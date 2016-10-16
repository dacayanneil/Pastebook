using EntityModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class UserManager
    {

        public int AddUser(UserEntity inputUser)
        {
            int status = 0;
            
            try
            {
                using (var context = new PASTEBOOK_NJDDEntities())
                {
                    var newUser = new PB_USER();
                    newUser.ID = inputUser.ID;
                    newUser.USER_NAME = inputUser.Username;
                    newUser.PASSWORD = inputUser.Password;
                    newUser.SALT = inputUser.Salt;
                    newUser.FIRST_NAME = inputUser.FirstName;
                    newUser.LAST_NAME = inputUser.LastName;
                    newUser.BIRTHDAY = inputUser.BirthDay;
                    newUser.COUNTRY_ID = inputUser.CountryID;
                    newUser.MOBILE_NO = inputUser.MobileNo;
                    newUser.GENDER = inputUser.Gender;
                    newUser.PROFILE_PIC = inputUser.ProfilePic;
                    newUser.DATE_CREATED = inputUser.DateCreated;
                    newUser.ABOUT_ME = inputUser.AboutMe;
                    newUser.EMAIL_ADDRESS = inputUser.EmailAddress;
                    context.PB_USER.Add(newUser);
                }
            }
            catch(ArgumentException ex)
            {

            }
            return status;
        }

        public List<UserEntity> RetrieveUser()
        {
            List<UserEntity> userList = new List<UserEntity>();
            try
            {
                using (var context = new PASTEBOOK_NJDDEntities())
                {
                    var result = context.PB_USER.ToList();
                    foreach (var item in result)
                    {
                        userList.Add(new UserEntity
                        {
                            ID = item.ID
                        });
                    }
                }    
            }
            catch(ArgumentException ex)
            {

            }
            return userList;
        }
    }
}
