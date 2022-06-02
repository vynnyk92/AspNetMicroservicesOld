using System;
using System.Net.Http;

namespace Catalog.API.IntegrationTests.Infrastructure
{
    public class FeatureFixture : IDisposable
    {
        private readonly CustomWebAppFactory _applicationFactory;
        public readonly HttpClient Client;

        public FeatureFixture()
        {
            _applicationFactory = new CustomWebAppFactory();
            Client = _applicationFactory.CreateClient();
        }

        public void Dispose()
        {
            Client.Dispose();
            _applicationFactory.Dispose();
        }

    }
}
