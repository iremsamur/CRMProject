using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using DocumentFormat.OpenXml.Office2010.ExcelAc;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace CrmUpSchool.UILayer.Controllers
{
    [AllowAnonymous]
    public class RoleController : Controller
    {
        //rol işlemleri için RoleManager kullanılır
        private readonly RoleManager<AppRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;

        public RoleController(RoleManager<AppRole> roleManager, UserManager<AppUser> userManager)
        {
            _roleManager = roleManager;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _roleManager.Roles.ToList();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddRole()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddRole(RoleViewModel roleViewModel)
        {
            if (ModelState.IsValid)
            {
                AppRole appRole = new AppRole()
                {
                    Name = roleViewModel.RoleName
                };
                var result = await _roleManager.CreateAsync(appRole);
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }
                else
                {
                    foreach(var item in result.Errors)
                    {
                        ModelState.AddModelError("", item.Description);
                    }
                }

            }

            return View();
        }
        //rol silme
        public async Task<IActionResult> DeleteRole(int id)
        {
            var role = _roleManager.Roles.FirstOrDefault(x => x.Id == id);
            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        //güncelleme
        [HttpGet]
        public IActionResult UpdateRole(int ID)
        {
            var values = _roleManager.Roles.FirstOrDefault(x=>x.Id==ID);
            return View(values);
        }
        [HttpPost]
        public async Task<IActionResult> UpdateRole(AppRole appRole)
        {
            var values = _roleManager.Roles.FirstOrDefault(x => x.Id == appRole.Id);
            values.Name = appRole.Name;

            var result = await _roleManager.UpdateAsync(values);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }
            return View();
        }
        public IActionResult UserList()
        {
            var values = _userManager.Users.ToList();
            return View(values);
        }
        [HttpGet]
        public async Task<IActionResult> AssignRole(int id)
        {
            //rol atadan kullanıcılar listesinden seçilen kişi id
            var user = _userManager.Users.FirstOrDefault(x => x.Id == id);
            var roles = _roleManager.Roles.ToList();
            TempData["UserId"] = user.Id;
            //TempData ile user'ı view'e gönderiyoruz. TempData ile o controller dışında başka controller'un UI^'na datayı taşıyabiliriz. Ama viewbag de sadece aynı controller'un UI'na gönderilebilir.
            var userRoles = await _userManager.GetRolesAsync(user);//gönderilen kullanıcının rolünü getirsin.
            List<RoleAssignViewModel> models = new List<RoleAssignViewModel>();
            foreach(var item in roles)
            {
                //rol atama yapar. Roles listesinden gelen rolü
                RoleAssignViewModel roleAssignViewModel = new RoleAssignViewModel();
                roleAssignViewModel.Name = item.Name;
                roleAssignViewModel.RoleID = item.Id;
                roleAssignViewModel.Exists = userRoles.Contains(item.Name);
                models.Add(roleAssignViewModel);
            }
            return View(models);


        }
        [HttpPost]
        public async Task<IActionResult> AssignRole(List<RoleAssignViewModel> model)
        {
            //list olarak RoleAssignViewModel'i alıyor.  çünkü birden fazla rolde gelebilir.
            var userid = (int)TempData["UserId"];//Controller'dan UI'a TempData ile gönderdiğimiz veriyi burada controller'da çağırıp kullanıyoruz.
            var user = _userManager.Users.FirstOrDefault(x=>x.Id==userid);
            foreach(var item in model)
            {
                //bize srçtiklerimiz liste olarak geliyor. AssignRole yapıp veritabanına bu kaydedecek get'den gelen seçilenlere göre
                //eğer ilgili rol seçilmişse AspNetUserRoles'e ekleme yapılır
                //Seçilmemişse silme yapılacak
                if (item.Exists)
                {
                    //rol var mı checkbox işaretli mi çünkü varsa bu işlemler olacak
                    await _userManager.AddToRoleAsync(user,item.Name);
                    //checkboxda seçili ise rolü ekle
                }
                else
                {
                    await _userManager.RemoveFromRoleAsync(user,item.Name);
                    //checkboxda seçili değilse o rolü sil 
                }
            }
            return RedirectToAction("UserList");
        }

    }
}
