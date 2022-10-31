using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFStart.Models
{
    internal class Blog
    {
        public int BlogId { get; set; }

        public string Url { get; set; }
        public DateTime CraetedDate { get; set; }

        public List<Post> Posts { get; } = new List<Post>();
    }
}
