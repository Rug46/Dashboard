using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dashboard.Models;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class Import
    {
        public static string GetFileContents(IFormFile file)
        {
            using (var reader = new StreamReader(file.OpenReadStream(), new UTF8Encoding(encoderShouldEmitUTF8Identifier: false, throwOnInvalidBytes: true), detectEncodingFromByteOrderMarks: true))
            {
                var fileContents = reader.ReadToEnd();

                if (fileContents.Length > 0)
                {
                    return fileContents;
                }
                else
                {
                    return "Error";
                }
            }
        }

        public static string GetFileType(IFormFile file)
        {
            return file.ContentType;
        }

        public static bool IsFileType(IFormFile file, string fileExtension)
        {
            if (fileExtension == "xml")
            {
                if (GetFileType(file) == "text/xml")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else if (fileExtension == "csv")
            {
                if (GetFileType(file) == "application/vnd.ms-excel")
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }

            return false;
        }

        public static List<ImportModel> ImportCSV(IFormFile file)
        {
            var fileContents = GetFileContents(file);
            List<string> lines = fileContents.Split('\n').ToList();
            var list = new List<ImportModel>();

            lines.RemoveAt(0);
            lines.Reverse();
            lines.RemoveAt(0);
            lines.Reverse();

            foreach (var line in lines)
            {
                List<string> parts = line.Split(",").ToList();

                var model = new ImportModel
                {
                    Date = DateTime.Parse(parts.ElementAt(0)),
                    Game = parts.ElementAt(1),
                    Finish = DateTime.Parse(parts.ElementAt(2)),
                    Mode = parts.ElementAt(3)
                };

                list.Add(model);
            }

            return list;
        }

        public static void CSVDatabase(List<ImportModel> imports, string username)
        {
            using (var db = new Database())
            {
                foreach (var import in imports)
                {
                    var model = new ActivityModel
                    {
                        Date = import.Date,
                        Game = import.Game,
                        Finish = import.Finish,
                        Mode = import.Mode,
                        UserId = Account.GetUserId(username)
                    };

                    db.Activity.Add(model);
                }

                db.SaveChanges();
            }
        }
    }
}
