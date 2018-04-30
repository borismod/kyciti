using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using kyciti.Controllers;
using NUnit.Framework;

namespace kyciti.Tests
{
    [TestFixture]
    public class ValuationInitializerTests
    {
        [Test]
        public async Task Initialize_TotalScore_IsGreaterThanZero()
        {
            // Arrange
            var configureContainer = DependencyResolverConfig.ConfigureContainer();
            var valuationInitializer = configureContainer.Resolve<IValuationInitializer>();
            var cashedValuationService = configureContainer.Resolve<ICashedValuationService>();

            // Act
            valuationInitializer.Initialize();

            var cachedValudationData = await cashedValuationService.GetCachedValudationData("bezeq");

            // Assert
            cachedValudationData.TotalScore.Should().BeGreaterThan(0);
        }
    }
}