using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Landing.DAL.Models
{
    public  class Social
    {
        public int Id { get; set; }
        public string SocialName { get; set; }
        public string Url { get; set; }
        public bool IsOwner { get; set; }

        // المفتاح الأجنبي
        public string? ApplecationUserId { get; set; }
        public ApplecationUser? ApplecationUser { get; set; }



        // خاصية لتحديد ما إذا كان هذا الحساب هو حسابك الشخصي

    }
}
