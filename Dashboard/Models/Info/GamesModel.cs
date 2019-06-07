using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models.Info
{
    public class GamesModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Metacritic { get; set; }
        public string IGN { get; set; }
        public string Trailer { get; set; }
        public string Speedruns { get; set; }
    }
}
