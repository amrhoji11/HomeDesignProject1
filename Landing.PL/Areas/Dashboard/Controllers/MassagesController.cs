using AutoMapper;
using Landing.DAL.Data;
using Landing.PL.Areas.Dashboard.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("Dashboard")]
    public class MassagesController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;

        public MassagesController(IMapper Mapper, ApplecationDbContext Context)
        {
            this.Mapper = Mapper;
            context = Context;
        }
        public IActionResult Index()
        {
            var massages = context.massages.Include(a => a.Profile).ToList();
            var vm = Mapper.Map<IEnumerable<MassageVM>>(massages);

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var massages = context.massages.Include(a => a.Profile).FirstOrDefault(a => a.Id == id);
            if (massages == null)
            {
                return NotFound();
            }
            var vm = Mapper.Map<MassageDetails>(massages);



            return View(vm);
        }

        public IActionResult DeleteConfirm(int id)
        {
            var massages = context.massages.Find(id);
            if (massages is null)
            {
                return RedirectToAction(nameof(Index));
            }



            context.massages.Remove(massages);
            context.SaveChanges();
            return Ok(new { message = "Massage Deleted" });
        }
    }
}
