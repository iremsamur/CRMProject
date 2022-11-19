using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        List<DepartmentSalary> departmentSalaries = new List<DepartmentSalary>();
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult DepartmentChart()
        {
            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "Muhasebe",
                salaryavg = 17650
            });

            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "IT",
                salaryavg = 20000
            });

            departmentSalaries.Add(new DepartmentSalary
            {
                departmentname = "Satış",
                salaryavg = 12455
            });
            return Json(new {jsonList=departmentSalaries});//google chart için json döndürüyor. Bu departmentsalaries'den gelecek
        }

    }
}
