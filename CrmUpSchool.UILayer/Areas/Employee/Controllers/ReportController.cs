using Crm.UpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using iTextSharp.text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using System.Collections.Generic;
using System.Linq;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [AllowAnonymous]
    public class ReportController : Controller
    {

        //static Excel Listesi- database'e bağlı olmadan
        public IActionResult ReportList()
        {
            //Index'e view oluşturmuyorum. Çünkü oluşturursam dosyayı indirir.
            //Bunu engellemek için Reportlist içinde bir liste olsun buradan indirme yapsın diyorum
            return View();
        }
        public IActionResult Index()
        {
            ExcelPackage excelPackage = new ExcelPackage();
            //önce excel dosyası için çalışma sayfası lazım. Onu tanımlıyoruz
            var workSheet = excelPackage.Workbook.Worksheets.Add("Sayfa1");//çalışma kitabının içine yeni çalışma sayfası ekliyorum
            workSheet.Cells[1, 1].Value = "Personel ID";//worksheete hücre ekledim Hücrenin 1,1 diyerek
                                                        //1.satır1.sütununu alıyorum
            workSheet.Cells[1, 2].Value = "Personel Adı";
            workSheet.Cells[1, 3].Value = "Personel Soyadı";
            workSheet.Cells[2, 1].Value = "0001";
            workSheet.Cells[2, 2].Value = "İrem";
            workSheet.Cells[2, 3].Value = "Samur";
            workSheet.Cells[3, 1].Value = "0002";
            workSheet.Cells[3, 2].Value = "Tuba";
            workSheet.Cells[3, 3].Value = "Zorlu";
            var bytes = excelPackage.GetAsByteArray();// excelde yazdığım worksheet'i byte dizisi olarak alırım
            return File(bytes, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet","personeller.xlsx");//1.parametre dosyanın içeriğini gönder
            //2.parametre dosyanın içeriğinin uzantısı



          
        }
        //dinamik excel
        public List<CustomerViewModel> CustomerList()
        {
            List<CustomerViewModel> customerViewModels = new List<CustomerViewModel>();
            using(var context = new Context())
            {
                customerViewModels = context.Customers.Select(x => new CustomerViewModel
                {
                    Mail=x.CustomerMail,
                    Name=x.CustomerName,
                    Surname=x.CustomerSurname,
                    Phone=x.CustomerPhone


                }).ToList();
            }
            return customerViewModels;
        }


        public IActionResult DynamicExcel()
        {
            return View();
            
        }
    }
}
