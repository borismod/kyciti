using System.Threading.Tasks;
using Autofac;
using FluentAssertions;
using kyciti.Controllers;
using NUnit.Framework;

namespace kyciti.Tests.Controllers
{
    [TestFixture]
    public class PersonEvaluationServiceTests
    {
        [Test]
        public async Task EvaluatePersonAsync_InnocentPerson_ZeroResults()
        {
            var configureContainer = DependencyResolverConfig.ConfigureContainer();
            var personEvaluationService = configureContainer.Resolve<IPersonEvaluationService>();

            var searchEngineResults = await personEvaluationService.EvaluatePersonAsync("Michael Corbat", "money laundering");

            // Assert
            searchEngineResults.Should().HaveCount(0);
        }

        [Test]
        public async Task EvaluatePersonAsync_SuspiciousPerson_SomeResults()
        {
            var configureContainer = DependencyResolverConfig.ConfigureContainer();
            var personEvaluationService = configureContainer.Resolve<IPersonEvaluationService>();

            var searchEngineResults = await personEvaluationService.EvaluatePersonAsync("Stella Handler", "fraud");

            // Assert
            searchEngineResults.Should().HaveCountGreaterThan(0);
        }
    }
}

