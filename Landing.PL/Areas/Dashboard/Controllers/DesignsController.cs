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
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("Dashboard")]
    public class DesignsController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;

        public DesignsController(IMapper Mapper, ApplecationDbContext Context)
        {
            this.Mapper = Mapper;
            context = Context;
        }
        public IActionResult Index()
        {
            var design = context.Designs.Include(a=>a.Flaticon).ToList();
            var Vm = Mapper.Map<IEnumerable<DesignVM>>(design);

            return View(Vm);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            var flaticon = context.flaticons.ToList();
            var vm = new DesignsFromVM
            {
                FlaticonList = new SelectList(flaticon, "Id", "Name")
            };

            return View(vm);
            
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(DesignsFromVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }





            var design = new Design
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                IsDeleted = model.IsDeleted,
                FlaticonId = model.SelectedFlaticonId
            };


            context.Add(design);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            var model=context.Designs.Include(a=>a.Flaticon).FirstOrDefault(a=>a.Id==id);
            if (model is null)
            {
                return NotFound();
            }
            var VM = Mapper.Map<DesignDetails>(model);
            return View(VM);
        }
       
        [HttpPost]
        
        public IActionResult DeleteConfirm(int id)
        {
            var design = context.Designs.Find(id);
            if (design is null)
            {
                return RedirectToAction(nameof(Index));
            }
           


            context.Designs.Remove(design);
            context.SaveChanges();
            return Ok(new { message = "Service Deleted" });
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
            var design = context.Designs.Include(a=>a.Flaticon).FirstOrDefault(a=>a.Id==id);
            if (design is null)
            {
                return NotFound();
            }
            var vm = new DesignsFromVM
            {
                Id = id,
                Name = design.Name,
                IsDeleted = design.IsDeleted,
                SelectedFlaticonId = design.FlaticonId,
                Description = design.Description,
                


            };

            var flaticon = context.flaticons.ToList();
            vm.FlaticonList = new SelectList(flaticon, "Id", "Name");

            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(DesignsFromVM ViewModel)
        {
            var design = context.Designs.Find(ViewModel.Id);
            if (!ModelState.IsValid)
            {
                var flaticon = context.flaticons.ToList();
                ViewModel.FlaticonList = new SelectList(flaticon, "Id", "Name"); // إعادة تحميل الفلاتيكون
                return View(ViewModel);
               

            }
            
         
          

            if (design is null)
            {
                return NotFound();

            }

             
            design.Name= ViewModel.Name;
            design.Description= ViewModel.Description;
            design.FlaticonId = ViewModel.SelectedFlaticonId;
            design.IsDeleted= ViewModel.IsDeleted;
           

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }

    }
}
