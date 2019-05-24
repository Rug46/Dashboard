using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class ActivityModel
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Game { get; set; }
        public DateTime Finish { get; set; }
        public string Mode { get; set; }
        public int UserId { get; set; }
    }
}
