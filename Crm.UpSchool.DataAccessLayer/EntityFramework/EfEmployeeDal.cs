using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.EntityFramework
{
    public class EfEmployeeDal : GenericRepository<Employee>, IEmployeeDal
    {
        public void ChangeEmployeeStatusToFalse(int id)
        {
            using (var context = new Context())
            {
                var employee = context.Employees.Find(id);
                employee.EmployeeStatus = false;
                Update(employee);//Bu update'i GenericRepository'den kullanıyoruz
                
            }
        }

        public void ChangeEmployeeStatusToTrue(int id)
        {
            using (var context = new Context())
            {
                var employee = context.Employees.Find(id);
                employee.EmployeeStatus = true;
                Update(employee);
            }
        }

        public List<Employee> GetEmployeesByCategory()
        {
            //ilişkili tabloların aynı anda verilerini listeletmek için include kullanıyoruz
            using(var context = new Context())
            {
                return context.Employees.Include(x => x.Category).ToList();//Include ile Employee ile birlikte ilişkili olan hangi tabloları getirmek istiyorsak
                //hepsi include ile bu şekilde yazılır.
            }
        }
    }
}
