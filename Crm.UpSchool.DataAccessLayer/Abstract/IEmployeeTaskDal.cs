using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.Abstract
{
    public interface IEmployeeTaskDal : IGenericDal<EmployeeTask>
    {
        List<EmployeeTask> GetEmployeeTaskByEmployee();//sadece görevin atandığı kişi bilgisini getirir.
        List<EmployeeTask> GetEmployeeTaskswithFollowerAndAssigneeUser();//assignee ve follower bilgisi ile görevleri getirir.
    }
}
