using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class Feedback
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Job { get; set; }
        public string Content { get; set; }

        // المفتاح الأجنبي
        public int? PProfileId { get; set; }
        public PProfile? Profile { get; set; }


    }
}
