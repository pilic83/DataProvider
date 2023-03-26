using System.Data;
using System.Data.Common;

namespace DataProvider.Database
{
    internal class Database<Connection, Command> : IDatabase
     where Connection : IDbConnection , new()
     where Command : IDbCommand , new()
    {
        private readonly string _connectionString;
        private Connection? _connection;

        public Database(string connectionString)
        {
            _connectionString = connectionString;
        }

        public IDbConnection GetConnection
        {
            get
            {
                _connection = new Connection();
                _connection.ConnectionString = _connectionString;
                return _connection;
            }
        }

        public IDbCommand GetCommand(string SQLQuery_OR_StoredProcedureName, List<(string, object)>? MapParameters)
        {
            Command command = new Command();
            command.Connection = _connection;
            command.CommandType = CommandType.Text;
            if (SQLQuery_OR_StoredProcedureName.Split(' ').Length == 1)
                command.CommandType = CommandType.StoredProcedure;
            command.CommandText = SQLQuery_OR_StoredProcedureName;

            MapParameters?.ForEach(parameter =>
            {
                var dbDataParameter = command.CreateParameter();
                dbDataParameter.ParameterName = parameter.Item1;
                dbDataParameter.Value = parameter.Item2;
                command.Parameters.Add(dbDataParameter); 
            });
            return command;
        }
    }
}
