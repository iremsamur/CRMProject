using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.BusinessLayer.ValidationRules;
using CrmUpSchool.EntityLayer.Concrete;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.Linq;

namespace CrmUpSchool.UILayer.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly IEmployeeService _employeeService;
        private readonly ICategoryService _categoryService;//kategori listesini getirmek için CategoryService'ide dahil ettim.

        public EmployeeController(IEmployeeService employeeService,ICategoryService categoryService)
        {
            _employeeService = employeeService;
            _categoryService = categoryService;
        }

        public IActionResult Index()
        {
            var values = _employeeService.TGetEmployeesByCategory();
            return View(values);
        }
        [HttpGet]
        public IActionResult AddEmployee()
        {

            //sayfa yüklendiğinde dropdown içinde kategori listesini getirecek

            List<SelectListItem> categoryValues = (from x in _categoryService.TGetList()
                                                   select new SelectListItem
                                                   {
                                                       Text = x.CategoryName,//dropdown içinde görünecek kısım. CategoryName text olur
                                                       Value = x.CategoryID.ToString()//seçim yapıldığında id'sini alan kısım ise Value Category.Id olur



                                                   }).ToList();
            ViewBag.v = categoryValues;//frontend tarafına bu listeyi viewbag ile aktarırız
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
        public IActionResult ChangeStatusToFalse(int id)
        {

            _employeeService.TChangeEmployeeStatusToFalse(id);
           
           
            return RedirectToAction("Index");
        }
        public IActionResult ChangeStatusToTrue(int id)
        {

            _employeeService.TChangeEmployeeStatusToTrue(id);
            return RedirectToAction("Index");
        
       }

        //güncelleme
        [HttpGet]
        public IActionResult UpdateEmployee(int id)
        {
            var values = _employeeService.TGetByID(id);
            return View(values);

        
        }
        [HttpPost]
        public IActionResult UpdateEmployee(Employee employee)
        {
            var values = _employeeService.TGetByID(employee.EmployeeID);//güncellenecek olanda status, tarih gibi güncellenmeyecek olan bilgilere mevcut değerini atamak için
            //var olan mevcut bilgileri getirmek için bunu yazdık.
            employee.EmployeeStatus = values.EmployeeStatus;//statusü güncellememesi default değer atamaması eski değeri ne ise onu ataması için bunu yaptık.

            _employeeService.TUpdate(employee);
            return RedirectToAction("Index");

        }



    }
}
