using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebookBL
{
    public class FriendEntity
    {
        public int ID { get; set; }
        public int User_ID { get; set; }
        public int Friend_ID { get; set; }
        public string Request { get; set; }
        public string Blocked { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
