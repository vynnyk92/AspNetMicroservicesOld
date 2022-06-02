using Catalog.API.Entities;
using Catalog.API.Settings;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Catalog.API.Data
{
    public class CatalogContext : ICatalogContext
    {
        private readonly DatabaseSettings _databaseSettings;
        private readonly IMongoClient _mongoClient;
        public CatalogContext(IOptions<DatabaseSettings> databaseSettings, IMongoClient mongoClient)
        {
            _databaseSettings = databaseSettings.Value;
            _mongoClient = mongoClient;
            var db = _mongoClient.GetDatabase(_databaseSettings.DatabaseName);
            Products = db.GetCollection<Product>(_databaseSettings.CollectionName);
        }

        public IMongoCollection<Product> Products { get; }
    }
}
