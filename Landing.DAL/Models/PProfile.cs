using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public  class PProfile
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Bio { get; set; }
        public string? ProfilePictureUrl { get; set; }

        // المفتاح الأجنبي لربط هذا الملف مع المستخدم
        public string? ApplecationUserId { get; set; }
        
        public ApplecationUser? ApplecationUser { get; set; }
        public ICollection<Social>? Socials { get; set; }
        public ICollection<Feedback>? Feedbacks { get; set; }
        public ICollection<Comment>? Comments { get; set; }
        public ICollection<Massage>? Massages { get; set; }

    }
}
