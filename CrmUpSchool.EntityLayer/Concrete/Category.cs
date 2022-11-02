using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.EntityLayer.Concrete
{
    public class Category
    {
        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public string CategoryDescription { get; set; }

        //Employee ilişkisi için bu tarafa tanımlama yapmam gerekir.
        //ilişkide çok kısımı
        //list veya collection ikisi ilede olur.
        public ICollection<Employee> Employees
        {
            get; set;
        }
    }
}
