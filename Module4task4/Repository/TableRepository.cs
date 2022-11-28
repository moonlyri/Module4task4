using System.Data;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Module4task4.Repository.Abstractions;
using Module4task4.Services.Abstractions;

namespace Module4task4.Repository;

public class TableRepository : ITableRepository
{
    private readonly ApplicationDbContext _dbContext;

    public TableRepository(
        IDbContextWrapper<ApplicationDbContext> dbContextWrapper)
    {
        _dbContext = dbContextWrapper.DbContext;
    }

    public void CreateTable(DataTable table, DataSet set)
    {
        set.Tables.Add(table);
    }

    public void DeleteTable(DataTable table, DataSet set)
    {
        set.Tables.Remove(table); 
    }

    public void CopyTable(DataTable table, DataTable newtable)
    {
        newtable = table.Copy();
    }
}