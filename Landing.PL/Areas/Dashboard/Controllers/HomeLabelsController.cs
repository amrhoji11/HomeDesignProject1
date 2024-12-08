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
    public class HomeLabelsController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;

        public HomeLabelsController(IMapper Mapper, ApplecationDbContext Context)
        {
            this.Mapper = Mapper;
            context = Context;
        }
        public IActionResult Index()
        {
            var Label = context.HomeLabels.ToList();
            var Vm = Mapper.Map<IEnumerable<HLebelVM>>(Label);

            return View(Vm);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(HLebelFromVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            

                model.ImageName = FileSetting.UploadFile(model.Image, "images");
            
           
            var label = Mapper.Map<HomeLabel>(model);
           
            context.Add(label);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            var model=context.HomeLabels.Find(id);
            if (model is null)
            {
                return NotFound();
            }
            var VM = Mapper.Map<HLebelDetails>(model);
            return View(VM);
        }

        [HttpPost]
      // [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirm(int id)
        {
            var label = context.HomeLabels.Find(id);
            if (label is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSetting.DeleteFile(label.ImageName, "images");


            context.HomeLabels.Remove(label);
            context.SaveChanges();
            return Ok(new { message = "Service Deleted" });
        }


        public IActionResult Edit(int id)
        {
            var label = context.HomeLabels.Find(id);
            if (label is null)
            {
                return NotFound();
            }
           var vm =  Mapper.Map<HLebelFromVM>(label);
            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(HLebelFromVM ViewModel)
        {
            var label = context.HomeLabels.Find(ViewModel.Id);
            if (!ModelState.IsValid)
            {
                return View(ViewModel);

            }
            var c = ViewModel.ImageName;
            if (ViewModel.Image !=null)
            {
                FileSetting.DeleteFile(label.ImageName, "images");
                ViewModel.ImageName = FileSetting.UploadFile(ViewModel.Image, "images");

            }
            else
            {
                 ViewModel.ImageName= label.ImageName;

            }
           

            if (label is null)
            {
                return NotFound();

            }
            
          Mapper.Map(ViewModel,label);
            context.SaveChanges();
            
                return RedirectToAction(nameof(Index));
        }

    }
}
