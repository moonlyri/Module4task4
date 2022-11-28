using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Module4task4.Services.Abstractions;

namespace Module4task4.Services;

public class DbContextWrapper<T> : IDbContextWrapper<T>
    where T : DbContext
{
    private readonly T _dbContext;

    public DbContextWrapper(
        IDbContextFactory<T> dbContextFactory)
    {
        _dbContext = dbContextFactory.CreateDbContext();
    }

    public T DbContext => _dbContext;

    public Task<IDbContextTransaction> BeginTransactionAsync(CancellationToken cancellationToken)
    {
        return _dbContext.Database.BeginTransactionAsync(cancellationToken);
    }
}