using Crm.UpSchool.BusinessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace CrmUpSchool.UILayer.Controllers
{
    public class EmployeeTaskController : Controller
    {
        private readonly IEmployeeTaskService _employeeTaskService;
        private readonly UserManager<AppUser> _userManager;

        public EmployeeTaskController(IEmployeeTaskService employeeTaskService, UserManager<AppUser> userManager)
        {
            _employeeTaskService = employeeTaskService;
            _userManager = userManager;
        }

        public IActionResult Index()
        {
            var values = _employeeTaskService.TGetEmployeeTaskswithFollowerAndAssigneeUser();//çalışan görevlerini atayan kişi ve atanan kişilerle birlikte getirir.
            return View(values);
            //kaggle
        }
        [HttpGet]
        public IActionResult AddTask()
        {
            List<SelectListItem> userValues = (from x in _userManager.Users.ToList()//görev atama yaparken kişi seçimini userManager'dan aldığımız bilgilerle yaparız
                                               select new SelectListItem
                                               {
                                                   Text = x.Name + " " + x.Surname,
                                                   Value = x.Id.ToString()
                                               }).ToList();
            ViewBag.v = userValues;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AddTask(EmployeeTask employeeTask)
        {
            var values = await _userManager.FindByNameAsync(User.Identity.Name);
            employeeTask.Status = "Görev Atandı";
            employeeTask.FollowerUserID = values.Id;//görevi atayan kişi oturumdaki login olmuş kişi
            employeeTask.Date = Convert.ToDateTime(DateTime.Now.ToShortDateString());
            _employeeTaskService.TInsert(employeeTask);
            return RedirectToAction("Index");
        }
    }
}
