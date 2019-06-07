using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class WishlistModel
    {
        public int Id { get; set; }
        public string GameName { get; set; }
        public string ConsoleName { get; set; }
        public int UserId { get; set; }
        public int Archived { get; set; }
    }
}
