using Xunit;

namespace Catalog.API.IntegrationTests.Infrastructure
{
    [CollectionDefinition(nameof(CollectionFixture))]
    public class CollectionFixture : ICollectionFixture<FeatureFixture>
    {
    }
}
