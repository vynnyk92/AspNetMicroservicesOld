using System;
using Catalog.API.Entities;
using Catalog.API.Settings;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace Catalog.API.Extensions
{
    public static class MongoExtensions
    {
        public static IServiceCollection AddMongoClient(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var databaseSettings = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            var client = new MongoClient(databaseSettings.ConnectionString);
            return serviceCollection.AddSingleton<IMongoClient>(client);
        }

        public static IMongoCollection<Product> GetProductCollection(IServiceProvider serviceProvider)
        {
            var client = serviceProvider.GetRequiredService<IMongoClient>();
            var configuration = serviceProvider.GetRequiredService<IConfiguration>();
            var databaseSettings = configuration.GetSection("DatabaseSettings").Get<DatabaseSettings>();
            var db = client.GetDatabase(databaseSettings.DatabaseName);
            return db.GetCollection<Product>(databaseSettings.CollectionName);
        }
    }
}
