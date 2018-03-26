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
            var companyKeyPersonsRetriever = new CompanyKeyPersonsRetriever();
            var keyPersons = companyKeyPersonsRetriever.GetKeyPersons("GOOGL.OQ");

            Assert.IsNotNull(keyPersons);
        }
    }
}