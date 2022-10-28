using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.Abstract
{
    public interface ICustomerDal: IGenericDal<Customer>
    {
        /*
        //Temel Crud işlem metodları
        void Insert(Customer customer);
        void Update(Customer customer);
        void Delete(Customer customer);//delete işleminde tüm satır silineceği için id değil nesne veriliyor
        //sadece silinecek olanı bulma işleminde id kullanılır
        List<Customer> GetList();
        Customer GetByID(int id);
        */

    }
}
