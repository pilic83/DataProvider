using DataProvider;
using DataProviderDemo.Model;
using System.Data;
using System.Data.SqlClient;

namespace DataProviderDemo.DataProvider
{
    public class DataProvider : Provider<SqlConnection, SqlCommand>
    {
        public DataProvider(string connectionString) : base(connectionString)
        {
        }
        public DataTable? LoadAllContestantsInDataTable()
        {
            return Repository.ExecuteAsQuery("UcitajTakmicare");
        }

        public List<Contestant>? LoadAllContestantsInList()
        {
            return Repository.ExecuteAsQuery<Contestant>("UcitajTakmicare")?.ToList();
        }

        public List<string>? LoadNamesOfAllContestantsWithHeighSalaryInList(decimal salary)
        {
            List<(string, object)> mapParameters = new();
            mapParameters.Add(("@price", salary));
            return Repository.ExecuteAsQuery<string>("UcitajImenaTakmicara", mapParameters)?.ToList();
        }

        public void AddContestant(Contestant contestant)
        {
            List<(string, object)> mapParameters = new() { 
                ("@id", contestant.id),
                ("@name", contestant.name),
                ("@description", contestant.description),
                ("@price", contestant.price)
            };
            Repository.ExecuteAsCommand("DodajTakmicara", mapParameters);
        }

        public void RemoveContestant(Contestant contestant)
        {
            List<(string, object)> mapParameters = new();
            mapParameters.Add(("@id", contestant.id));
            Repository.ExecuteAsCommand("ObrisiTakmicara", mapParameters);
        }

        public List<Contestant>? LoadAllContestantsInListUsingSQLQuery()
        {
            string sqlQuery = "select * from takmicar";
            return Repository.ExecuteAsQuery<Contestant>(sqlQuery)?.ToList();
        }

        public List<Contestant>? LoadDataAboutContestant(string name)
        {
            string sqlQuery = "select * from takmicar where takmicar.ime like @name";
            List<(string, object)> mapParameters = new();
            mapParameters.Add(("@name", name));
            return Repository.ExecuteAsQuery<Contestant>(sqlQuery, mapParameters)?.ToList();
        }
    }
}
