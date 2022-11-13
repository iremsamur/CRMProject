using Crm.UpSchool.BusinessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Abstract;
using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.BusinessLayer.Concrete
{
    public class EmployeeTaskDetailManager : IEmployeeTaskDetailService
    {
        IEmployeeTaskDetailDal _employeeTaskDetailDal;

        public EmployeeTaskDetailManager(IEmployeeTaskDetailDal employeeTaskDetailDal)
        {
            _employeeTaskDetailDal = employeeTaskDetailDal;
        }

        public void TDelete(EmployeeTaskDetail t)
        {
            _employeeTaskDetailDal.Delete(t);
        }

        public EmployeeTaskDetail TGetByID(int id)
        {
            return _employeeTaskDetailDal.GetByID(id);
        }

        public List<EmployeeTaskDetail> TGetEmployeeTaskDetailById(int id)
        {
            return _employeeTaskDetailDal.GetEmployeeTaskDetailById(id);
        }

        public List<EmployeeTaskDetail> TGetList()
        {
            return _employeeTaskDetailDal.GetList();

        }

        public void TInsert(EmployeeTaskDetail t)
        {
            _employeeTaskDetailDal.Insert(t);
        }

        public void TUpdate(EmployeeTaskDetail t)
        {
            _employeeTaskDetailDal.Update(t);
        }
    }
}
