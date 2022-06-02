using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using Catalog.API.Entities;
using Catalog.API.IntegrationTests.Infrastructure;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Bson.IO;
using Xunit;
using JsonConvert = Newtonsoft.Json.JsonConvert;

namespace Catalog.API.IntegrationTests.Controllers
{
    [Collection(nameof(CollectionFixture))]
    public class CatalogControllersTest
    {
        private readonly HttpClient _httpClient;

        public CatalogControllersTest(FeatureFixture featureFixture)
        {
            _httpClient = featureFixture.Client;
        }

        [Fact]
        public async Task GetProductsByCategory_WhenOneInCollection_ShouldReturnOneelement()
        {
            var correctCategoryName = "Smart Phone";
            var requestUri = $"api/v1/catalog/GetProductByCategory/{correctCategoryName}";
            var response = await _httpClient.GetAsync(requestUri);

            Assert.True(response.StatusCode.Equals(HttpStatusCode.OK));

            var data = await response.Content.ReadAsStringAsync();
            var content = JsonConvert.DeserializeObject<IReadOnlyCollection<Product>>(data);
            Assert.True(content.Count.Equals(1));
        }
    }
}
