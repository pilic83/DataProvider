using System.Data;

namespace DataProvider.Repository
{
    public interface IRepository
    {
        /// <summary>
        /// Return the message after execution on database
        /// </summary>
        string Message { get; }
        /// <summary>
        /// Execute stored procedure or SQL query as text.
        /// </summary>
        /// <param name="SQLQuery_OR_StoredProcedureName">String presents name of stored procedure OR text of SQL query.</param>
        /// <param name="MapParameters">List of tuples presents parametars names and values.</param>
        /// <returns>Returns true if execution is properly done.</returns>
        bool ExecuteAsCommand(string SQLQuery_OR_StoredProcedureName, List<(string, object)>? MapParameters = null);
        /// <summary>
        /// Execute stored procedure or SQL query as text.
        /// </summary>
        /// <param name="SQLQuery_OR_StoredProcedureName">String presents name of stored procedure OR text of SQL query.</param>
        /// <param name="MapParameters">List of tuples presents parametars names and values.</param>
        /// <returns>Returns data in DataTable.</returns>
        DataTable? ExecuteAsQuery(string SQLQuery_OR_StoredProcedureName, List<(string, object)>? MapParameters = null);
        /// <summary>
        /// Execute stored procedure or SQL query as text.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="SQLQuery_OR_StoredProcedureName">String presents name of stored procedure OR text of SQL query.</param>
        /// <param name="MapParameters">List of tuples presents parametars names and values.</param>
        /// <returns>Returns data in list.</returns>
        IList<T>? ExecuteAsQuery<T>(string SQLQuery_OR_StoredProcedureName, List<(string, object)>? MapParameters = null);
    }
}
