using System.Linq;

namespace kyciti.CrunchBase
{
    public class CompanyKeyPersonsRetriever
    {
        private readonly ICompanyDataRetriever _companyDataRetriever;

        public CompanyKeyPersonsRetriever(ICompanyDataRetriever companyDataRetriever)
        {
            _companyDataRetriever = companyDataRetriever;
        }

        public KeyPerson[] GetKeyPersons(string companyName)
        {
            var companyData = _companyDataRetriever.GetCompanyData(companyName);

            return companyData.Data.Relationships.BoardMembersAndAdvisors.Items
                .Select(i => new KeyPerson
                {
                    Category = "Board",
                    Title = i.Properties.Title,
                    Name = i.Properties.FirstName,
                }).ToArray();
        }
    }
}
