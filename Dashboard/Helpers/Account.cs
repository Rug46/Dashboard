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

        public static bool RegisterChild(string username, string password, string email, int parentAccountId)
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
                    Admin = 0,
                    ParentAccountId = parentAccountId
                };

                db.Users.Add(user);
                db.SaveChanges();

                return true;
            }
        }

        public static int GetUserId(string username)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(um => um.Username == username)
                    .ToList();

                if (records.Count != 1)
                {
                    return -1;
                }

                return records.ElementAt(0).Id;
            }
        }

        public static bool IsParent(int UserId)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(um => um.Id == UserId)
                    .OrderBy(um => um.Id)
                    .ToList();

                if (records.ElementAt(0).Admin == 0)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public static string GetEmail(int UserId)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(um => um.Id == UserId)
                    .OrderBy(um => um.Id)
                    .ToList();

                return records.ElementAt(0).Email;
            }
        }
    }
}
