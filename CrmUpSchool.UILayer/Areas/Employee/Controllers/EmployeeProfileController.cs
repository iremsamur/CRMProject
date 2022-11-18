using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Areas.Employee.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;


namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeProfileController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeProfileController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> EditEmployeeProfile()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            UserEditProfileViewModel userEditProfileViewModel = new UserEditProfileViewModel();
            userEditProfileViewModel.Name = values.Name;
            userEditProfileViewModel.Surname = values.Surname;
            userEditProfileViewModel.PhoneNumber = values.PhoneNumber;
            userEditProfileViewModel.Email= values.Email;
            return View(userEditProfileViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> EditEmployeeProfile(UserEditProfileViewModel userEditProfileViewModel)
        {

            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            //resim güncelleme
            if (userEditProfileViewModel.Image != null)
            {
                var resource = Directory.GetCurrentDirectory();//bulunduğumuz klasör konumunu alır
                var extension = Path.GetExtension(userEditProfileViewModel.Image.FileName);//aynı isimli resimi kullanıcı eklerse diye buradan yeniden adlandırılıyor
                var ImageName = Guid.NewGuid() + extension;
                var saveLocation = resource + "/wwwroot/UserImages/" + ImageName;
                var stream =new FileStream(saveLocation,FileMode.Create);//resimin kaydolacağı kısım ve dosya erişim türü olarak iki tür alır
                await userEditProfileViewModel.Image.CopyToAsync(stream);
                user.ImageUrl = ImageName;


                    




            }
            user.Name = userEditProfileViewModel.Name;
            user.Surname = userEditProfileViewModel.Surname;
            user.PhoneNumber = userEditProfileViewModel.PhoneNumber;
            user.Email = userEditProfileViewModel.Email;
            user.PasswordHash = _userManager.PasswordHasher.HashPassword(user, userEditProfileViewModel.Password);//1.parametre hangi kullanıcı için olacak, 2. ise şifrenin geleceği kısım
            var result = await _userManager.UpdateAsync(user);
            //confirm password kontrolü ekle
            if (result.Succeeded)
            {
                //resultda değer varsa yani başarılı bir şekilde güncellendiyse
                return RedirectToAction("Index","Login");

            }
            return View();
        }
        //1.soru : html tarafındaki kısıtlamalar ile backend tarafındaki kısıtlamalar arasında ne fark var
        //2.soru değişkenlerin büyük harf ile küçük harf ile başlayanlar arasında ne fark var.
    }
}
