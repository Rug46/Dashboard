using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;
using System.Text;

namespace Dashboard.Helpers
{
    public class Account
    {
        public static bool RegisterParent(string username, string password, string email, int question1, int question2, int question3, string answer1, string answer2, string answer3)
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

                if (question1 == 0 || question2 == 0 || question3 == 0)
                {
                    return false;
                }

                if (answer1 == "" || answer1 == null || answer2 == "" || answer2 == null || answer3 == "" || answer3 == null)
                {
                    return false;
                }

                if (question1 == question2 || question1 == question3 || question2 == question3)
                {
                    return false;
                }

                UserModel user = new UserModel
                {
                    Username = username,
                    Password = Passwords.Hash(password),
                    Email = email,
                    Admin = 1,
                    Question1 = question1,
                    Question2 = question2,
                    Question3 = question3,
                    Answer1 = answer1,
                    Answer2 = answer2,
                    Answer3 = answer3
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

        public static string GetUsername(int userId)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(um => um.Id == userId)
                    .ToList();

                return records.ElementAt(0).Username;
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

        public static bool IsChildOf(int ParentId, int ChildId)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(um => um.Id == ChildId)
                    .OrderBy(um => um.Id)
                    .ToList();

                if (records.Count == 0)
                {
                    return false;
                }

                if (records.ElementAt(0).Admin != 0)
                {
                    return false;
                }

                if (records.ElementAt(0).ParentAccountId != ParentId)
                {
                    return false;
                }

                return true;
            }
        }

        public static string GenerateResetToken(string username, string email, string answer1, string answer2, string answer3)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(um => um.Username == username)
                    .Where(um => um.Email == email)
                    .Where(um => um.Answer1 == answer1)
                    .Where(um => um.Answer2 == answer2)
                    .Where(um => um.Answer3 == answer3)
                    .ToList();

                if (records.Count() != 1)
                {
                    return null;
                }

                Random random = new Random();
                string characters = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz";
                int length = 16;
                StringBuilder result = new StringBuilder(length);
                for (int i = 0; i < length; i++)
                {
                    result.Append(characters[random.Next(characters.Length)]);
                }

                UserResetTokenModel tokenModel = new UserResetTokenModel
                {
                    UserId = GetUserId(username),
                    Token = result.ToString()
                };

                db.UserResetTokens.Add(tokenModel);
                db.SaveChanges();

                return result.ToString();
            }
        }

        public static bool TokenExists(string token)
        {
            using (var db = new Database())
            {
                var records = db.UserResetTokens
                    .Where(tm => tm.Token == token)
                    .ToList();

                if (records.Count() == 1)
                {
                    return true;
                }

                return false;
            }
        }

        public static int GetTokenUserId(string token)
        {
            using (var db = new Database())
            {
                var records = db.UserResetTokens
                    .Where(tm => tm.Token == token)
                    .ToList();

                if (records.Count() != 1)
                {
                    return -1;
                }

                return records.ElementAt(0).UserId;
            }
        }

        public static void ResetPassword(string token, string password)
        {
            using (var db = new Database())
            {
                var tokens = db.UserResetTokens
                    .Where(tm => tm.Token == token)
                    .ToList();

                if (tokens.Count() != 1)
                {
                    return;
                }

                var userid = tokens.ElementAt(0).UserId;

                var users = db.Users
                    .Where(um => um.Id == userid)
                    .ToList();

                if (users.Count() == 0)
                {
                    return;
                }

                if (tokens.ElementAt(0).UserId != userid)
                {
                    return;
                }

                if (password == null || password.Length < 6)
                {
                    return;
                }

                users.ElementAt(0).Password = Passwords.Hash(password);
                db.UserResetTokens.Remove(tokens.ElementAt(0));
                db.SaveChanges();
            }
        }
    }
}
