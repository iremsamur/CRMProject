﻿using CrmUpSchool.EntityLayer.Concrete;
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
                return RedirectToAction("Index", "Login");
            }
        

            return View();
        }
    }
}
