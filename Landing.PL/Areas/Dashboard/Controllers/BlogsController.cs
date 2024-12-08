using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("Dashboard")]
    public class BlogsController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;

        public BlogsController(IMapper Mapper, ApplecationDbContext Context)
        {
            this.Mapper = Mapper;
            context = Context;
        }
        public IActionResult Index()
        {
            var blog = context.blogs.Include(a => a.Item).ToList();
            var Vm = Mapper.Map<IEnumerable<BlogVM>>(blog);

            return View(Vm);
           
        }

        [HttpGet]
        public IActionResult Create()
        {
            var item = context.Items.ToList();
            var vm = new BlogFromVM
            {
                ItemList = new SelectList(item, "Id", "Name")
            };

            return View(vm);

        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(BlogFromVM model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }





            var blog = new Blog
            {
                Id = model.Id,
                Content = model.Content,
                ItemId = model.SelectItemId
            };


            context.Add(blog);
            context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Details(int id)
        {

            var model = context.blogs.Include(a => a.Item).FirstOrDefault(a => a.Id == id);
            if (model is null)
            {
                return NotFound();
            }
            var VM = Mapper.Map<BlogDetail>(model);
            return View(VM);
        }

        [HttpPost]

        public IActionResult DeleteConfirm(int id)
        {
            var blog = context.blogs.Find(id);
            if (blog is null)
            {
                return RedirectToAction(nameof(Index));
            }



            context.blogs.Remove(blog);
            context.SaveChanges();
            return Ok(new { message = "Blog Deleted" });
        }

        [HttpGet]
        public IActionResult Edit(int id)
        {
            var blog = context.blogs.Include(a => a.Item).FirstOrDefault(a => a.Id == id);
            if (blog is null)
            {
                return NotFound();
            }
            var vm = new BlogFromVM
            {
                Id = id,
                Content = blog.Content,
                SelectItemId = blog.ItemId,
            };

            var item = context.Items.ToList();
            vm.ItemList = new SelectList(item, "Id", "Name");

            return View(vm);


        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(BlogFromVM ViewModel)
        {
            var blog = context.blogs.Find(ViewModel.Id);
            if (!ModelState.IsValid)
            {
                var item = context.Items.ToList();
                ViewModel.ItemList = new SelectList(item, "Id", "Name"); // إعادة تحميل الفلاتيكون
                return View(ViewModel);


            }




            if (blog is null)
            {
                return NotFound();

            }

            blog.Content = ViewModel.Content;
           
            blog.ItemId = ViewModel.SelectItemId;

            context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }






    }
}
