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

    public class EfEmployeeTaskDal : GenericRepository<EmployeeTask>, IEmployeeTaskDal
    {
        public List<EmployeeTask> GetEmployeeTaskByEmployee()
        {
            using (var context = new Context())
            {
                var values = context.EmployeeTasks.Include(x => x.AssigneeUser).ToList();
               //sadece görevin atandığı kişi bilgisini alır.
                return values;
            }
        }

        public List<EmployeeTask> GetEmployeeTaskById(int id)
        {
           using(var context = new Context())
            {
                var values = context.EmployeeTasks.Where(x => x.TaskAssigneeUserID == id).ToList();
                return values;
            }
        }

        public List<EmployeeTask> GetEmployeeTaskswithFollowerAndAssigneeUser()
        {
            using (var context = new Context())
            {
                var values = context.EmployeeTasks.Include(x => x.AssigneeUser).Include(x => x.FollowerUser).ToList();
                //assignee ve follower user bilgileriyle birlikte taskları getirir. Include ile tüm ilişkili olduğu tabloları veriyoruz
                return values;
            }

        }
    }
}
