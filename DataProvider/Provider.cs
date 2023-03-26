using DataProvider.Repository;
using DataProvider.Database;
using System.Data;

namespace DataProvider
{
    public class Provider<Connection, Command>
        where Connection : IDbConnection, new()
        where Command : IDbCommand, new()
    {
        private readonly IRepository _repository;

        public string Message => _repository.Message;

        protected IRepository Repository => _repository;

        public Provider(string connectionString)
        {
            IDatabase database = new Database<Connection, Command>(connectionString);
            IRepository repository = new DataProvider.Repository.Repository(database);
            _repository = repository;
        }
    }
}
