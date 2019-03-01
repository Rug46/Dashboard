using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class BacklogModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string System { get; set; }
        public int Status { get; set; }
        public string Progress { get; set; }
        public int NowPlaying { get; set; }
    }
}
