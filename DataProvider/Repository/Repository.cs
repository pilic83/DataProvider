using System.Data;
using System.Reflection;
using DataProvider.Database;

namespace DataProvider.Repository
{
    internal class Repository : IRepository
    {
        private readonly IDatabase _database;
        private string message = string.Empty;

        public Repository(IDatabase database)
        {
            _database = database;
        }

        public bool ExecuteAsCommand(string SQLQuery_OR_StoredProcedureName, List<(string, object)>? MapParameters = null)
        {
            try
            {
                using (IDbConnection connection = _database.GetConnection)
                using (IDbCommand command = _database.GetCommand(SQLQuery_OR_StoredProcedureName, MapParameters))
                {
                    connection.Open();
                    int affectedRows = command.ExecuteNonQuery();
                    message = $"Row affected: {affectedRows}";
                    return true;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return false;
            }
        }

        public DataTable? ExecuteAsQuery(string SQLQuery_OR_StoredProcedureName, List<(string, object)>? MapParameters = null)
        {
            try
            {
                DataTable table = new DataTable();
                using (IDbConnection connection = _database.GetConnection)
                using (IDbCommand command = _database.GetCommand(SQLQuery_OR_StoredProcedureName, MapParameters))
                {
                    connection.Open();
                    using (IDataReader dataReader = command.ExecuteReader())
                    {
                        table.Load(dataReader);
                    }
                    message = $"Row affected: {table.Rows.Count}";
                    return table;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }

        public IList<T>? ExecuteAsQuery<T>(string SQLQuery_OR_StoredProcedureName, List<(string, object)>? MapParameters = null)
        {
            try
            {
                IList<T> listT = new List<T>();
                using (IDbConnection connection = _database.GetConnection)
                using (IDbCommand command = _database.GetCommand(SQLQuery_OR_StoredProcedureName, MapParameters))
                {
                    connection.Open();
                    using (IDataReader dataReader = command.ExecuteReader())
                    {
                        while (dataReader.Read())
                        {
                            if (!(typeof(T).IsValueType || typeof(T).Equals(typeof(string))))
                            {
                                List<object> TValuesParameters = new List<object>();
                                PropertyInfo[] properties = typeof(T).GetProperties();
                                for (int i = 0; i < properties.Length; i++)
                                {
                                    TValuesParameters.Add(dataReader.GetValue(i));
                                }
                                T data = (T)Activator.CreateInstance(typeof(T), TValuesParameters.ToArray());
                                listT.Add(data);
                            }
                            else
                            {
                                var data = Convert.ChangeType(0, typeof(T));
                                data = Convert.ChangeType(dataReader.GetValue(0).ToString(), typeof(T));
                                listT.Add((T)data);
                            }
                        }
                    }
                    message = $"Row affected: {listT.Count}";
                    return listT;
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                return null;
            }
        }

        public string Message => message;
    }
}
