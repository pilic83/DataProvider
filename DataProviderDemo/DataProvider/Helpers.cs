namespace DataProviderDemo.DataProvider
{
    public static class Helpers
    {
        public static DataProvider GetDataProvider()
        {
            string connection = "data source=DESKTOP-AE2LP3R;" +
                                   "database=TestBaza;" +
                                   "integrated security = true;";
            return new DataProvider(connection);
        }
    }
}
