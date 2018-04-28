using System.Collections.Generic;
using kyciti.Controllers;

namespace kyciti.Models
{
    public class CompanyData
    {
        public CompanyData()
        {
            Scores = new List<CompanyScore>();
            Members = new List<Person>();
        }

        public string Category { get; set; }
        public string Name { get; set; }
        public List<Person> Members { get; set; }
        public List<CompanyScore> Scores { get; }
        public double TotalScore { get; set; }
    }
}