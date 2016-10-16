using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Manager
{
    class PasswordManager
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
}
