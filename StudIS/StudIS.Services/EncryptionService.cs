using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StudIS.Services
{
    public static class EncryptionService
    {
        public static String EncryptSHA1(String password)
        {
            String encryptedString;
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                var hash = sha1.ComputeHash(Encoding.UTF8.GetBytes(password));

                 encryptedString= Convert.ToBase64String(hash);

            }
            return encryptedString;
           
            
        }
    }
}
