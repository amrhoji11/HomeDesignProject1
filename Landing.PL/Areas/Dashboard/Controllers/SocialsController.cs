using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Landing.PL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles ="Admin,SuperAdmin")]
    [Area("Dashboard")]
    public class SocialsController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;

        public SocialsController(IMapper Mapper, ApplecationDbContext Context)
        {
            this.Mapper = Mapper;
            context = Context;
        }
        public IActionResult Index()
        {
            var socials = context.socials.Include(s => s.ApplecationUser).ToList();
            var vm = Mapper.Map<IEnumerable<SocialVM>>(socials);
            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var user = context.Users.ToList();
           ViewBag.User = new SelectList(user,"Id","UserName");
            // إحضار الفرق لعرضها في القائمة المنسدلة
           
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(SocialVM model)
        {
            if (!ModelState.IsValid)
            {
                // إعادة تحميل قائمة OutTeams إذا كانت هناك مشكلة في التحقق من الصحة
                var user = context.Users.ToList();
                ViewBag.User = new SelectList(user, "Id", "UserName");
                return View(model);
            }

            var social = Mapper.Map<Social>(model);
            context.Add(social);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            var model = context.socials.Include(a => a.ApplecationUser).FirstOrDefault(a => a.Id == id);
            if (model is null)
            {
                return NotFound();
            }
            var VM = Mapper.Map<SocialVM>(model);
            return View(VM);
        }
        [HttpPost]
        // [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var social = context.socials.Find(id);
            if (social is null)
            {
                return RedirectToAction(nameof(Index));
            }



            context.socials.Remove(social);
            context.SaveChanges();
            return Ok(new { message = "Social Deleted" });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var social = context.socials.Include(a=>a.ApplecationUser).FirstOrDefault(a=>a.Id==id);
            if (social is null)
            {
                return NotFound();
            }

            var vm = Mapper.Map<SocialVM>(social);
            var user = context.Users.ToList();
            ViewBag.User = new SelectList(user, "Id", "UserName");
            return View(vm);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(SocialVM ViewModel)
        {
            if (!ModelState.IsValid)
            {
                var user = context.Users.ToList();
                ViewBag.User = new SelectList(user, "Id", "UserName");
                return View(ViewModel);
            }

            var social = context.socials.Include(a=>a.ApplecationUser).FirstOrDefault(a=>a.Id==ViewModel.Id);
            if (social is null)
            {
                return NotFound();
            }

            Mapper.Map(ViewModel, social);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

    }
}
