using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PastebookEFModel;
using System.Data.Entity;

namespace PastebookBL
{
    public class UserBL
    {
        MapperBL mapper = new MapperBL();
        PasswordManager passwordManager = new PasswordManager();

        public bool Checker(int status)
        {
            bool process = false;
            if (status == 1)
            {
                process = true;
            }
            else
            {
                process = false;
            }
            return process;
        }

        public int AddUser(UserEntity inputUser)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    string salt = null;
                    inputUser.Password = passwordManager.GeneratePasswordHash(inputUser.Password, out salt);
                    inputUser.Salt = salt;
                    inputUser.CreatedDate = DateTime.Now;

                    var userMapped = mapper.UserEntityToDb(inputUser);
                    context.PB_USER.Add(userMapped);
                    status = context.SaveChanges();
                }
            }
            catch
            {

            }
            return status;
        }

        public int UpdateUser(UserEntity inputUser)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var userMapped = mapper.UserEntityToDb(inputUser);
                    context.Entry(userMapped).State = EntityState.Modified;
                    status = context.SaveChanges();
                }
            }
            catch
            {

            }
            return status;
        }

        public int DeleteUser(UserEntity inputUser)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var userMapped = mapper.UserEntityToDb(inputUser);
                    context.Entry(userMapped).State = EntityState.Deleted;
                    status = context.SaveChanges();
                }
            }
            catch
            {

            }
            return status;
        }

        public UserEntity RetrieveSpecificUser(int id)
        {
            var user = new UserEntity();
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var result = context.PB_USER.Where(x => x.ID == id).SingleOrDefault();
                    user = mapper.UserDbToEntity(result);
                }
            }
            catch(Exception e)
            {

            }
            return user;
        }

        public List<UserEntity> RetrieveAllUser()
        {
            List<UserEntity> userList = new List<UserEntity>();
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var result = context.PB_USER.ToList();
                    foreach (var item in result)
                    {
                        userList.Add(mapper.UserDbToEntity(item));
                    }
                }
            }
            catch (ArgumentException ex)
            {

            }
            return userList;
        }

        public List<CountryEntity> RetrieveAllCountry()
        {
            List<CountryEntity> countryList = new List<CountryEntity>();
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var result = context.PB_REF_COUNTRY.ToList();
                    foreach (var item in result)
                    {
                        countryList.Add(mapper.CountryDbToEntity(item));
                    }
                }
            }
            catch
            {

            }
            return countryList;
        }

        public int Login(UserEntity inputUser)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var result = context.PB_USER.Where(item => item.USER_NAME == inputUser.Username).SingleOrDefault();
                    if (passwordManager.IsPasswordMatch(inputUser.Password, result.SALT, result.PASSWORD))
                    {
                        status = 1;
                    };
                }
            }
            catch
            {

            }
            return status;
        }

        public int CheckEmailAddress(string email)
        {
            int status = 0;
            try
            {
                using (var context = new PASTEBOOK_Entities())
                {
                    var result = context.PB_USER.Where(item => item.EMAIL_ADDRESS == email).SingleOrDefault();
                    if (result == null)
                    {
                        status = 1;
                    }
                }
            }
            catch
            {

            }
            return status;
        }

    }
}
