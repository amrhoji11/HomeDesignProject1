using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Helpers;
using Landing.PL.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Controllers
{
    public class PProfilesController : Controller
    {
        private readonly ApplecationDbContext context;
        private readonly IMapper mapper;
        private readonly UserManager<ApplecationUser> userManager;
        private readonly SignInManager<ApplecationUser> signInManager;

        public PProfilesController(ApplecationDbContext Context, IMapper mapper, UserManager<ApplecationUser> userManager, SignInManager<ApplecationUser> signInManager)
        {
            context = Context;
            this.mapper = mapper;
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        // عرض الملف الشخصي
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var profile = await context.profiles.FirstOrDefaultAsync(p => p.ApplecationUserId == user.Id);
            if (profile == null)
            {
                profile = new PProfile { Name = user.UserName, ApplecationUserId = user.Id };
                context.profiles.Add(profile);
                await context.SaveChangesAsync();
            }

            var profileVM = mapper.Map<ProfileVM>(profile);
            return View(profileVM);
        }

        // تعديل الاسم
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditName(string name)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var profile = await context.profiles.FirstOrDefaultAsync(p => p.ApplecationUserId == user.Id);
            if (profile == null)
            {
                return NotFound();
            }

            // تعديل الاسم
            profile.Name = name;
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // تعديل الـ Bio
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditBio(string bio)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var profile = await context.profiles.FirstOrDefaultAsync(p => p.ApplecationUserId == user.Id);
            if (profile == null)
            {
                return NotFound();
            }

            // تعديل الـ Bio
            profile.Bio = bio;
            await context.SaveChangesAsync();

            return RedirectToAction("Index");
        }

        // تعديل الصورة
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditProfilePicture(IFormFile ProfilePicture)
{
    var user = await userManager.GetUserAsync(User);
    if (user == null)
        return RedirectToAction("Login", "Account");

    var profile = await context.profiles.FirstOrDefaultAsync(p => p.ApplecationUserId == user.Id);
    if (profile == null)
    {
        return NotFound();
    }

    // إذا تم رفع صورة جديدة
    if (ProfilePicture != null && ProfilePicture.Length > 0)
    {
                if (profile.ProfilePictureUrl != null ) {
                    FileProfileSetting.DeleteFile(profile.ProfilePictureUrl, "images");

                }
                profile.ProfilePictureUrl = FileProfileSetting.UploadFile(ProfilePicture,"images");
                await context.SaveChangesAsync();
    }
           


    return RedirectToAction("Index");
}
        // تعديل الوصف (Description)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditDescription(string description)
        {
            var user = await userManager.GetUserAsync(User);
            if (user == null)
                return RedirectToAction("Login", "Account");

            var profile = await context.profiles.FirstOrDefaultAsync(p => p.ApplecationUserId == user.Id);
            if (profile == null)
            {
                return NotFound();
            }

            // التحقق من أن الـ description ليس null أو فارغ
            if (string.IsNullOrEmpty(description))
            {
                TempData["Error"] = "Description cannot be empty.";
                return RedirectToAction("Index");
            }

            // تعديل الـ Description
            profile.Description = description;
            await context.SaveChangesAsync();

            TempData["Success"] = "Description updated successfully.";
            return RedirectToAction("Index");
        }


    }
}
