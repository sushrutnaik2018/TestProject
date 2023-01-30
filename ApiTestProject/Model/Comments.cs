using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiTestProject
{
    /// <summary>
    /// Model for Comments Post test
    /// </summary>
    public class Comments
    {
        public long postId { get; set; }

        public long id { get; set; }

        public string name { get; set; }

        public string email { get; set; }

        public string body { get; set; }
    }
}
