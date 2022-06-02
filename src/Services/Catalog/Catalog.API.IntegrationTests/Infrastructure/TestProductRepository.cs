using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.Repositories;

namespace Catalog.API.IntegrationTests.Infrastructure
{
    public class TestProductRepository : IProductRepository
    {
        private readonly IReadOnlyCollection<Product> products;

        public TestProductRepository()
        {
            this.products = new List<Product>()
            {
                new Product()
                {
                    Id = "602d2149e773f2a3990b47f5",
                    Name = "IPhone X",
                    Summary = "This phone is the company's biggest change to its flagship smartphone in years. It includes a borderless.",
                    Description = "Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus. Lorem ipsum dolor sit amet, consectetur adipisicing elit. Ut, tenetur natus doloremque laborum quos iste ipsum rerum obcaecati impedit odit illo dolorum ab tempora nihil dicta earum fugiat. Temporibus, voluptatibus.",
                    ImageFile = "product-1.png",
                    Price = 950.00M,
                    Category = "Smart Phone"
                }
            };
        }

        public Task CreateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> DeleteProduct(string id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Product> GetProduct(string id)
        {
            throw new System.NotImplementedException();
        }

        public async Task<IReadOnlyCollection<Product>> GetProductByCategory(string categoryName)
        {
            var product = products.Where(p => p.Category == categoryName).ToList();
            return await Task.FromResult(product);
        }

        public Task<Product> GetProductByName(string name)
        {
            throw new System.NotImplementedException();
        }

        public Task<IReadOnlyCollection<Product>> GetProducts()
        {
            throw new System.NotImplementedException();
        }

        public Task<bool> UpdateProduct(Product product)
        {
            throw new System.NotImplementedException();
        }
    }
}
