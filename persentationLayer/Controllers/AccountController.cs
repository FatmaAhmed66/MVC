using Demo.DataAcessLayer.Models;
using Demo.persentationLayer.Utilities;
using Demo.persentationLayer.viewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Demo.persentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        #region Register
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Register(RegisterViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser()
                {
                    UserName = viewModel.UserName,
                    Email = viewModel.Email,
                    IsAgree = viewModel.IsAgree,
                    FirstName = viewModel.FirstName,
                    LastName = viewModel.LastName,

                };
                var result = _userManager.CreateAsync(user, viewModel.Password).Result;
                if (result.Succeeded) return RedirectToAction("Login");
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);

                    }
                    return View(viewModel);
                }
            }

            return View(viewModel);
        }
        #endregion


        #region Login
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel viewModel)
        {
            if (!ModelState.IsValid)return View(viewModel);
                var user = _userManager.FindByEmailAsync(viewModel.Email).Result;
            if (user is not null)
            {
                bool flag = _userManager.CheckPasswordAsync(user, viewModel.Password).Result;
                if (flag)
                {
                    var Result = _signInManager.PasswordSignInAsync(user, viewModel.Password, viewModel.RememberMe, false).Result;

                    if (Result.IsNotAllowed)
                    {
                        ModelState.AddModelError(string.Empty, "Your Account Is Not Allowed");
                    }

                    if (Result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Your Account is Locked out");
                    }

                    if (Result.Succeeded)
                    {
                        return RedirectToAction(nameof(HomeController.Index),"Home");
                    }

                }
            }
            else
            {
                ModelState.AddModelError(string.Empty, "invalid login");
              
            }
            return View(viewModel);
        }
        #endregion


        #region SIGNOUT
        public async Task<IActionResult> SignOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(Login));
        }
        #endregion
        #region forget password
        public IActionResult ForgetPassword()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SendResetPasswordLink(ForgetPasswordViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                var user = _userManager.FindByEmailAsync(viewModel.Email).Result;
                if(user is not null)
                {
                    var token = _userManager.GeneratePasswordResetTokenAsync(user).Result;
                    // BaseURL/account/resetpassword/faty662004@gmail.com/token
                    var ReserPasswordUrl = Url.Action("ResetPassword", "Account", new
                    {
                        email=viewModel.Email,
                        token
                    },Request.Scheme);

                    //Create email
                    var email = new Email()
                    {
                        To = viewModel.Email,
                        Subject = "Reset Password",   
                        Body = ReserPasswordUrl

                    };

                    //send email 

                    EmailSettings.SendEmail(email);
                    return RedirectToAction("CheckYourInbox");

                }
               

            }
            ModelState.AddModelError(string.Empty, "invalid operation");
            return View(nameof(ForgetPassword), viewModel);
        }
        #endregion

        #region "CheckYourInbox"

        [HttpGet]
        public IActionResult CheckYourInbox()
        {
            return View();
        }
        #endregion

        #region Resetpass
        [HttpGet]
        public IActionResult ResetPassword(string email,string token)
        {
            TempData["email"] = email;
            TempData["token"] = token;
            return View();
        }

        [HttpPost]

        public IActionResult ResetPassword(ResetPasswordViewModel viewModel)
        {

            if (!ModelState.IsValid) return View(viewModel);
            string email = TempData["email"] as string ?? string.Empty;
            string token = TempData["token"] as string ?? string.Empty;

            var user = _userManager.FindByEmailAsync(email).Result;
            if(user != null)
            {
               var Result= _userManager.ResetPasswordAsync(user, token, viewModel.Password).Result;
                if (Result.Succeeded)
                    return RedirectToAction (nameof(Login));

                else
                {
                    foreach (var item in Result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, item.Description);

                    }
                }
            }

            return View(nameof(ResetPassword), viewModel);
          
        
        }
        #endregion
    }
}
