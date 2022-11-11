using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]//Bu controller'ın areanın controller'u olduğunu belirtmek için Area annotasyonunu ekleriz. Bunu belirtmezsek
    //area olduğunu görmez. Dolayısıyla bu controller'u bulamaz. Employee adında bir areamızın olduğunu söylüyoruz
    public class EmployeeAreaController : Controller
    {
        private readonly UserManager<AppUser> _userManager;

        public EmployeeAreaController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);//login olan kullanıcının bilgilerini
            //identity ile alır. Kullanıcının giriş yaptığı Name değerine göre alır.
            ViewBag.v1 = values.Name;
            ViewBag.v2 = values.Surname;
            return View();
        }
    }
}
