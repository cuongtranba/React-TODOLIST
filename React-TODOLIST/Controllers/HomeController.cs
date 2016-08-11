using System.Web.Mvc;
using ServiceInterfaces;

namespace React_TODOLIST.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private IToDoItemService _toDoItemService;

        public HomeController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public ActionResult Index()
        {
            return View(_toDoItemService.GetAllToDoItem());
        }
    }
}