using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Dashboard.Models
{
    public class UserModel
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public int Admin { get; set; }
        public string Email { get; set; }
        public int ParentAccountId { get; set; }
    }
}
