using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using CrmUpSchool.UILayer.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using OfficeOpenXml.FormulaParsing.Excel.Functions.Numeric;
using System;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous]
    public class RegisterController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IAppUserService _appUserService;

      

        public RegisterController(UserManager<AppUser> userManager,IAppUserService appUserService)
        {
            _userManager = userManager;
            _appUserService = appUserService;
        }
        [HttpGet]
        public IActionResult EmailConfirmPage()
        {
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> EmailConfirmedPage(AppUser appUser)
        {
            var user = await _userManager.FindByEmailAsync(appUser.Email);
            if (user.EmailConfirmedControlCode == appUser.EmailConfirmedControlCode)
            {
                user.EmailConfirmed = true;

                var result = await _userManager.UpdateAsync(user);
                return RedirectToAction("Index", "Login");
            }
            return View();
        }
      
        public void SendEmail(string emailAddress,string emailcode)
        {
            MimeMessage mimeMessage = new MimeMessage();

            MailboxAddress mailboxAddressFrom = new MailboxAddress("Admin", "fromEmailAddress");
            mimeMessage.From.Add(mailboxAddressFrom); //Maili gönderen

            MailboxAddress mailboxAddressTo = new MailboxAddress("User", emailAddress);
            mimeMessage.To.Add(mailboxAddressTo); //mail gönderilecek kişi

            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody = emailcode;
            mimeMessage.Body = bodyBuilder.ToMessageBody(); //Mail içeriği

            mimeMessage.Subject = "Üyelik Kaydı"; //Mail konusu

            SmtpClient client = new SmtpClient(); 
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("fromEmailAddress", "emailKey");
            client.Send(mimeMessage);
            client.Disconnect(true);
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
            Random rnd = new Random();
            string code = rnd.Next(10000, 999999).ToString();

            if (ModelState.IsValid)
            {
                AppUser appUser = new AppUser()
                {
                    UserName = userSignUp.Username,
                    Name = userSignUp.Name,
                    Surname = userSignUp.Surname,
                    Email = userSignUp.Email,
                    PhoneNumber = userSignUp.PhoneNumber,
                    EmailConfirmedControlCode=code
                };
                if (userSignUp.Password == userSignUp.ConfirmPassword)
                {
                    //eğer şifreler uyuşuyorsa ona göre işlem yapsın
                    var result = await _userManager.CreateAsync(appUser, userSignUp.Password);
                    if (result.Succeeded)
                    {
                        SendEmail(userSignUp.Email,code);
                        return RedirectToAction("EmailConfirmPage", "Register");
                        //sendEmailConfirmedEmailCode(appUser.Email);

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
