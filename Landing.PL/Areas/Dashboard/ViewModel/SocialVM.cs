using Landing.DAL.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Landing.PL.Areas.Dashboard.ViewModel
{
    public class SocialVM
    {
        public int Id { get; set; }
        public string SocialName { get; set; }
        public string Url { get; set; }
        public bool IsOwner { get; set; }
        public string? ApplecationUserId { get; set; }
        public ApplecationUser? ApplecationUser { get; set; }

        
    }
}
