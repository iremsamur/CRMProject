using Crm.UpSchool.BusinessLayer.Abstract;
using Microsoft.AspNetCore.Mvc;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [Area("Employee")]
    public class EmployeeTaskDetail : Controller
    {
        private readonly IEmployeeTaskDetailService _employeeTaskDetailService;
        //buradaki dependency injection'un startup.cs'de de tanımlanması gerekiyor

        public EmployeeTaskDetail(IEmployeeTaskDetailService employeeTaskDetailService)
        {
            _employeeTaskDetailService = employeeTaskDetailService;
        }

        public IActionResult Index(int id)
        {
            var values = _employeeTaskDetailService.TGetEmployeeTaskDetailById(id);
            return View(values);
        }
    }
}
