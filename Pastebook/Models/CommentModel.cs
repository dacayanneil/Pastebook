using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Pastebook
{
    public class CommentModel
    {
        public int ID { get; set; }
        public int Post_ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int Poster_ID { get; set; }
        public UserModel User { get; set; }
    }
}