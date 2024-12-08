using Landing.DAL.Data;
using Landing.DAL.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Controllers
{
    public class FeedbackesController : Controller
    {
        private readonly ApplecationDbContext context;
        private readonly UserManager<ApplecationUser> userManager;

        public FeedbackesController(ApplecationDbContext context, UserManager<ApplecationUser> userManager)
        {
            this.context = context;
            this.userManager = userManager;
        }
        // Action لعرض نموذج إضافة الفيدباك
        public async Task<IActionResult> Index()
        {
            var user = await userManager.GetUserAsync(User);

            if (user == null)
            {
                return RedirectToAction("Login", "Account"); // إعادة التوجيه إذا لم يكن هناك مستخدم
            }

            // تحميل الملف الشخصي للمستخدم
            var profile = await context.profiles.Include(a=>a.Feedbacks)
                                       .FirstOrDefaultAsync(p => p.ApplecationUserId == user.Id);

            if (profile == null)
            {
                return RedirectToAction("Login", "Account"); // توجيه لإنشاء ملف شخصي إذا لم يكن موجودًا
            }

            // إنشاء نموذج الفيدباك وربطه بالملف الشخصي
            var feedback = new Feedback
            {
                PProfileId = profile.Id,
               
                     
            };
            

            return View(feedback); 
        }


        // حفظ الفيدباك في قاعدة البيانات
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task< IActionResult> AddFeedback(Feedback feedback)
        {
            if (feedback.Name==null || feedback.Job==null || feedback.Content==null)
            {
                return RedirectToAction(nameof(Index));
            }
                 context.feedbacks.Add(feedback);
                await context.SaveChangesAsync();

                return RedirectToAction("Index", "Home"); 
            
            

            
            
        }




    }
}
