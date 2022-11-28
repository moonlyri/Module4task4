using System.Data;

namespace Module4task4.Services.Abstractions;

public interface ICreateTableService
{
    void CreateTable(string table);
    void DeleteTable(string name);
    void CopyTable(string table);
}