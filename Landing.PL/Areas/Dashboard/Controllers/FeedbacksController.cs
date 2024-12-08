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
    public class FeedbacksController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;

        public FeedbacksController(IMapper Mapper, ApplecationDbContext Context)
        {
            this.Mapper = Mapper;
            context = Context;
        }
        public IActionResult Index()
        {
            var Feedbackes = context.feedbacks.Include(a => a.Profile).ToList();
            var vm = Mapper.Map<IEnumerable<FeedbackVM>>(Feedbackes);

            return View(vm);
        }

        public IActionResult Details(int id)
        {
            var feedbacke = context.feedbacks.Include(a => a.Profile).FirstOrDefault(a => a.Id == id);
            if (feedbacke == null)
            {
                return NotFound();
            }
            var vm = Mapper.Map<FeedbackeDetails>(feedbacke);



            return View(vm);
        }

        public IActionResult DeleteConfirm(int id)
        {
            var feedback = context.feedbacks.Find(id);
            if (feedback is null)
            {
                return RedirectToAction(nameof(Index));
            }



            context.feedbacks.Remove(feedback);
            context.SaveChanges();
            return Ok(new { message = "Feedback Deleted" });
        }
    }
}
