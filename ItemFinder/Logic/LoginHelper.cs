using System;
using System.Security.Cryptography;

namespace ItemFinderClassLibrary.Logic
{
    public class LoginHelper
    {
        public static byte[] GenerateSalt()
        {
            //create an array of bytes
            byte[] bSalt = new byte[24];

            //use salt generator to generate array of bytes
            RNGCryptoServiceProvider saltGenerator = new RNGCryptoServiceProvider();
            saltGenerator.GetBytes(bSalt);

            //return the randomly created byte array
            return bSalt;
        }

        public static string GeneratePasswordHash(string plainText, byte[] salt, int iterations)
        {

            byte[] encryptedPassBytes = null;

            using (Rfc2898DeriveBytes hashGenerator = new Rfc2898DeriveBytes(plainText, salt, iterations,
                HashAlgorithmName.SHA256))
            {
                encryptedPassBytes = hashGenerator.GetBytes(24);
            }

            return "" + iterations + "|" + Convert.ToBase64String(salt) + "|" + Convert.ToBase64String(encryptedPassBytes);
        }

        public static bool IsUserAuthentic(string name, string password)
        {
            //if(name.Equals("user1") && password.Equals("password1")) //validate against database
            //    return true;
            //if(name.Equals("admin1") && password.Equals("password1")) //validate against database
            //    return true;
            //return false;

            UserDao userDao = new UserDao();
            string encPassword = userDao.GetEncPassword(name);

            string[] parts = encPassword.Split('|');
            int iterations = int.Parse(parts[0]);
            byte[] bSalt = Convert.FromBase64String(parts[1]);

            string hashPass = GeneratePasswordHash(password, bSalt, iterations);

            if (hashPass == encPassword)
                return true;

            return false;

        }

        public static string GetUserRole(string name)
        {
            if (name.Equals("user1")) //read from database
                return "user";
            if (name.Equals("admin1")) //read from database
                return "admin";
            return "";
        }
    }
}
