using Autofac;
using kyciti.Controllers;
using NUnit.Framework;

namespace kyciti.Tests.Controllers
{
    [TestFixture]
    public class CompanyKeyPersonsRetrieverTests
    {
        [Test]
        [Ignore("ignore")]
        public void Test()
        {
            var configureContainer = DependencyResolverConfig.ConfigureContainer();

            var companyKeyPersonsRetriever = configureContainer.Resolve<ICompanyKeyPersonsRetriever>();

            var keyPersons = companyKeyPersonsRetriever.GetKeyPersons("GOOGL.OQ");

            Assert.IsNotNull(keyPersons);
        }
    }
}