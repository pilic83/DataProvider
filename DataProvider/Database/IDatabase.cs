using System.Data;

namespace DataProvider.Database
{
    internal interface IDatabase
    {
        IDbConnection GetConnection { get; }
        IDbCommand GetCommand(string StoredProcedureName, List<(string, object)>? MapParameters);
    }
}
