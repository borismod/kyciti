using kyciti.CrunchBase;
using NUnit.Framework;

namespace kyciti.Tests.CrunchBase
{
    [TestFixture]
    public class CompanyDataRetrieverTests
    {
        [Test]
        public void GetCompanyData_ReturnsNotNull()
        {
            var companyDataRetriever = new CompanyDataRetriever();
            var companyData = companyDataRetriever.GetCompanyData();


            Assert.IsNotNull(companyData);
        }
    }
}