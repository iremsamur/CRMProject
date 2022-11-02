using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.Abstract
{
    public interface IEmployeeDal:IGenericDal<Employee>
    {
        List<Employee> GetEmployeesByCategory();//kategorileri ile employee'ları getirecek. Bu metod sadece employee sınıfına özgü.

        //silme yerine durum güncellemek için
        void ChangeEmployeeStatusToTrue(int id);
        void ChangeEmployeeStatusToFalse(int id);
    }
}
