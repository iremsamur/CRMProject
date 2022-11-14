using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using MailKit.Net.Smtp;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using System;
using System.Linq;

using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        private readonly IAppUserService _appUserService;
        private readonly UserManager<AppUser> _userManager;

        public MessageController(IMessageService messageService, UserManager<AppUser> userManager, IAppUserService appUserService)
        {
            _messageService = messageService;
            _userManager = userManager;
            _appUserService = appUserService;
        }



        [HttpGet]
        public async Task <IActionResult> SendMessage()
        {
            
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendMessage(Message message)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            message.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            message.ReceiverName = _appUserService.TGetSelectedUserName(message.ReceiverEmail);
           
            message.SenderEmail = user.Email;
            message.SenderName = user.Name+" "+user.Surname;
            _messageService.TInsert(message);//mesaj gönder

            //mesajı mail atma
            MailRequest mailRequest = new MailRequest();
            mailRequest.EmailContent = message.MessageContent;
            mailRequest.EmailSubject = message.MessageSubject;
            mailRequest.ReceiverMail = message.ReceiverEmail;
            await SendEmail(mailRequest);

           
           
            

            return View("SendMessage");
        }
        //mail gönderme işlemi
        [HttpGet]
        public async Task<IActionResult> SendEMail()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SendEmail(MailRequest mailRequest)
        {

            MimeMessage mimeMessage = new MimeMessage();
            MailboxAddress mailBoxAddressFrom = new MailboxAddress("Admin", "mysoftwareproject40@gmail.com");//mailin kimden gittiğini gösterir. 1.parametre mail kim tarafından gönderildi. 2.parametre
            //gönderilen mail adresi yani şifrsini aktif hale getirdiğimiz mail adresi
            mimeMessage.From.Add(mailBoxAddressFrom);//mailin kimden gönderileceği
            //bilgisini ekledik

            MailboxAddress mailboxAddressTo = new MailboxAddress("User",mailRequest.ReceiverMail);//mailin kime gönderileceği
            //bilgisi
            mimeMessage.To.Add(mailboxAddressTo);//mesajın kime gönderileceği bilgisini ekledik

            //mesajın içeriği
            var bodyBuilder = new BodyBuilder();
            bodyBuilder.TextBody=mailRequest.EmailContent;//mailin içeriik kısımı
            mimeMessage.Body = bodyBuilder.ToMessageBody();//mailin içeriği
            mimeMessage.Subject = mailRequest.EmailSubject;//mailin konusu
            SmtpClient client = new SmtpClient();
            client.Connect("smtp.gmail.com", 587, false);
            client.Authenticate("mysoftwareproject40@gmail.com", "wicnautwssjvkdhu");
            //2.parametreye gmail hesabı izinden aldığımız key değerini veriyoruz
            client.Send(mimeMessage);//mimeMessage'ı gönder
            client.Disconnect(true);



            return View();
        }
    }
}
