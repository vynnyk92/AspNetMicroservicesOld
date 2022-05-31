using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Data;
using Catalog.API.Entities;
using MongoDB.Driver;

namespace Catalog.API.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ICatalogContext _catalogContext;

        public ProductRepository(ICatalogContext catalogContext)
        {
            _catalogContext = catalogContext;
        }

        public async Task CreateProduct(Product product)
        {
            await _catalogContext.Products.InsertOneAsync(product);
        }

        public async Task<bool> DeleteProduct(string id)
        {
            var result = await _catalogContext.Products.DeleteOneAsync(p=> p.Id == id);
            return result.IsAcknowledged && result.DeletedCount == 1;
        }

        public async Task<Product> GetProduct(string id)
        {
            return await _catalogContext.Products
                .Find(p => p.Id == id)
                .FirstOrDefaultAsync();

        }

        public async Task<IReadOnlyCollection<Product>> GetProductByCategory(string categoryName)
        {
            return await _catalogContext.Products.Find(p => p.Category.Equals(categoryName)).ToListAsync();
        }

        public async Task<Product> GetProductByName(string name)
        {
            return await _catalogContext.Products
                .Find(p => p.Name == name)
                .FirstOrDefaultAsync();
        }

        public async Task<IReadOnlyCollection<Product>> GetProducts()
        {
            return await _catalogContext.Products.Find(p => true).ToListAsync();
        }

        public async Task<bool> UpdateProduct(Product product)
        {
            var result = await _catalogContext.Products.ReplaceOneAsync(p=> p.Id == product.Id, replacement: product);
            return result.IsAcknowledged && result.ModifiedCount == 1;
        }
    }
}
