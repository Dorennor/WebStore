using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using System.Linq;
using System.Threading.Tasks;
using WebStore.Models;
using WebStore.ViewModels;

namespace WebStore.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ApplicationContext _db;
        //private readonly IWebHostEnvironment _appEnvironment;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ApplicationContext context/*, IWebHostEnvironment appEnvironment*/)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _db = context;
            //_appEnvironment = appEnvironment;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User { Email = model.Email, UserName = model.UserName };
                var result = await _userManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, false);
                    return RedirectToAction("Index", "Store");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, false);
                if (result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(model.ReturnUrl) && Url.IsLocalUrl(model.ReturnUrl))
                    {
                        return Redirect(model.ReturnUrl);
                    }
                    else
                    {
                        return RedirectToAction("Index", "Store");
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Неправильный логин и (или) пароль");
                }
            }
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Store");
        }

        public IActionResult Profile()
        {
            //User user = _db.Users.Where(u => u.UserName == User.Identity.Name).First();
            //if (_db.UserIcons.Any())
            //{
            //    string path = _db.UserIcons.Where(i => i.UserId == _db.Users.Where(u => u.UserName == User.Identity.Name).First().Id).First().Path;

            //    using (var filestream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Open))
            //    {

            //    }

            //    //UserProfileViewModel model = new UserProfileViewModel
            //    //{
            //    //    User = user,
            //    //    Image = null
            //    //};
            //    //return View(model);
            //}
            /*else */return View(/*new UserProfileViewModel()*/_db.Users.Where(u => u.UserName == User.Identity.Name).First());
        }

        [HttpGet]
        public async Task<IActionResult> EditAccount()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            EditUserViewModel model = new EditUserViewModel { Id = user.Id, Email = user.Email, UserName = user.UserName };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> EditAccount(EditUserViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    user.Email = model.Email;
                    user.UserName = model.UserName;

                    //if (model.UploadedFile != null)
                    //{
                    //    string name = User.Identity.Name + "_" + DateTime.Now.Hour + "_" + DateTime.Now.Minute + "_" + DateTime.Now.Second + "_" + DateTime.Now.Day + "_" + DateTime.Now.Month + "_" + DateTime.Now.Year + ".jpeg";
                    //    string path = "\\image\\user_icons\\" + name;
                    //    using (var filestream = new FileStream(_appEnvironment.WebRootPath + path, FileMode.Create))
                    //    {
                    //        await model.UploadedFile.CopyToAsync(filestream);
                    //    }

                    //    Image image = new Image { Name = name, Path = _appEnvironment.WebRootPath + path, UserId = user.Id };
                    //    _db.UserIcons.Add(image);
                    //    _db.SaveChanges();
                    //}

                    var result = await _userManager.UpdateAsync(user);
                    if (result.Succeeded)
                    {
                        await Logout();
                        return RedirectToAction("Index", "Store");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
            }
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> ChangePassword()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            ChangePasswordViewModel model = new ChangePasswordViewModel { Id = user.Id, Email = user.Email };
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByIdAsync(model.Id);
                if (user != null)
                {
                    IdentityResult result = await _userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Store");
                    }
                    else
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError(string.Empty, error.Description);
                        }
                    }
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Пользователь не найден");
                }
            }
            return View(model);
        }

        //private async void AddAdminAccount()
        //{
        //    if (!_db.Users.Any())
        //    {
        //        RegisterViewModel model = new RegisterViewModel
        //        {
        //            UserName = "admin",
        //            Email = "vova.rud.00@gmail.com",
        //            Password = "123456",
        //            PasswordConfirm = "123456"
        //        };
        //        if (ModelState.IsValid)
        //        {
        //            User user = new User { Email = model.Email, UserName = model.UserName };
        //            var result = await _userManager.CreateAsync(user, model.Password);
        //            if (result.Succeeded)
        //            {
        //                await _signInManager.SignInAsync(user, false);
        //            }
        //        }
        //    }
        //}
    }
}