using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebookBL
{
    public class LikeEntity
    {
        public int ID { get; set; }
        public int Post_ID { get; set; }
        public int Liked_By { get; set; }
    }
}
