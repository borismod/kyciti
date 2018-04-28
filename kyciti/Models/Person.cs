using System.Collections.Generic;

namespace kyciti.Models
{
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
}