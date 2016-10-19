﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PastebookBL
{
    public class PostEntity
    {
        public int ID { get; set; }
        public DateTime CreatedDate { get; set; }
        public string Content { get; set; }
        public int Profile_Owner_ID { get; set; }
        public int Poster_ID { get; set; }
    }
}
