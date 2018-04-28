using System.Collections.Generic;
using kyciti.Engine;

namespace kyciti.Models
{
    public class PersonScore
    {
        public string Category { get; set; }
        public bool Passed { get; set; }
        public List<SearchEngineResult> Sources { get; set; }
    }
}