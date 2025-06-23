using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.IO;

namespace Dal
{
    public class MongoDbContext
    {
        private readonly IMongoDatabase _database;

        public MongoDbContext()
        {
            // טוען את הקונפיגורציה מה־appsettings.json
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory()) // חשוב – מאיפה לטעון את הקובץ
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();

            // קורא את המחרוזת חיבור והשם של הדאטהבייס
            var connectionString = configuration["MongoDbSettings:ConnectionString"];
            var databaseName = configuration["MongoDbSettings:DatabaseName"];

            // יוצר את הלקוח של MongoDB
            var client = new MongoClient(connectionString);

            // מתחבר לדאטהבייס
            _database = client.GetDatabase(databaseName);
        }

        // פונקציה לקבל קולקשן לפי שם
        public IMongoCollection<T> GetCollection<T>(string name)
        {
            return _database.GetCollection<T>(name);
        }
    }
}
