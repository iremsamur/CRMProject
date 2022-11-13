using Crm.UpSchool.DataAccessLayer.Abstract;
using Crm.UpSchool.DataAccessLayer.Concrete;
using Crm.UpSchool.DataAccessLayer.Repository;
using CrmUpSchool.EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Crm.UpSchool.DataAccessLayer.EntityFramework
{
    public class EfEmployeeTaskDetailDal:GenericRepository<EmployeeTaskDetail>,IEmployeeTaskDetailDal
    {
        //taska göre onun detayları için id'sine göre getirir.
        public List<EmployeeTaskDetail> GetEmployeeTaskDetailById(int id)
        {
            using(var context = new Context())
            {
                return context.EmployeeTaskDetail.Where(x => x.EmployeeTaskID == id).ToList();
            }
        }


    }
}
