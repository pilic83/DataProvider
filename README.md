# DataProvider
Framework for executing SQL text queries and stored procedures in different databases.<br/>
All you have to do is create a data provider class that will derive from the generic class Provider with different type parameters for different databases. 
For example:<br/>
Microsoft SQL Server - `Provider<SqlConnection, SqlCommand>`<br/>
SQLite - `Provider<SQLiteConnection, SQLiteCommand>`<br/>
MySQL - `Provider<MySqlConnection, MySqlCommand>`<br/>
Oracle - `Provider<OracleConnection, OracleCommand>`<br/>
PostgreSQL - `Provider<NpgsqlConnection, NpgsqlCommand>`<br/>
IBM DB2 - `Provider<DB2Connection, DB2Command>`<br/>
Sybase - `Provider<AseConnection, AseCommand>`<br/>
Firebird - `Provider<FbConnection, FbCommand>`<br/>
SAP HANA - `Provider<HanaConnection, HanaCommand>`<br/>
Teradata - `Provider<TdConnection, TdCommand>`<br/>
Informix - `Provider<IfxConnection, IfxCommand>`<br/>
<br/>
MySQL database example<br/>
```
public class DataProvider : Provider<MySqlConnection, MySqlCommand>
{
  public DataProvider(string connectionString) : base(connectionString)
  {
  }
  //Your methodes for executing stored procedures and text SQL queries
  
}
```
If your stored procedure or text SQL querie doesn't have parameters you can just call<br/> 
`Repository.ExecuteAsQuery("SomeStoredProcedure");`<br/> 
and you'll get DataTable as result, or<br/> 
`Repository.ExecuteAsQuery<Model>("SomeStoredProcedure");`<br/> 
and you'll get List<Model> where Model you have define as record with all stufs which it contains to map database response<br/>
public record Model(int id, string name, DateTime date);<br/>
You can call<br/> 
`Repository.ExecuteAsQuery<string>("SomeStoredProcedure");`<br/> 
or<br/> 
`Repository.ExecuteAsQuery<int>("SomeStoredProcedure");`<br/> 
or something else and get List<string> or List<int> depending on what you need<br/>
And finally you can call<br/> 
`Repository.ExecuteAsCommand("SomeStoredProcedure");`<br/> 
and get true or false depending on whether the execution was successful<br/>

If your stored procedure or text SQL querie contains parameters, you have map parameters in List of Tuples<string, objects><br/>
where is string Item1 - parameter name, and object Item2 - parameter value<br/>
Rest is same as previous<br/>
`Repository.ExecuteAsQuery<string>("SELECT * FROM Students WHERE Students.Year > @year", new List<(string, object)>(){("@year", someintvalue)});`<br/>
or<br/>
`Repository.ExecuteAsCommand("UpdateStudents", new List<(string, object)>(){("@year", someintvalue), ("@name", somestring)});`<br/>
