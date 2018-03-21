using System.IO;
using System.Linq;
using kyciti.CrunchBase.QuickType;

namespace kyciti.CrunchBase
{
    public interface ICompanyDataRetriever
    {
        Company GetCompanyData(string companyName);
    }

    public class CompanyDataRetriever : ICompanyDataRetriever
    {
        public Company GetCompanyData(string companyName)
        {
            var assembly = GetType().Assembly;

            var companyResourceName = $"kyciti.Engine.{companyName}.json";
            var defaultResourceName = assembly.GetManifestResourceNames().First();

            var stream = assembly.GetManifestResourceStream(companyResourceName) ??
                assembly.GetManifestResourceStream(defaultResourceName);

            using (StreamReader reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();
                return Company.FromJson(text);
            }
        }
    }
}