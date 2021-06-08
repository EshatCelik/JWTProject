using System;
using System.Collections.Generic;
using System.Text;

namespace JWT.Core.Utilities.hashing
{
    public class HashingHelper
    {
        public static void CreatePasswordHash(string password,  byte[] passwordHash,  byte[] passwordSalt)
        {

            using (var hash = new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hash.Key;
                passwordHash = hash.ComputeHash(Encoding.UTF8.GetBytes(password));
            }
        }

        public static bool VerifyPasswordHash(string password, byte[] passwordHash, byte[] passwordSalt)
        {
            using (var verifypass = new System.Security.Cryptography.HMACSHA512(passwordSalt))
            {
                var computeHash = verifypass.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computeHash.Length; i++)
                {
                    if (passwordHash[i] != passwordSalt[i])
                    {
                        return false;
                    }
                }
                return true;
            }

        }
    }
}
