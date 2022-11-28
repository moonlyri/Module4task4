using System.Data;
using Microsoft.Extensions.Logging;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Services;

public class CreateTableService : BaseDataService<ApplicationDbContext>, ICreateTableService
{
    private readonly ITableRepository _tableRepository;
    private readonly ILogger<CreateTableService> _loggerService;

    public CreateTableService(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper,
        ILogger<BaseDataService<ApplicationDbContext>> logger,
        ITableRepository tableRepository,
        ILogger<CreateTableService> loggerService)
        : base(dbContextWrapper, logger)
    {
        _tableRepository = tableRepository;
        _loggerService = loggerService;
    }

    public void CreateTable(string name)
    {
        var set = new DataSet();
        var table = new DataTable(name);
        set.Tables.Add(table);
        _loggerService.LogInformation($"Added new table {name}");
    }

    public void DeleteTable(string name)
    {
        var set = new DataSet();
        var table = new DataTable(name);
        set.Tables.Remove(table); 
        _loggerService.LogInformation($"Table {name} was removed");
    }

    public void CopyTable(string table)
    {
        var mytable = new DataTable();
        var newtable = new DataTable(table);
        newtable = mytable.Copy();
        _loggerService.LogInformation($"Table {table} was copied to table {newtable}");
    }
}