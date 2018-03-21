using System.IO;
using kyciti.CrunchBase.QuickType;

namespace kyciti.CrunchBase
{
    public class CompanyDataRetriever
    {
        public Company GetCompanyData()
        {
            var stream = GetType().Assembly
                .GetManifestResourceStream("kyciti.CrunchBase.CrunchBaseData.json");

            using (StreamReader reader = new StreamReader(stream))
            {
                string text = reader.ReadToEnd();
                return Company.FromJson(text);
            }
        }
    }
}