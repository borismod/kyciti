using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyciti.Controllers
{
    public enum RiskValuations
    {
        Low = 1,
        Medium,
        High
    }

    public class Person
    {
        public Person()
        {
            Scores = new List<PersonScore>();
        }

        public string Name { get; set; }
        public string Title { get; set; }
        public List<PersonScore> Scores { get; }
        public int TotalScore { get; set; }
    }

    public class CompanyData
    {
        public CompanyData()
        {
            Scores = new List<CompanyScore>();
            Members = new List<Person>();
        }

        public static CompanyData GetMockData(string id, bool addValuation)
        {
            if (id.ToLower() == "bezeq")
            {
                var shaulLinks = new Dictionary<string, List<string>>()
                {
                    {
                        "Shaul Elovitch Chairman bribe",
                        new List<string>
                        {
                            "https://www.timesofisrael.com/bezeq-controlling-shareholder-elovitch-to-resign-from-board-amid-probe/",
                            "https://www.timesofisrael.com/top-officials-executives-revealed-as-suspects-in-bezeq-graft-investigation/"
                        }
                    },

                    {
                        "Shaul Elovitch Chairman money laundry",
                        new List<string>
                        {
                            "https://www.reuters.com/article/bezeq-chairman-investigation/bezeq-telecoms-acting-chairman-detained-in-bribery-probe-police-idUSL8N1L02XO",
                            "https://www.haaretz.com/israel-news/acting-bezeq-chairman-held-in-steinmetz-affair-1.5442738"
                        }
                    }
                };

                var person1 = new Person() {Name = "Shaul Elovitch", Title = "Chairman"};
                var person2 = new Person() {Name = "Stella Handler", Title = "Chief Executive Officer"};
                var person3 = new Person() {Name = "David Granot", Title = "Temporary Acting Chairman"};

                return new CompanyData() {Name = id, Members = new List<Person>() {person1, person2, person3}};
            }
            else
            {
                var person1 = new Person() {Name = "Michael Corbat", Title = "CEO",};
                var person2 = new Person() {Name = "Don Callahan", Title = "Head of operation"};
                var person3 = new Person() {Name = "Stuart Riley", Title = "Head of Markets"};

                return new CompanyData() {Name = id, Members = new List<Person>() {person1, person2, person3}};
            }
        }

        public string Category { get; set; }
        public string Name { get; set; }
        public List<Person> Members { get; set; }
        public List<CompanyScore> Scores { get; }
        public double TotalScore { get; set; }
    }
}