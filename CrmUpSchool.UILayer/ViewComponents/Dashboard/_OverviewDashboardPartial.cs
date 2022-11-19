using Crm.UpSchool.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace CrmUpSchool.UILayer.ViewComponents.Dashboard
{
    public class _OverviewDashboardPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            using (var context = new Context())
            {
                ViewBag.EmployeeCount = context.Employees.Count();
                ViewBag.EmployeeGenderWomanCount = context.Users.Where(x => x.Gender == "Kadın").Count();
                int id = context.Users.Max(x => x.Id);
                ViewBag.LastUser = context.Users.Where(x => x.Id == id).Select(x => x.Name + " " + x.Surname).FirstOrDefault(); 
                /*
                 2.yol
                ViewBag.LastUser= context.Users.OrderByDescending(x=>x.Id)
                .Take(1).SingLeOrDefault().Name*/
                



            }
            
            return View();
        }
    }
}
