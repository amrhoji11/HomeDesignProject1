using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Landing.PL.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles ="Admin,SuperAdmin")]
    [Area("Dashboard")]
    public class InformationsController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;

        public InformationsController(IMapper Mapper, ApplecationDbContext Context)
        {
            this.Mapper = Mapper;
            context = Context;
        }
        public IActionResult Index()
        {
            var info = context.Informations.ToList();
            var Vm = Mapper.Map<IEnumerable<InfoVM>>(info);

            return View(Vm);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(InfoVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            

              
            
           
            var info = Mapper.Map<Information>(model);
           
            context.Add(info);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            var model=context.Informations.Find(id);
            if (model is null)
            {
                return NotFound();
            }
            var VM = Mapper.Map<InfoVM>(model);
            return View(VM);
        }

        [HttpPost]
      // [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var info = context.Informations.Find(id);
            if (info is null)
            {
                return RedirectToAction(nameof(Index));
            }
           


            context.Informations.Remove(info);
            context.SaveChanges();
            return Ok(new { message = "Information Deleted" });
        }


        public IActionResult Edit(int id)
        {
            var info = context.Informations.Find(id);
            if (info is null)
            {
                return NotFound();
            }
           var vm =  Mapper.Map<InfoVM>(info);
            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(InfoVM ViewModel)
        {
            var info = context.Informations.Find(ViewModel.Id);
            if (!ModelState.IsValid)
            {
                return View(ViewModel);

            }
 

            if (info is null)
            {
                return NotFound();

            }
            
          Mapper.Map(ViewModel,info);
            context.SaveChanges();
            
                return RedirectToAction(nameof(Index));
        }

    }
}
