using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastebook
{
    public class PostModel
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int Profile_Owner_ID { get; set; }
        public int Poster_ID { get; set; }

        public UserModel Poster { get; set; }
        public IEnumerable<CommentModel> CommentList { get; set; }
        public IEnumerable<LikeModel> LikeList { get; set; }  
    }
}