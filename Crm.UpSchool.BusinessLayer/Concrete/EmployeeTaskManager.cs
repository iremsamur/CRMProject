using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Concrete
{
    public class EmployeeTaskManager : IEmployeeTaskService
    {
        IEmployeeTaskDal _employeeTaskDal;

        public EmployeeTaskManager(IEmployeeTaskDal employeeTaskDal)
        {
            _employeeTaskDal = employeeTaskDal;
        }

        public List<EmployeeTask> TGetEmployeeTaskswithFollowerAndAssigneeUser()
        {
            return _employeeTaskDal.GetEmployeeTaskswithFollowerAndAssigneeUser();
        }

        public void TDelete(EmployeeTask t)
        {
            _employeeTaskDal.Delete(t);
        }

        public EmployeeTask TGetByID(int id)
        {
            return _employeeTaskDal.GetByID(id);
        }

        public List<EmployeeTask> TGetEmployeeTaskByEmployee()
        {
            return _employeeTaskDal.GetEmployeeTaskByEmployee();
        }

        public List<EmployeeTask> TGetList()
        {
            return _employeeTaskDal.GetList();
        }

        public void TInsert(EmployeeTask t)
        {
            _employeeTaskDal.Insert(t);
        }

        public void TUpdate(EmployeeTask t)
        {
            _employeeTaskDal.Update(t);
        }
    }
}
