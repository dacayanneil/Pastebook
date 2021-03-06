﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastebook
{
    public class UserModel
    {
        public int ID { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
        public string Salt { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime BirthDay { get; set; }
        public int CountryID { get; set; }
        public string MobileNo { get; set; }
        public string Gender { get; set; }
        public byte[] ProfilePic { get; set; }
        public DateTime DateCreated { get; set; }
        public string AboutMe { get; set; }
        public string EmailAddress { get; set; }
    }
}