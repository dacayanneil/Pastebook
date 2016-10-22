using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using PastebookEFModel;
using PastebookDataAccessLayer;

namespace PastebookBusinessLogicLayer
{
        public class UserBusinessLogic
        {

            public int Register(PB_USER user)
            {
                var dataAccess = new GenericDataAccess<PB_USER>();
                var passwordManager = new PasswordManager();

                string salt = null;
                user.PASSWORD = passwordManager.GeneratePasswordHash(user.PASSWORD, out salt);
                user.SALT = salt;
                user.DATE_CREATED = DateTime.Now;
                var status = dataAccess.Create(user);
                return status;
            }

            public int Login(PB_USER user)
            {
                var passwordManager = new PasswordManager();
                var dataAccess = new GenericDataAccess<PB_USER>();

                int status = 0;
                var userList = dataAccess.Retrieve();
                var getuser = userList.Where(x => x.EMAIL_ADDRESS == user.EMAIL_ADDRESS).SingleOrDefault();
                if(getuser != null)
                {
                if (passwordManager.IsPasswordMatch(user.PASSWORD, getuser.SALT, getuser.PASSWORD))
                    status = 1;
                }
                return status;
            }

            public int GetUserIDbyEmail(string email)
            {
                var dataAccess = new GenericDataAccess<PB_USER>();
                int id;
                    try
                    {
                        var user = dataAccess.Retrieve().Where(x => x.EMAIL_ADDRESS == email).SingleOrDefault();
                        id = user.ID;
                    }
                    catch (Exception e)
                    {
                        throw;
                    }
                return id;
            }
        }

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

