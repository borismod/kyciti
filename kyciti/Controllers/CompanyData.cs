using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace kyciti.Controllers {
    public enum RiskValuations {
        Low = 1, Medium, High
    }

    public class Person {
        public string Name { get; set; }
        public string Title { get; set; }
        public RiskValuations RiskValuation { get; set; }
        public Dictionary<string, List<string>> ArticleLinks { get; set; }
    }

    public class CompanyData {

        public static CompanyData GetMockData(string id, bool addValuation) {
            if (id.ToLower() == "bezeq") {
                var shaulLinks = new Dictionary<string, List<string>>() {
                { "Shaul Elovitch Chairman bribe", new List<string> { "https://www.timesofisrael.com/bezeq-controlling-shareholder-elovitch-to-resign-from-board-amid-probe/", "https://www.timesofisrael.com/top-officials-executives-revealed-as-suspects-in-bezeq-graft-investigation/" } },

            { "Shaul Elovitch Chairman money laundry", new List<string> { "https://www.reuters.com/article/bezeq-chairman-investigation/bezeq-telecoms-acting-chairman-detained-in-bribery-probe-police-idUSL8N1L02XO", "https://www.haaretz.com/israel-news/acting-bezeq-chairman-held-in-steinmetz-affair-1.5442738" } }
            };
                
                var person1 = new Person() { Name = "Shaul Elovitch", Title = "Chairman"};
                var person2 = new Person() { Name = "Stella Handler", Title = "Chief Executive Officer"};
                var person3 = new Person() { Name = "David Granot", Title = "Temporary Acting Chairman"};
                if (addValuation) {
                    person1.ArticleLinks = shaulLinks;
                    person1.RiskValuation = RiskValuations.High;
                    person2.RiskValuation = RiskValuations.Medium;
                    person3.RiskValuation = RiskValuations.Low;
                }
                return new CompanyData() { Name = id, Members = new List<Person>() { person1, person2, person3 } };
            }
            else {
                var person1 = new Person() { Name = "Michael Corbat", Title = "CEO", };
                var person2 = new Person() { Name = "Don Callahan", Title = "Head of operation"};
                var person3 = new Person() { Name = "Stuart Riley", Title = "Head of Markets"};
                if (addValuation) {
                    person1.RiskValuation = RiskValuations.Low;
                    person2.RiskValuation = RiskValuations.Low;
                    person3.RiskValuation = RiskValuations.Low;
                }
                return new CompanyData() { Name = id, Members = new List<Person>() { person1, person2, person3 } };
            }

        }

        public string Name { get; set; }
        public RiskValuations RiskValuation { get; set; }
        public List<Person> Members { get; set; }
    }
}