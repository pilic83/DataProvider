using DataProviderDemo.DataProvider;
using DataProviderDemo.Model;

DataProviderDemo.DataProvider.DataProvider dp = Helpers.GetDataProvider();

var names = dp.LoadNamesOfAllContestantsWithHeighSalaryInList(140);
Console.WriteLine(dp.Message);

var list = dp.LoadAllContestantsInList();
Console.WriteLine(dp.Message);

var tabela = dp.LoadAllContestantsInDataTable();
Console.WriteLine(dp.Message);

dp.AddContestant(new Contestant(7, "djura", "mutavi", DateTime.Now, 105));
Console.WriteLine(dp.Message);

names = dp.LoadNamesOfAllContestantsWithHeighSalaryInList(140);
Console.WriteLine(dp.Message);

list = dp.LoadAllContestantsInListUsingSQLQuery();
Console.WriteLine(dp.Message);

list = dp.LoadDataAboutContestant("askur");
Console.WriteLine(dp.Message);

Console.ReadLine();