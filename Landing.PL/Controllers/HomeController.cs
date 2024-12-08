using AutoMapper;
using Landing.DAL.Data;
using Landing.DAL.Models;
using Landing.PL.Helpers;
using Landing.PL.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NuGet.Protocol;
using System.Diagnostics;
using System.Security.Claims;
using Landing.PL.Areas.Dashboard.ViewModel;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;
using Microsoft.AspNetCore.Authentication;

namespace Landing.PL.Controllers;


public class HomeController :  BaseController
{
    private readonly ILogger<HomeController> _logger;
    private readonly ApplecationDbContext _context;
    private readonly IMapper mapper;
    private readonly UserManager<ApplecationUser> userManager;
    private readonly SignInManager<ApplecationUser> signInManager;

    public HomeController(ILogger<HomeController> logger, ApplecationDbContext Context, IMapper mapper , UserManager<ApplecationUser> userManager, SignInManager<ApplecationUser> signInManager) : base(Context)
    {
        _logger = logger;
        _context = Context;
        this.mapper = mapper;
        this.userManager = userManager;
        this.signInManager = signInManager;
    }




    public  async Task<IActionResult> Index()
    {
       
        var homeLabels =  _context.HomeLabels.ToList();
        
        var informations= _context.Informations.ToList();
        


        var items = _context.Items
                     .Include(i => i.Blog)
                     .Include(i => i.Design)
                     .ToList();
        var designs = _context.Designs.Include(a=>a.Flaticon).ToList();

        var comments= _context.comments.Include(a=>a.Profile).ToList();
        var feedback=_context.feedbacks.Include(a=>a.Profile).ToList();

        
        var allUsers = await userManager.Users.ToListAsync();

        
        var usersWithRoles = new List<ApplecationUser>();
        foreach (var user in allUsers)
        {
            if (await userManager.IsInRoleAsync(user, "Admin") || await userManager.IsInRoleAsync(user, "SuperAdmin"))
            {
                usersWithRoles.Add(user);
            }
        }

        
        var allSocials = await _context.socials
            .Include(s => s.ApplecationUser).ThenInclude(a=>a.Profile) 
            .ToListAsync();

        
        var socials = allSocials
            .Where(s => usersWithRoles.Any(u => u.Id == s.ApplecationUserId))
            .ToList();

        ViewBag.social = socials;
        ViewBag.feedback= feedback;

        ViewBag.comment = comments;
        ViewBag.info = informations;
        
        ViewBag.items = items;
        ViewBag.designs = designs;


        var data = new IndexVm
        {
            HomeLabels = homeLabels.Select(h => new HLebelFromVM
            {

                Id = h.Id,
                Name = h.Name,
                IsDeleted = h.IsDeleted,
                Description = h.Description,
                ImageName = h.ImageName



            }).ToList(),
          
        };
            return View(data); 
       

    }



    public IActionResult Privacy()
    {
        return View();
    }

    public async Task<IActionResult> About() 
    {
        var allUsers = await userManager.Users.ToListAsync();

       
        var usersWithRoles = new List<ApplecationUser>();
        foreach (var user in allUsers)
        {
            if (await userManager.IsInRoleAsync(user, "Admin") || await userManager.IsInRoleAsync(user, "SuperAdmin"))
            {
                usersWithRoles.Add(user);
            }
        }

        
        var allSocials = await _context.socials
            .Include(s => s.ApplecationUser).ThenInclude(a=>a.Profile) 
            .ToListAsync();

       
        var socials = allSocials
            .Where(s => usersWithRoles.Any(u => u.Id == s.ApplecationUserId))
            .ToList();

        ViewBag.social = socials;
        return View();
    
    }

    public IActionResult Service()
    {
        var designs = _context.Designs.Include(a => a.Flaticon).ToList();
        var feedback = _context.feedbacks.Include(a => a.Profile).ToList();
        ViewBag.designs = designs;
        ViewBag.feedback = feedback;

        return View();
    }

    public IActionResult Project()
    {
        var items = _context.Items.Include(a => a.Design).ToList();
        var designs = _context.Designs.Include(a => a.Flaticon).ToList();
        ViewBag.items = items;
        ViewBag.designs = designs;


        return View();
    }

    public IActionResult OutBlog()
    {
        var items = _context.Items
                      .Include(i => i.Blog)
                      .Include(i => i.Design)
                      .ToList();
        ViewBag.items = items;

        return View();
    }

    [HttpGet]
    public async Task <IActionResult> Contact()
    {
        var user = await userManager.GetUserAsync(User);
        var profile = _context.profiles.Include(p => p.Massages).FirstOrDefault(p => p.ApplecationUserId == user.Id);
        if (profile==null)
        {
            return RedirectToAction("Login","Account");

        }
        ViewBag.Profile = profile;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Contact(Massage massage)
    {
        if (massage.YourName==null|| massage.YourMassage==null)
        {
            return View(massage);
        }
        
            var user = await userManager.GetUserAsync(User);
            var profile = _context.profiles.Include(a=>a.Massages).FirstOrDefault(p => p.ApplecationUserId == user.Id);

            
                massage.PProfileId = profile.Id; 
                _context.massages.Add(massage);
                await _context.SaveChangesAsync();
                return RedirectToAction("Index", "Home"); 
           
        

        
    }


    [HttpGet]
    public async Task<IActionResult> BlogDetail()
    {
        var itemss = await _context.Items
     .Include(i => i.Blog)
     .Where(i => i.Blog != null)
     .OrderByDescending(i => i.Id) 
     .Take(3)
     .ToListAsync();

        
        if (itemss == null || !itemss.Any())
        {
            ViewBag.itemss = Enumerable.Empty<Item>();
            Console.WriteLine("No items found.");
        }
        else
        {
            ViewBag.itemss = itemss;
            Console.WriteLine($"Found {itemss.Count} items.");
        }



        var comments = await _context.comments
       .Include(c => c.Replies)
       .Include(c => c.Profile)
       .OrderBy(c => c.DatePosted)
       .Take(3)
       .ToListAsync();

        var commentsWithReplies = comments
            .Where(c => c.ParentCommentId == null)
            .ToList();

        foreach (var comment in commentsWithReplies)
        {
            comment.Replies = comments
                .Where(c => c.ParentCommentId == comment.Id)
                .OrderBy(c => c.DatePosted)
                .ToList();
        }

       
        ViewBag.Comment = commentsWithReplies as List<Comment> ?? new List<Comment>();

        var user = await userManager.GetUserAsync(User);
        var profile = await _context.profiles.FirstOrDefaultAsync(p => p.ApplecationUserId == user.Id);

        if (profile == null)
        {
            return RedirectToAction("Login", "Account");
        }

        ViewBag.Profile = profile;

        // ??? ???? ??????????
        var allUsers = await userManager.Users.ToListAsync();
        var firstAdminUser = default(ApplecationUser);

        // ??? ??? Admin ?? ????? ????????
        foreach (var userr in allUsers)
        {
            try
            {
                if (await userManager.IsInRoleAsync(userr, "Admin"))
                {
                    var adminProfile = await _context.profiles.FirstOrDefaultAsync(p => p.ApplecationUserId == userr.Id);

                    if (adminProfile != null)
                    {
                        firstAdminUser = userr;
                        ViewBag.FirstAdmin = adminProfile; // ???? ?? ?? Admin Profile ?????
                        break;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error occurred while checking role for user {userr.Id}: {ex.Message}");
            }
        }

        if (firstAdminUser == null)
        {
            Console.WriteLine("Admin user doesn't have a Profile or is not found in the database.");
        }




        ViewBag.Designs = _context.Designs
       .Select(d => new
       {
           d.Name,
           ItemCount = _context.Items.Count(i => i.DesignId == d.Id)
       })
       .ToList();

        
        var items = await _context.Items
            .Include(i => i.Blog)
            .Include(i => i.Design)
            .ThenInclude(d => d.Flaticon) 
            .Where(i => i.Blog != null)
            .ToListAsync();

        if (items == null || !items.Any())
        {
            ViewBag.item = Enumerable.Empty<Item>(); 
            Console.WriteLine("No items found.");
        }
        else
        {
            ViewBag.item = items; 
            Console.WriteLine($"Found {items.Count} items.");
        }

        return View(); 
    }

    [HttpGet]
    public async Task<IActionResult> ReplyToComment(int commentId)
    {
        var parentComment = await _context.comments
            .Include(c => c.Profile)
            .FirstOrDefaultAsync(c => c.Id == commentId);

        if (parentComment == null)
        {
            return NotFound(); 
        }

        return View(parentComment); 
    }
    public async Task<IActionResult> AllComments()
    {
        
        var comments = await _context.comments
           .Include(c => c.Replies) 
           .Include(c => c.Profile) 
           .OrderBy(c => c.DatePosted) 
           .ToListAsync();

        
        var commentsWithReplies = comments
            .Where(c => c.ParentCommentId == null)  
            .ToList();

        
        foreach (var comment in commentsWithReplies)
        {
            comment.Replies = comments
                .Where(c => c.ParentCommentId == comment.Id)  
                .OrderBy(c => c.DatePosted)  
                .ToList();
        }

        ViewBag.Comment = commentsWithReplies; 

        return View(); 
    }


    [HttpPost]
    public async Task<IActionResult> ReplyToComment(int parentCommentId, string content)
    {
       
        var parentComment = await _context.comments
            .Include(c => c.Profile)  
            .FirstOrDefaultAsync(c => c.Id == parentCommentId);

        if (parentComment == null)
        {
            return NotFound(); 
        }

       
        var userId = User.FindFirstValue(ClaimTypes.NameIdentifier); 
        var profile = await _context.profiles.FirstOrDefaultAsync(p => p.ApplecationUserId == userId); // ??? ????????? ????? ??? ???? ????????

        
        var reply = new Comment
        {
            Content = content,
            DatePosted = DateTime.Now,
            ParentCommentId = parentCommentId,  
            PProfileId = profile?.Id, 
            Profile = profile, 
            Name = profile?.Name 
        };

        
        _context.comments.Add(reply);
        await _context.SaveChangesAsync();

        
        return RedirectToAction("BlogDetail");
    }










    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult BlogDetail(Comment comment)
    {
       
        comment.DatePosted = DateTime.Now;
        if (comment.Name==null || comment.Content==null)
        {
            return View(comment);

        }

        _context.comments.Add(comment);
        _context.SaveChanges();

        return RedirectToAction("BlogDetail", "Home");
    }

    public IActionResult Info(int id)
    {
        
        var item = _context.Items
            .Include(i => i.Design)  
            .FirstOrDefault(i => i.Id == id);

        if (item == null)
        {
            return NotFound();
        }

        return View(item);
    }

    public IActionResult InfoBlog(int id)
    {
       
        var blog = _context.blogs
            .Include(i => i.Item.Design) 
            .FirstOrDefault(i => i.ItemId == id);

        if (blog == null )
        {
            return View("NoBlog");
        }

        return View(blog);
    }

    [HttpGet]
    public async Task<IActionResult> GetTopComments()
    {
       
        var comments = await _context.comments
            .Include(c => c.Profile) 
            .OrderByDescending(c => c.DatePosted) 
            .Take(3) 
            .ToListAsync();

        return View(comments);
    }


  

 




    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

    

}
