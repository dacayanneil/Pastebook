using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PastebookEFModel;

namespace PastebookUILayer
{
    public class UserFriendModel
    {
        public PB_USER User { get; set; }
        public List<PB_FRIEND> Friends { get; set; }
    }
}