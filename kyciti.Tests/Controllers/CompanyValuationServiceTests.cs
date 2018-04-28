using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using kyciti.Controllers;
using NUnit.Framework;

namespace kyciti.Tests.Controllers
{
    [TestFixture]
    public class CompanyValuationServiceTests
    {
        [Test]
        [Ignore("Integration")]
        public async Task Test()
        {
            var configureContainer = DependencyResolverConfig.ConfigureContainer();

            var companyValuationService = configureContainer.Resolve<ICompanyValuationService>();

            var companyValuationData = await companyValuationService.GetCompanyValuationData("citigroup");

            companyValuationData.TotalScore.Should().Be(0);
        }
    }
}