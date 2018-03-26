using kyciti.Controllers;
using NUnit.Framework;

namespace kyciti.Tests.Controllers
{
    [TestFixture]
    public class CompanyStockTickerRetrieverTests
    {
        [Test]
        [Ignore("integration")]
        public void Test()
        {
            var companyStockTickerRetriever = new CompanyStockTickerRetriever();
            var companyStockTicker = companyStockTickerRetriever.GetCompanyStockTicker("google");

            Assert.NotNull(companyStockTicker);
            //TestCop				
            Assert.Fail("WriteMe");
        }
    }
}