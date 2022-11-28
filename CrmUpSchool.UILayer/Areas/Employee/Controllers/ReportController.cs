using ClosedXML.Excel;
using Crm.UpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using OfficeOpenXml;
using OfficeOpenXml.FormulaParsing.Excel.Functions.DateTime;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Xml;

namespace CrmUpSchool.UILayer.Areas.Employee.Controllers
{
    [AllowAnonymous]
    [Area("Employee")]
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
            using(var workBook = new XLWorkbook())
            {
                var workSheet = workBook.Worksheets.Add("Müşteri Listesi");
                workSheet.Cell(1, 1).Value = "Müşteri Mail Adresi";
                workSheet.Cell(1, 2).Value = "Müşteri Adı";
                workSheet.Cell(1, 3).Value = "Müşteri Soyadı";
                workSheet.Cell(1, 4).Value = "Müşteri Telefon";
                int rowCount = 2;
                foreach(var item in CustomerList())
                {
                    workSheet.Cell(rowCount, 1).Value = item.Mail;
                    workSheet.Cell(rowCount, 2).Value = item.Name;
                    workSheet.Cell(rowCount, 3).Value = item.Surname;
                    workSheet.Cell(rowCount, 4).Value = item.Phone;
                    rowCount++;

                }
                using(var stream =new MemoryStream())
                {
                    workBook.SaveAs(stream);
                    var content = stream.ToArray();
                    return File(content, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet", "müşteri_listesi.xlsx");
                }
            }
            
            
        }
        public IEnumerable<DateTime> EachCalendarDay(DateTime startDate, DateTime endDate)
        {
            for (var date = startDate.Date;date.Date <= endDate.Date;date = date.AddDays(1)) yield
            return date;
        }
        //pdf rapor oluşturma
        public IActionResult StaticPdfReport()
        {
            string path = Path.Combine(Directory.GetCurrentDirectory(),"/wwwroot/PdfReports/"+"Musteri.pdf");
            var stream = new FileStream(path, FileMode.Create);
            Document document = new Document(PageSize.A4);
            PdfWriter.GetInstance(document,stream);
            document.Open();
            Paragraph paragraph = new Paragraph("Akbank & up School .Net Core" +
                "Backend Proje");
            document.Add(paragraph);
            document.Close();
            return File("/PdfReport/Musteri.pdf", "application/pdf", "Musteri.pdf");

        }
        /*
        public IActionResult GetExhangeRates()
        {
            DateTime StartDate = Convert.ToDateTime("11/10/2022");
            DateTime EndDate = Convert.ToDateTime("27/10/2022");
            string today = "";
            List<double> usdrates = new List<double>();
            List<double> eurorates = new List<double>();
            foreach (DateTime day in EachCalendarDay(StartDate, EndDate))
            {
                if(day.DayOfWeek==DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                else
                {
                    today = "https://www.tcmb.gov.tr/kurlar/" + day.Year + day.Month + "/" + day.Day + day.Month + day.Year + ".xml";
                    Console.WriteLine("Date is : Day : " + day.Day + " Month : " + day.Month + " year : " + day.Year);
                   
                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(today);

                    // Xml içinden tarihi alma - gerekli olabilir
                    DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

                    string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
                    string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
                    usdrates.Add(Convert.ToDouble(USD));
                    eurorates.Add(Convert.ToDouble(EURO));

                }


                //string POUND = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            }
            DateTime StartDate2 = Convert.ToDateTime("1/11/2022");
            DateTime EndDate2 = Convert.ToDateTime("23/11/2022");
            string today2 = "";
      
            foreach (DateTime day in EachCalendarDay(StartDate2, EndDate2))
            {
                if (day.DayOfWeek == DayOfWeek.Saturday || day.DayOfWeek == DayOfWeek.Sunday)
                {
                    continue;
                }
                else
                {
                    today2 = "https://www.tcmb.gov.tr/kurlar/" + day.Year + day.Month + "/" + day.Day + day.Month + day.Year + ".xml";
                    Console.WriteLine("Date is : Day : " + day.Day + " Month : " + day.Month + " year : " + day.Year);

                    var xmlDoc = new XmlDocument();
                    xmlDoc.Load(today);

                    // Xml içinden tarihi alma - gerekli olabilir
                    DateTime exchangeDate = Convert.ToDateTime(xmlDoc.SelectSingleNode("//Tarih_Date").Attributes["Tarih"].Value);

                    string USD = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='USD']/BanknoteSelling").InnerXml;
                    string EURO = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='EUR']/BanknoteSelling").InnerXml;
                    usdrates.Add(Convert.ToDouble(USD));
                    eurorates.Add(Convert.ToDouble(EURO));

                }


                //string POUND = xmlDoc.SelectSingleNode("Tarih_Date/Currency[@Kod='GBP']/BanknoteSelling").InnerXml;
            }

            int size = usdrates.Count();
            List<double> biggestusd = new List<double>();

            biggestusd.Add(usdrates.Max());
            
            usdrates.Remove(usdrates.Max());
            biggestusd.Add(usdrates.Max());

            usdrates.Remove(usdrates.Max());
            biggestusd.Add(usdrates.Max());

            usdrates.Remove(usdrates.Max());
            biggestusd.Add(usdrates.Max());

            usdrates.Remove(usdrates.Max());
            biggestusd.Add(usdrates.Max());

            usdrates.Remove(usdrates.Max());
            int sizebiggest = biggestusd.Count();


            int sizeeuro = eurorates.Count();
            List<double> biggesteuro = new List<double>();

            biggesteuro.Add(eurorates.Max());

            eurorates.Remove(eurorates.Max());
            biggesteuro.Add(eurorates.Max());

            eurorates.Remove(eurorates.Max());
            biggesteuro.Add(eurorates.Max());

            eurorates.Remove(eurorates.Max());
            biggesteuro.Add(eurorates.Max());

            eurorates.Remove(eurorates.Max());
            biggesteuro.Add(eurorates.Max());

            usdrates.Remove(eurorates.Max());
            int sizebiggesteuro = biggesteuro.Count();






            return View();

        }
        */



    }
}
