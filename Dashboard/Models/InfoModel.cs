using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class InfoModel
    {
        public string Title { get; set; }
        public string Publisher { get; set; }
        public string ReleaseDate {get;set;}
        public string Platform { get; set; }
        public string Metascore { get; set; }
        public string Critics { get; set; }
        public string BoxArt { get; set; }
        public string Summary { get; set; }
        public string UserScore { get; set; }
        public string Users { get; set; }
        public string Developers { get; set; }
        public List<string> Genre { get; set; }
        public string Players { get; set; }

        public string Error { get; set; }
    }
}
