using Funq;
using MinWebApp.ServiceInterface;
using MinWebApp.ServiceModel;
using NUnit.Framework;
using ServiceStack;

namespace MinWebApp.Tests
{
    public class IntegrationTest
    {
        const string BaseUri = "http://localhost:2000";
        private readonly ServiceStackHost appHost;

        class AppHost : AppSelfHostBase
        {
            public AppHost() : base(nameof(IntegrationTest), typeof(CompanyServices).Assembly) { }

            public override void Configure(Container container)
            {
            }
        }

        public IntegrationTest()
        {
            appHost = new AppHost()
                .Init()
                .Start(BaseUri);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        public IServiceClient CreateClient() => new JsonServiceClient(BaseUri);

        [Test]
        public void Can_call_Company_Services()
        {
            var client = CreateClient();

            var name = "Acme";
            var response = client.Get(new GetCompany { Name = name });
            Assert.That(response?.Result?.Name, Is.EqualTo(name));
        }
    }
}