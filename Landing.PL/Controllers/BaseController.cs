using Landing.DAL.Data;
using Landing.DAL.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace Landing.PL.Controllers
{ // هذا الController عملته لكي احط فيه ال ViewBag اللي بدي اوديها على ال Layout , وهذا الController يجب ان اورثة للHomeController
    public class BaseController : Controller
    {
        protected readonly ApplecationDbContext _context;

        public BaseController(ApplecationDbContext context)
        {
            _context = context;
        }

        public override void OnActionExecuted(ActionExecutedContext context)
        {
            // الوصول إلى الجداول باستخدام _context
            var informations = _context.Informations.ToList();
            var socials = _context.socials.ToList();

            ViewBag.info = informations;
            ViewBag.social = socials;
            base.OnActionExecuted(context);
        }

       
    }
}
