using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Content { get; set; }

        public int? ItemId { get; set; }
        public Item? Item { get; set; }
    }
}
