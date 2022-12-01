using System;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace Module4task4.Services.Abstractions;

public abstract class BaseDataService<T>

    where T : DbContext
{
    private readonly IDbContextWrapper<T> _dbContextWrapper;
    private readonly ILogger<BaseDataService<ApplicationDbContext>> _logger;

    protected BaseDataService(
        IDbContextWrapper<T> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger)
    {
        _dbContextWrapper = dbContextWrapper;
        _logger = logger;
    }

    protected Task ExecuteSafeAsync(
        Func<Task> action,
        CancellationToken cancellationToken = default)
        => ExecuteSafeAsync(token => action(), cancellationToken);

    protected Task<TResult> ExecuteSafeAsync<TResult>(
        Func<Task<TResult>> action,
        CancellationToken cancellationToken = default)
        => ExecuteSafeAsync(token => action(), cancellationToken);

    private async Task ExecuteSafeAsync(
        Func<CancellationToken, Task> action,
        CancellationToken cancellationToken = default)
    {
        await using var transaction = await _dbContextWrapper.BeginTransactionAsync(cancellationToken);

        try
        {
            await action(cancellationToken);

            await transaction.CommitAsync(cancellationToken);
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(ex, $"Transaction was rollbacked");
            throw;
        }
    }

    private async Task<TResult> ExecuteSafeAsync<TResult>(Func<CancellationToken, Task<TResult>> action, CancellationToken cancellationToken = default)
    {
        await using var transaction = await _dbContextWrapper.BeginTransactionAsync(cancellationToken);

        try
        {
            var result = await action(cancellationToken);

            await transaction.CommitAsync(cancellationToken);

            return result;
        }
        catch (Exception ex)
        {
            await transaction.RollbackAsync(cancellationToken);
            _logger.LogError(ex, $"transaction is rollbacked");
            throw;
        }
    }
}