using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.EntityLayer.Concrete
{
    public class EmployeeTask
    {
        public int EmployeeTaskID { get; set; }
        public string Title { get; set; }//görev adı
        public string Details { get; set; }
        public string Status { get; set; }
        public DateTime Date { get; set; }
        public int TaskAssigneeUserID { get; set; }//görevin atandığı kişi
        public AppUser AssigneeUser { get; set; }
        //görevi atayan kişi identity'den geliyor.
        public int FollowerUserID { get; set; }//görevin atandığı kişi
        public AppUser FollowerUser { get; set; }//görevi atayan kişi

    }
}
