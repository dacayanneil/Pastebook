using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastebook
{
    public class UserListModel
    {
        public UserModel User { get; set; }
        public IEnumerable<UserModel> UserList { get; set; }
    }
}