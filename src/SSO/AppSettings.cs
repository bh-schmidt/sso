using Microsoft.Extensions.Configuration;

namespace SSO
{
    public static class AppSettings
    {
        private static IConfiguration appConfiguration;

        //public static string MongoDbConnectionString => appConfiguration?.GetConnectionString("MongoDbConnectionString");
        public static string MongoDbDatabaseName;
        public static string MongoDbConnectionString;
        public static string UserCollectionName;

        public static void Configure(IConfiguration configuration)
        {
            appConfiguration = configuration;

            MongoDbConnectionString = appConfiguration?.GetConnectionString("MongoDbConnectionString");
            MongoDbDatabaseName = appConfiguration?.GetSection("MongoDbDatabaseName").Value;
            UserCollectionName = appConfiguration?.GetSection("UserCollectionName").Value;
        }
    }
}
