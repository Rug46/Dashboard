using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class MetacriticModel
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate { get; set; }
        public string Platform { get; set; }
        public string Metascore { get; set; }
        public string Critics { get; set; }
        public string Summary { get; set; }
        public string Developers { get; set; }
        public string Genre { get; set; }

        public bool ExactMatch { get; set; }
    }
}
