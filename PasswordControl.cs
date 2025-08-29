using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CEIS400_ECS
{
    public static class PasswordControl
    {
        // Sets our password hash
        public static string HashPassword(string password, out string saltBase64)
        {
            using (var hmac = new HMACSHA512())
            {
                byte[] salt = hmac.Key;
                byte[] hash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                saltBase64 = Convert.ToBase64String(salt);
                return Convert.ToBase64String(hash);
            }
        }

        // Verifies we have the right password by comparing stored hash
        // and salt against input password after it has been converted to hash and salt
        public static bool VerifyPassword(string password, string storedHash, string storedSalt)
        {
            // Decode the Base64 strings back into byte arrays
            byte[] saltBytes = Convert.FromBase64String(storedSalt);
            byte[] storedHashBytes = Convert.FromBase64String(storedHash);

            using (var hmac = new HMACSHA512(saltBytes))
            {
                byte[] computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));

                // Compare byte by byte
                if (computedHash.Length != storedHashBytes.Length) return false;
                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != storedHashBytes[i]) return false;
                }
                return true;
            }
        }
    }
}
