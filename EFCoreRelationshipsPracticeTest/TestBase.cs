using System.Net.Http;
using EFCoreRelationshipsPractice;
using Xunit;

namespace EFCoreRelationshipsPracticeTest
{
    public class TestBase : IClassFixture<CustomWebApplicationFactory<Startup>>
    {
        public TestBase(CustomWebApplicationFactory<Startup> factory)
        {
            this.Factory = factory;
        }

        protected CustomWebApplicationFactory<Startup> Factory { get; }

        protected HttpClient GetClient()
        {
            return Factory.CreateClient();
        }
    }
}