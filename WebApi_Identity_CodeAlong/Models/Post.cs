﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi_Identity_CodeAlong.Models
{
    public class Post
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public virtual ApplicationUser Author { get; set; }
    }
}