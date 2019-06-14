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
    }
}
