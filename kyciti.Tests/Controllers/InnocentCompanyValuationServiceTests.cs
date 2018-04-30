using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using kyciti.Controllers;
using NUnit.Framework;

namespace kyciti.Tests.Controllers
{
    [TestFixture]
    public class InnocentCompanyValuationServiceTests
    {
        [Test]
        public async Task ConfigureContainer_ResolveICompanyValuationService_ResolvedInnocentCompanyValuationService()
        {
            // Act
            var configureContainer = DependencyResolverConfig.ConfigureContainer();

            var companyValuationService = configureContainer.Resolve<IInnocentCompanyValuationService>();
            var companyValuationData = await companyValuationService.GetCompanyValuationData("citigroup");

            // Assert
            companyValuationData.TotalScore.Should().Be(0);
        }
    }
}

