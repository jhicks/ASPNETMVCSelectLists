using System.Web.Mvc;
using SelectLists.Models;

namespace SelectLists.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HomeModel form)
        {
            // ... validation failed
            return View(form);
        }
    }
}
