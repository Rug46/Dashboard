using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dashboard.Data;
using Dashboard.Models;

namespace Dashboard.Helpers
{
    public class SecurityQuestion
    {
        public static List<SecurityQuestionModel> GetQuestions()
        {
            using (var db = new Database())
            {
                var records = db.SecurityQuestions
                    .OrderBy(sqm => sqm.Question)
                    .ToList();

                return records;
            }
        }

        public static string GetQuestionFromId(int id)
        {
            using (var db = new Database())
            {
                var records = db.SecurityQuestions
                    .Where(sqm => sqm.Id == id)
                    .ToList();

                if (records.Count == 0)
                {
                    return null;
                }

                return records.ElementAt(0).Question;
            }
        }

        public static string GetUserSecurityQuestion(int userid, int questionNum)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(um => um.Id == userid)
                    .ToList();

                if (records.Count == 0)
                {
                    return null;
                }

                if (questionNum == 1)
                {
                    return GetQuestionFromId(records.ElementAt(0).Question1);
                }
                else if (questionNum == 2)
                {
                    return GetQuestionFromId(records.ElementAt(0).Question2);
                }
                else if (questionNum == 3)
                {
                    return GetQuestionFromId(records.ElementAt(0).Question3);
                }
                else
                {
                    return null;
                }
            }
        }

        public static bool UsernameEmailMatch(string username, string email)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(um => um.Username == username)
                    .Where(um => um.Email == email)
                    .ToList();

                if (records.Count() != 1)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }
    }
}
