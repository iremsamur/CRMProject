using Crm.UpSchool.BusinessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace CrmUpSchool.UILayer.Areas.Admin.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AdminCustomerController : Controller
    {
        private readonly ICustomerService _customerService;

        public AdminCustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public IActionResult Index()
        {
            return View();
        }
        public IActionResult CustomerList()
        {
            var jsonCustomers = JsonConvert.SerializeObject(_customerService.TGetList());//customer sınıfından gelen verileri serialize edip dönüştürecek
            return Json(jsonCustomers);//json olarak jsonCustomers'ı döndürsün
        }
        //normalde post ettiğinde boş ekleme yapmaması için get ve post olarak iki metod yazarak ekleme işlemi yapıyorduk.
        //ajax kullanarak post etmesini engeller böylece httppost olarak tek method yeterli olur.
        [HttpPost]
        public IActionResult AddCustomer(Customer customer) {
            _customerService.TInsert(customer);//veritabanına işlemi yansıtır
            var values = JsonConvert.SerializeObject(customer);
            return Json(values);//veritabanına ajax üzerinden göndermemi sağlar.


                
        }
        //id'ye göre getirme
        public IActionResult GetByID(int CustomerID)
        {
            var values = _customerService.TGetByID(CustomerID);
            var jsonValues = JsonConvert.SerializeObject(values);
            return Json(jsonValues);


        }
    }
}
