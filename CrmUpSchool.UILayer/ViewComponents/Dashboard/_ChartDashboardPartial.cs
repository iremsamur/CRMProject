using Crm.UpSchool.DataAccessLayer.Concrete;
using CrmUpSchool.UILayer.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
namespace CrmUpSchool.UILayer.ViewComponents.Dashboard
{
    public class _ChartDashboardPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            List<DepartmentSalary> departmentSalaries = new List<DepartmentSalary>();

         

            return View();
        }
    }
}
