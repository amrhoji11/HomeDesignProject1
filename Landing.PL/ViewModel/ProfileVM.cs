using Landing.DAL.Models;

namespace Landing.PL.ViewModel
{
    public class ProfileVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string? Bio { get; set; }

        public string ProfilePictureUrl { get; set; }
        public IFormFile ProfilePicture { get; set; }
        public string? ApplecationUserId { get; set; }
        public ApplecationUser ApplecationUser { get; set; }
    }
}
