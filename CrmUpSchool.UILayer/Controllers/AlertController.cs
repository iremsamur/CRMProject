using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CrmUpSchool.UILayer.Controllers
{
    [Area("Admin")]
    [AllowAnonymous]
    public class AlertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
