using System.Data;

namespace Module4task4.Repository.Abstractions;

public interface ITableRepository
{
    void CreateTable(DataTable table, DataSet set);
    void DeleteTable(DataTable table, DataSet set);
    void CopyTable(DataTable table, DataTable newtable);
}