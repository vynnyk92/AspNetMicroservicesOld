using System.Linq;
using Catalog.API.Repositories;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;

namespace Catalog.API.IntegrationTests.Infrastructure
{
    public class CustomWebAppFactory : WebApplicationFactory<Startup>
    {
        protected override void ConfigureWebHost(IWebHostBuilder builder)
        {
            builder.ConfigureServices(services =>
            {
                var repo = services.SingleOrDefault(
                    d => d.ServiceType ==
                         typeof(IProductRepository));

                services.Remove(repo);

                services.AddScoped<IProductRepository, TestProductRepository>();
            });
        }
    }
}
