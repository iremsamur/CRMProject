using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public RegisterController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(AppUser appUser)
        {
            var result = await _userManager.CreateAsync(appUser,appUser.PasswordHash);//bu metod yeni bir kullanıcı değeri oluşturacak. Bir kullanıcı ve şifre istiyor
            //await burada beklemeden çalışmasını sağlar.
            bool check = result.Succeeded;
            if (result.Succeeded)
            {
                ViewBag.registerIsSucceeded = true;
                return RedirectToAction("Index", "Login");
            }
        

            return View();
        }

        //Register
        [HttpGet]
        public IActionResult SignUp()
        {
            return View();
        }
        //Register
        [HttpPost]
        public async Task<IActionResult> SignUp(UserSignUpModel userSignUp)
        {
            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = userSignUp.Username,
                    Name = userSignUp.Name,
                    Surname = userSignUp.Surname,
                    Email = userSignUp.Email,
                    PhoneNumber = userSignUp.PhoneNumber
                };
                if (userSignUp.Password == userSignUp.ConfirmPassword)
                {
                    //eğer şifreler uyuşuyorsa ona göre işlem yapsın
                    var result = await _userManager.CreateAsync(appUser, userSignUp.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Login");
                    }
                    else
                    {
                        foreach (var item in result.Errors)
                        {
                            ModelState.AddModelError("", item.Description);//hataları UI tarafında bana göstermesi için gerekli 
                        }
                    }
                }
                

            }
            
            return View();
        }

    }
}
