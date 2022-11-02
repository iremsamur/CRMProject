using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Abstract
{
    public interface IEmployeeService : IGenericService<Employee>
    {
        public List<Employee> TGetEmployeesByCategory();
        public void TChangeEmployeeStatusToFalse(int id);
        public void TChangeEmployeeStatusToTrue(int id);
    }
}
