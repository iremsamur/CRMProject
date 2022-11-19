using Crm.UpSchool.DataAccessLayer.Concrete;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
namespace CrmUpSchool.UILayer.ViewComponents.Dashboard
{
    public class _FeatureDashboardPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            

            return View();
        }
    }
}
