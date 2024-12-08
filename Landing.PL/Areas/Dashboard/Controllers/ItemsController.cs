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
    public class ItemsController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;

        public ItemsController(IMapper Mapper, ApplecationDbContext Context)
        {
            this.Mapper = Mapper;
            context = Context;
        }
        public IActionResult Index()
        {
            var item = context.Items.ToList();
            var Vm = Mapper.Map<IEnumerable<ItemVM>>(item);

            return View(Vm);
        }
        [HttpGet]
        public IActionResult Create() 
        {
            var design = context.Designs.ToList();
            var vm = new ItemFromVM
            {
                Design = new SelectList(design, "Id", "Name")
            };

            return View(vm);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ItemFromVM model)
        {
            if (!ModelState.IsValid)
            {
                var design = context.Designs.ToList();
                model.Design = new SelectList(design, "Id", "Name"); // إعادة تحميل الفلاتيكون
                return View(model);
            }
            

                model.ImageName = FileSetting.UploadFile(model.Image, "images");
            
           
            var item = Mapper.Map<Item>(model);
           
            context.Add(item);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public IActionResult Details(int id)
        {

            var model=context.Items.Include(a=>a.Design).FirstOrDefault(a=>a.Id==id);
            if (model is null)
            {
                return NotFound();
            }
            var VM = Mapper.Map<ItemDetails>(model);
            VM.Design = model.Design;
         
           // VM.Design = model.Design;
            return View(VM);
        }
        
        [HttpPost]
        
        public IActionResult DeleteConfirm(int id)
        {
            var item = context.Items.Find(id);
            if (item is null)
            {
                return RedirectToAction(nameof(Index));
            }
            FileSetting.DeleteFile(item.ImageName,"images");


            context.Items.Remove(item);
            context.SaveChanges();
            return Ok(new { message = "Service Deleted" });
        }

        public IActionResult Edit(int id)
        {
           
            var item = context.Items.Include(a=>a.Design).FirstOrDefault(a=>a.Id==id);
            if (item is null)
            {
                return NotFound();
            }
            var vm = new ItemFromVM
            {
                Id = item.Id,
                Name = item.Name,
                ImageName = item.ImageName,
                DesignId = item.DesignId,
                Description = item.Description


            };

            var design = context.Designs.ToList();
            vm.Design = new SelectList(design, "Id", "Name");

            return View(vm);


        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(ItemFromVM ViewModel)
        {
            var item = context.Items.Include(a=>a.Design).FirstOrDefault(a=>a.Id== ViewModel.Id);
            if (!ModelState.IsValid)
            {

                var design = context.Designs.ToList();
                ViewModel.Design = new SelectList(design, "Id", "Name"); // إعادة تحميل الفلاتيكون
                return View(ViewModel);

            }
            var c = ViewModel.ImageName;
            if (ViewModel.Image !=null)
            {
                FileSetting.DeleteFile(item.ImageName, "images");
                ViewModel.ImageName = FileSetting.UploadFile(ViewModel.Image, "images");

            }
            else
            {
                 ViewModel.ImageName= item.ImageName;

            }
           

            if (item is null)
            {
                return NotFound();

            }
            
          Mapper.Map(ViewModel, item);
            context.SaveChanges();
            
                return RedirectToAction(nameof(Index));
        }

        
    }
}
