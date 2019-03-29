using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Helpers
{
    public class Account
    {
        public static bool RegisterParent(string username, string password, string email)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(u => u.Username == username)
                    .ToList();

                if (records.Count != 0)
                {
                    return false;
                }

                if (username == "" || username == null)
                {
                    return false;
                }

                if (password == null || password.Length < 6)
                {
                    return false;
                }

                UserModel user = new UserModel
                {
                    Username = username,
                    Password = Passwords.Hash(password),
                    Email = email,
                    Admin = 1
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
        }
    }
}
