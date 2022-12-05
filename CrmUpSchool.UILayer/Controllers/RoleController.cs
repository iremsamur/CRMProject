using CrmUpSchool.EntityLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
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

    }
}
