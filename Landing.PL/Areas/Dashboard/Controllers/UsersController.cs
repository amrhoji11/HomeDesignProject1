using AutoMapper;
using Landing.DAL.Data;
//using Landing.DAL.Data.Migrations;
using Landing.DAL.Models;
using Landing.PL.Areas.Dashboard.ViewModel;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Landing.PL.Areas.Dashboard.Controllers
{
    [Authorize(Roles = "Admin,SuperAdmin")]
    [Area("Dashboard")]

    public class UsersController : Controller
    {
        private readonly IMapper Mapper;
        private readonly ApplecationDbContext context;
        private readonly UserManager<DAL.Models.ApplecationUser> userManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public UsersController(IMapper Mapper, ApplecationDbContext Context,  UserManager<DAL.Models.ApplecationUser> userManager,RoleManager<IdentityRole> roleManager)
        {
            this.Mapper = Mapper;
            context = Context;
            this.userManager = userManager;
            this.roleManager = roleManager;
        }
        public IActionResult Index()
        {
            var user=userManager.Users.ToList();
            var vm = user.Select(user => new UserViewModel
            {
                Id = user.Id,
                UserName=user.UserName,
                Email=user.Email,
                Roles=userManager.GetRolesAsync(user).Result
            }).ToList();
            
            

            return View(vm);
        }

        public IActionResult EditUserRole (string id)
        {

            var vm = new EditUserRoleVM
            {
                Id = id,
                RolesList = roleManager.Roles.Select(
                    role => new SelectListItem
                    {
                        Value = role.Id,
                        Text = role.Name
                    }
                    ).ToList(),
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> EditUserRole (EditUserRoleVM model)
        {
            var user= await userManager.FindByIdAsync(model.Id);
            var CurrentRole = await userManager.GetRolesAsync(user);
            var res = await userManager.RemoveFromRolesAsync(user,CurrentRole);
            var roles = await roleManager.FindByIdAsync(model.SelectedRoles);
            await userManager.AddToRoleAsync(user,roles.Name); 


            return RedirectToAction(nameof(Index));
        }
    }
}
