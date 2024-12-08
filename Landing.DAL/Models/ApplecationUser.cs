using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public class ApplecationUser : IdentityUser
    {
        public string? FullName { get; set; }
        public string? Address { get; set; }

        // العلاقة مع ملف التعريف (PProfile)
        public PProfile? Profile { get; set; }

        // العلاقة مع الجداول الاجتماعية
       


    }
}
