﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    /// <summary>
    /// Model for Posts Post test
    /// </summary>
    public class Posts
    {
        public long userId { get; set; }

        public long id { get; set; }

        public string title { get; set; }

        public string body { get; set; }
    }
}
