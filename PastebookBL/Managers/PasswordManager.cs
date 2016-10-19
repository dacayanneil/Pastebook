using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace PastebookBL
{
    public class PasswordManager
    {
        HashComputer m_hashComputer = new HashComputer();

        public string GeneratePasswordHash(string plainTextPassword, out string salt)
        {
            salt = SaltGenerator.GetSaltString();

            string finalString = plainTextPassword + salt;

            var hash = m_hashComputer.GetPasswordHashAndSalt(finalString);

            return hash;
        }

        public bool IsPasswordMatch(string password, string salt, string hash)
        {
            string finalString = password + salt;
            return hash == m_hashComputer.GetPasswordHashAndSalt(finalString);
        }
    }

    class SaltGenerator
    {
        private static RNGCryptoServiceProvider m_cryptoServiceProvider = null;
        private const int SALT_SIZE = 24;

        static SaltGenerator()
        {
            m_cryptoServiceProvider = new RNGCryptoServiceProvider();
        }

        public static string GetSaltString()
        {
            Utility utility = new Utility();
            // Lets create a byte array to store the salt bytes
            byte[] saltBytes = new byte[SALT_SIZE];

            // lets generate the salt in the byte array
            m_cryptoServiceProvider.GetNonZeroBytes(saltBytes);

            // Let us get some string representation for this salt
            string saltString = utility.GetString(saltBytes);

            // Now we have our salt string ready lets return it to the caller
            return saltString;
        }
    }

    class Utility
    {
        public string GetString(byte[] input)
        {
            string output = "";
            output = ASCIIEncoding.ASCII.GetString(input);
            return output;
        }

        public byte[] GetBytes(string input)
        {
            byte[] output;
            output = ASCIIEncoding.ASCII.GetBytes(input);
            return output;
        }
    }

    class HashComputer
    {
        public string GetPasswordHashAndSalt(string message)
        {
            // Let us use SHA256 algorithm to 
            // generate the hash from this salted password
            Utility utility = new Utility();
            SHA256 sha = new SHA256CryptoServiceProvider();
            byte[] dataBytes = utility.GetBytes(message);
            byte[] resultBytes = sha.ComputeHash(dataBytes);

            // return the hash string to the caller
            return utility.GetString(resultBytes);
        }
    }
}
