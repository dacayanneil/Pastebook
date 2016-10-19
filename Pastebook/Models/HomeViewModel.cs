using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastebook
{
    public class HomeViewModel
    {
        public UserModel CurrentUser { get; set; }
        public IEnumerable<PostModel> PostList { get; set; }
    }
}