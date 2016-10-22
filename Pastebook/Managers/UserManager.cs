using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastebookBL;

namespace Pastebook
{
    public class UserManager
    {
        UserBL userBL = new UserBL();
        Mapper mapper = new Mapper();

        public int AddUser(UserModel inputUser)
        {
            return userBL.AddUser(mapper.UserModelToEntity(inputUser));
        }

        public int UpdateUser(UserModel inputUser)
        {
            return userBL.UpdateUser(mapper.UserModelToEntity(inputUser));
        }

        public int DeleteUser(UserModel inputUser)
        {
            return userBL.DeleteUser(mapper.UserModelToEntity(inputUser));
        }

        public UserModel RetrieveSpecificUser(int id)
        {
            var user = new UserModel();
            user = mapper.UserEntityToModel(userBL.RetrieveSpecificUser(id));
            return user;
        }

        public UserModel RetrieveSpecificUser(string email)
        {
            var user = new UserModel();
            user = mapper.UserEntityToModel(userBL.RetrieveSpecificUser(email));
            return user;
        }

        public UserListModel RetrieveAllUser()
        {
            var users = userBL.RetrieveAllUser();
            List<UserModel> userList = new List<UserModel>();
            foreach (var item in users)
            {
                userList.Add(mapper.UserEntityToModel(item));
            }
            var userListModel = new UserListModel()
            {
                UserList = userList
            };
            return userListModel;
        }

        public List<CountryModel> RetreiveAllCountry()
        {
            List<CountryModel> countryList = new List<CountryModel>();
            var result = userBL.RetrieveAllCountry();
            foreach (var item in result)
            {
                countryList.Add(mapper.CountryEntityToModel(item));
            }
            return countryList;
        }

        public int Login(UserModel inputUser)
        {
            return userBL.Login(mapper.UserModelToEntity(inputUser));
        }

        public int CheckEmailAddress(string email)
        {
            return userBL.CheckEmailAddress(email);
        }

    }
}