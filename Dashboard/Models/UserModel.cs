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
        public int Question1 { get; set; }
        public string Answer1 { get; set; }
        public int Question2 { get; set; }
        public string Answer2 { get; set; }
        public int Question3 { get; set; }
        public string Answer3 { get; set; }
    }
}
