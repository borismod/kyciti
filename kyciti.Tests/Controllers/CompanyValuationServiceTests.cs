using System.IO;
using System.Threading.Tasks;
using Autofac;
using kyciti.Controllers;
using kyciti.Models;
using Newtonsoft.Json;
using NUnit.Framework;

namespace kyciti.Tests.Controllers
{
    [TestFixture]
    public class CompanyValuationServiceTests
    {
        [TestCase("siemens")]
        [TestCase("volkswagen")]
        [TestCase("bezeq")]
        //[Ignore("Integration")]
        public async Task EvaluateCompany(string companyName)
        {
            var configureContainer = DependencyResolverConfig.ConfigureContainer();

            var companyValuationService = configureContainer.Resolve<ICompanyValuationService>();

            CompanyData companyValuationData = await companyValuationService.GetCompanyValuationData(companyName);
            var serializer = new JsonSerializer {Formatting = Formatting.Indented};

            using (var file = File.CreateText($@"c:\work\github\kyciti-api\{companyName}.json"))
            {
                serializer.Serialize(file, companyValuationData);
            }
        }
    }
}