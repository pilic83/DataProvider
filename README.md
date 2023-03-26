# DataProvider
Framework for executing SQL text queries and stored procedures in different databases.<br/>
All you have to do is create a data provider class that will derive from the generic class Provider with different type parameters for different databases. 
For example:<br/>
Microsoft SQL Server - Provider<SqlConnection, SqlCommand><br/>
SQLite - Provider<SQLiteConnection, SQLiteCommand><br/>
MySQL - Provider<MySqlConnection, MySqlCommand><br/>
Oracle - Provider<OracleConnection, OracleCommand><br/>
PostgreSQL - Provider<NpgsqlConnection, NpgsqlCommand><br/>
IBM DB2 - Provider<DB2Connection, DB2Command><br/>
Sybase - Provider<AseConnection, AseCommand><br/>
Firebird - Provider<FbConnection, FbCommand><br/>
SAP HANA - Provider<HanaConnection, HanaCommand><br/>
Teradata - Provider<TdConnection, TdCommand><br/>
Informix - Provider<IfxConnection, IfxCommand><br/>
<br/>
//MySQL database example<br/>
public class DataProvider : Provider<MySqlConnection, MySqlCommand><br/>
{<br/>
  public DataProvider(string connectionString) : base(connectionString)<br/>
  {<br/>
  }<br/>
  //Your methodes for executing stored procedures and text SQL queries<br/>
  //If your stored procedure or text SQL querie doesn't have parameters<br/>
  //you can just call Repository.ExecuteAsQuery("SomeStoredProcedure") and you'll get DataTable as result <br/>
  //or Repository.ExecuteAsQuery< Model >("SomeStoredProcedure") and you'll get List<Model> where Model you have define as record with all stufs which it contains to map database response<br/>
  //public record Model(int id, string name, DateTime date);<br/>
  //or you can call Repository.ExecuteAsQuery< string >("SomeStoredProcedure") or Repository.ExecuteAsQuery< int >("SomeStoredProcedure") or something else and get List<string> or List<int> depending on what you need<br/>
  //and finaly you can call Repository.ExecuteAsCommand("SomeStoredProcedure") and get true or false depending on whether the execution was successful<br/>
  <br/>
  //If your stored procedure or text SQL querie contains parameters, you have map parameters in List of Tuples<string, objects><br/>
  //where is string Item1 - parameter name, and object Item2 - parameter value<br/>
  //Rest is same as previous<br/>
  //Repository.ExecuteAsQuery< string >("SELECT * FROM Students WHERE Students.Year > @year", new List<(string, object)>(){("@year", someintvalue)})<br/>
  //or<br/>
  //Repository.ExecuteAsCommand("UpdateStudents", new List<(string, object)>(){("@year", someintvalue), ("@name", somestring)})<br/>
}<br/>
