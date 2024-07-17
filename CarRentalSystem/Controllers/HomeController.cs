
using System.Web.Mvc;
using System.Web.Security;

namespace CarRentalSystem.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            FormsAuthentication.SignOut();
            return View();
        }
    }
}