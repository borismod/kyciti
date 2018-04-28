using Autofac;
using FluentAssertions;
using kyciti.Controllers;
using NUnit.Framework;

namespace kyciti.Tests
{
    [TestFixture]
    public class DependencyResolverConfigTests
    {
        [Test]
        public void ConfigureContainer_ResolveValuationController_Resolved()
        {
            // Act
            var configureContainer = DependencyResolverConfig.ConfigureContainer();

            var valuationController = configureContainer.Resolve<ValuationController>();

            // Arrange
            valuationController.Should().BeOfType<ValuationController>();
        }

        [Test]
        public void ConfigureContainer_ResolveCompanyController_Resolved()
        {
            // Act
            var configureContainer = DependencyResolverConfig.ConfigureContainer();

            var valuationController = configureContainer.Resolve<CompanyController>();

            // Arrange
            valuationController.Should().BeOfType<CompanyController>();
        }

        [Test]
        public void ConfigureContainer_ResolveCashedCompanyDataRetriever_Resolved()
        {
            // Act
            var configureContainer = DependencyResolverConfig.ConfigureContainer();

            var cashedCompanyDataRetriever1 = configureContainer.Resolve<ICashedCompanyDataRetriever>();
            var cashedCompanyDataRetriever2 = configureContainer.Resolve<ICashedCompanyDataRetriever>();

            // Assert
            cashedCompanyDataRetriever1.Should().Be(cashedCompanyDataRetriever2);
        }
    }
}