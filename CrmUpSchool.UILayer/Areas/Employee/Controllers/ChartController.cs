using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class ChartController : Controller
    {
        
        public IActionResult Index()
        {

            return View();
        }
        public IActionResult DepartmentChart()
        {
            List<DepartmentSalary> departmentSalaries = new List<DepartmentSalary>();
            departmentSalaries.Add(new DepartmentSalary
            {
                departmentName = "Muhasebe",
                salaryAvg = 17650
            });

            departmentSalaries.Add(new DepartmentSalary
            {
                departmentName = "IT",
                salaryAvg = 20000
            });

            departmentSalaries.Add(new DepartmentSalary
            {
                departmentName = "Satış",
                salaryAvg = 12455
            });
            return Json(new {jsonList=departmentSalaries});//google chart için json döndürüyor. Bu departmentsalaries'den gelecek
        }

    }
}
