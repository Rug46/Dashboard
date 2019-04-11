using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Dashboard.Data;

namespace Dashboard.Helpers
{
    public class Passwords
    {
        public static string Hash(string password)
        {
            byte[] salt = new byte[128 / 8];

            using (var rng = RandomNumberGenerator.Create())
            {
                //rng.GetBytes(salt);
            }

            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
                password,
                salt,
                prf: KeyDerivationPrf.HMACSHA1,
                iterationCount: 10000,
                numBytesRequested: 256 / 8));

            return hashed;
        }

        public static bool PasswordCorrect(string username, string password)
        {
            using (var db = new Database())
            {
                var records = db.Users
                    .Where(u => u.Username == username)
                    .ToList();

                if (records.Count != 1)
                {
                    return false;
                }

                var DBPassword = records.ElementAt(0).Password;
                var InPassword = Hash(password);

                if (DBPassword == InPassword)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
