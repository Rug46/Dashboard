using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class UserBudgetModel
    {
        public int id { get; set; }
        public int Daily { get; set; }
        public int Monthly { get; set; }
        public int UserId { get; set; }
    }
}
