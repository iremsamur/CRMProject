using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrmUpSchool.EntityLayer.Concrete
{
    public class AppUser : IdentityUser<int>
    {
        public string Name
        {
            get; set;
        }
        public string Surname
        {
            get; set;
        }
        public string ImageUrl
        {
            get; set;
        }
        public string Gender
        {
            get; set;
        }
        public string EmailConfirmedControlCode { get; set; }
        public List<EmployeeTask> EmployeeTasksFollower { get; set; }
        public List<EmployeeTask> EmployeeTasksAssignee { get; set; }
    }
}
