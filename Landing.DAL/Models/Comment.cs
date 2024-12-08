using Landing.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public  class Comment
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Content { get; set; }
        public DateTime DatePosted { get; set; }

        // العلاقة مع التعليق الأب (لإنشاء الردود)
        public int? ParentCommentId { get; set; }
        public Comment? ParentComment { get; set; }
        public ICollection<Comment>? Replies { get; set; }

        public int? PProfileId { get; set; }
        public PProfile? Profile { get; set; }

    }
}
