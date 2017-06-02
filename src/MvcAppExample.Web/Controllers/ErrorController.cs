using System.Web.Mvc;

namespace MvcAppExample.Web.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index(int? code)
        {
            return View("Error");
        }

        public ActionResult AccessDenied()
        {
            return View("AccessDenied");
        }

        public ActionResult NotFound()
        {
            return View("NotFound");
        }
    }
}