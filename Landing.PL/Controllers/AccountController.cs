using Landing.DAL.Models;
using Landing.PL.Helpers;
using Landing.PL.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Landing.PL.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplecationUser> userManager;
        private readonly SignInManager<ApplecationUser> signInManager;
        private readonly RoleManager<IdentityRole> roleManager;

        public AccountController(UserManager<ApplecationUser> userManager , RoleManager<IdentityRole> roleManager, SignInManager<ApplecationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.roleManager = roleManager;
        }
        public async Task<IActionResult> Register()
        {
          
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm model)
        {
            // التحقق من صحة النموذج
            if (ModelState.IsValid)
            {
                // إنشاء كائن المستخدم
                var user = new ApplecationUser
                {
                    UserName = model.UserName,
                    Email = model.Email
                };

                // إنشاء المستخدم في قاعدة البيانات
                var res = await userManager.CreateAsync(user, model.Password);
                if (res.Succeeded)
                {
                    // التحقق من وجود الدور "User"، وإنشاءه إذا لم يكن موجودًا
                    if (!await roleManager.RoleExistsAsync("User"))
                    {
                        await roleManager.CreateAsync(new IdentityRole("User"));
                    }

                    // إضافة المستخدم إلى الدور "User"
                    await userManager.AddToRoleAsync(user, "User");

                    // إنشاء رمز تأكيد البريد الإلكتروني
                    var token = await userManager.GenerateEmailConfirmationTokenAsync(user);

                    // إنشاء رابط تأكيد البريد الإلكتروني
                    var confirmEmail = Url.Action(
                        "ConfirmEmail",
                        "Account",
                        new { UserId = user.Id, token = token },
                        protocol: HttpContext.Request.Scheme);

                    // إعداد بيانات البريد الإلكتروني
                    var email = new Email
                    {
                        Subject = "Confirm Email",
                        Recivers = model.Email,
                        Body = $"Please confirm your email by clicking this link: {confirmEmail}"
                    };

                    // إرسال البريد الإلكتروني
                    EmailSettings.SendEmail(email);

                    // إعادة التوجيه إلى صفحة التأكيد
                    return RedirectToAction(nameof(ConfirmEmaill));
                }
                else
                {
                    // إذا فشلت عملية إنشاء المستخدم، أضف الأخطاء إلى ModelState
                    foreach (var error in res.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }

      
            return View(model);
        }


        public IActionResult ConfirmEmaill()
        {
            return View();
        }

        public async Task<IActionResult> ConfirmEmail(string UserId, string token)
        {
          
            var user = await userManager.FindByIdAsync(UserId);
            if (user is not null)
            {
                var res= await userManager.ConfirmEmailAsync(user,token);
                if (res.Succeeded)
                {
                    return RedirectToAction(nameof(Login));
                }

            }
            return RedirectToAction("Error","Home");
            
        }

        public IActionResult Login()
        {
         

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var check = await userManager.CheckPasswordAsync(user, model.Password);
                    if (check)
                    {
                        var res = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, false);
                        if (res.Succeeded)
                        {
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
            }
            return View(model);
        }

        public IActionResult ForgetPassword()
        {
            return View();
        }

        public async Task<IActionResult> SendResetPasswordUrl(ForgetPasswordVm model)
        {
            if (ModelState.IsValid)
            {
                var user=await userManager.FindByEmailAsync(model.Email);
                if (user is not null)
                {
                    var token = await userManager.GeneratePasswordResetTokenAsync(user);
                    var resetPasswordUrl = Url.Action("ResetPassword", "Account",new {email=model.Email,token=token },"https", "localhost:7118");
                    var email = new Email
                    {
                        Subject = "Reset Password",
                        Recivers = model.Email,
                        Body = resetPasswordUrl
                    };

                    EmailSettings.SendEmail(email);
                   

                }


            }

            return View(model);
        }

        public IActionResult ResetPassword(string email,string token)
        {
            return View();
        }


        [HttpPost]
        public async Task<IActionResult> ResetPassword(ResetPasswordVm model)
        {
            var user = await userManager.FindByEmailAsync(model.Email);
            if (user is not null) 
            {
                var res = await userManager.ResetPasswordAsync(user,model.Token,model.NewPassword);
                if (res.Succeeded) 
                {
                    return RedirectToAction(nameof(Login));
                
                }
            
            }
            return View(model);
        }

        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));

        }


    }


}
