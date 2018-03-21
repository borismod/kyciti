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
                    FirstName = i.Properties.FirstName,
                    LastName = i.Properties.LastName
                }).ToArray();
        }
    }

    public class KeyPerson
    {
        public string Category { get; set; }
        public string Title { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
