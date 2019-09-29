using Microsoft.Extensions.Configuration;

namespace SSO
{
    public static class AppSettings
    {
        public static string MongoDbDatabaseName { get; private set; }
        public static string MongoDbConnectionString { get; private set; }
        public static string UserCollectionName { get; private set; }

        public static void Configure(IConfiguration configuration)
        {
            MongoDbConnectionString = configuration?.GetConnectionString("MongoDbConnectionString");
            MongoDbDatabaseName = configuration?.GetSection("MongoDbDatabaseName").Value;
            UserCollectionName = configuration?.GetSection("UserCollectionName").Value;
        }
    }
}
