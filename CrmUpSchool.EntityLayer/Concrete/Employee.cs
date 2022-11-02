using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.EntityLayer.Concrete
{
    public class Employee
    {
        public int EmployeeID{get; set;}


        public string EmployeeName
        {
            get; set;
        }
        public string EmployeeSurname
        {
            get; set;
        }
        public string EmployeeMail
        {
            get; set;
        }
        public string EmployeeImage
        {
            get; set;
        }
        //Employee içinde gözükmesini istediğim entity'i aşağıdaki gibi tanımlarım
        //Employee-Category ilişkisi
        //ilişkide bir kısımı
        public int CategoryID
        {
            get; set;
        }
        public Category Category

        {
            get; set;
        }
        //silme işlemini veritabanından doğrudan yapmak doğru değil, durum ile yapmak için şu alanı ekliyoruz
        public bool EmployeeStatus
        {
            get; set;
        }
    }
}
