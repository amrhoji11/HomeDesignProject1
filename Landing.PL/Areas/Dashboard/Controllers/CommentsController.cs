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
    public class CommentsController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;

        public CommentsController(IMapper Mapper, ApplecationDbContext Context)
        {
            this.Mapper = Mapper;
            context = Context;
        }
        public IActionResult Index()
        {
            var comments = context.comments.Include(a => a.Profile).ToList();
            var vm = Mapper.Map<IEnumerable<CommentVM>>(comments);

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var comments = context.comments.Include(a => a.Profile).FirstOrDefault(a => a.Id == id);
            if (comments == null)
            {
                return NotFound();
            }
            var vm = Mapper.Map<CommentDetailVM>(comments);



            return View(vm);
        }

        public IActionResult DeleteConfirm(int id)
        {
            var Comment = context.comments.Find(id);
            if (Comment is null)
            {
                return RedirectToAction(nameof(Index));
            }



            context.comments.Remove(Comment);
            context.SaveChanges();
            return Ok(new { message = "Comment Deleted" });
        }
    }
}
