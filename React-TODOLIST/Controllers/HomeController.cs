using System.Web.Mvc;

namespace React_TODOLIST.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home

        public ActionResult Index()
        {
            return View();
        }
    }
}