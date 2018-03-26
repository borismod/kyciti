using kyciti.CrunchBase;
using NUnit.Framework;

namespace kyciti.Tests.CrunchBase
{
    [TestFixture]
    public class CompanyDataRetrieverTests
    {
        [Test]
        public void GetCompanyData_CrunchBase_ReturnsNotNull()
        {
            var companyDataRetriever = new MockCompanyDataRetriever();
            var companyData = companyDataRetriever.GetCompanyData("CrunchBase");

            Assert.IsNotNull(companyData);
        }

        [Test]
        public void GetCompanyData_Unknown_ReturnsNotNull()
        {
            var companyDataRetriever = new MockCompanyDataRetriever();

            var companyData = companyDataRetriever.GetCompanyData("Unknown");

            Assert.IsNotNull(companyData);
        }
    }
}