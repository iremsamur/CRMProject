using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.BusinessLayer.ValidationRules;
using CrmUpSchool.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;

namespace CrmUpSchool.UILayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;

        public EmployeeController(IEmployeeService employeeService)
        {
            _employeeService = employeeService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.TGetEmployeesByCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {
            
            return View();
        }
        [HttpPost]
        public IActionResult AddEmployee(Employee employee)
        {
            EmployeeValidator validationRules = new EmployeeValidator();//yazdığımız validasyonu kullanmak için burada çağırıyoruz
            ValidationResult result = validationRules.Validate(employee);//parametreden gelen değerlerin doğruluğunu sorgular
            if (result.IsValid)
            {
                //eğer validasyonu başarılı bir şekilde geçerse
                _employeeService.TInsert(employee);
                return RedirectToAction("Index");
            }
            else
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError(item.PropertyName,item.ErrorMessage);//Modelden gelen durumları mesela burada hata mesajlarını göstermek için kullanırız.
                }
            }
            return View();
            
        }
        public IActionResult DeleteEmployee(int id)
        {
            var values = _employeeService.TGetByID(id);
            if (values.EmployeeStatus == true)
            {
                _employeeService.TChangeEmployeeStatusToFalse(id);

            }
            else
            {
                _employeeService.TChangeEmployeeStatusToTrue(id);

            }
            

            //var values = _employeeService.TGetByID(id);
           // _employeeService.TDelete(values);


            return RedirectToAction("Index");
               

        }


    }
}
