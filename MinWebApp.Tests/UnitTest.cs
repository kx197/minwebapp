using MinWebApp.ServiceInterface;
using MinWebApp.ServiceModel;
using MinWebApp.ServiceModel.Types;
using NUnit.Framework;
using ServiceStack;
using ServiceStack.Testing;

namespace MinWebApp.Tests
{
    public class UnitTest
    {
        private readonly ServiceStackHost appHost;

        public UnitTest()
        {
            appHost = new BasicAppHost().Init();
            appHost.Container.AddTransient<CompanyServices>();
        }

        [OneTimeTearDown]
        public void OneTimeTearDown() => appHost.Dispose();

        [Test]
        public void Can_call_CompanyServices_without_name()
        {
            var service = appHost.Container.Resolve<CompanyServices>();

            var response = (CompanyResponse)service.Get(new GetCompany());
            Assert.That(response?.Result, Is.Null);
        }

        [Test]
        public void Can_call_CompanyServices_with_name()
        {
            var service = appHost.Container.Resolve<CompanyServices>();

            var name = "Acme";
            var response = (CompanyResponse)service.Get(new GetCompany { Name = name });
            Assert.That(response?.Result?.Name, Is.EqualTo(name));
        }
    }
}
