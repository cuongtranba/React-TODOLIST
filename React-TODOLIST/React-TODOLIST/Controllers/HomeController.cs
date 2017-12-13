using System;
using System.Linq;
using System.Web.Mvc;
using Domain.Model;
using ServiceInterfaces;

namespace React_TODOLIST.Controllers
{
    public class HomeController : Controller
    {
        private readonly IToDoItemService _toDoItemService;

        public HomeController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public ActionResult Index()
        {
            return View(_toDoItemService.GetAllToDoItem());
        }

        public ActionResult GetToDo()
        {
            return Json(_toDoItemService.GetAllToDoItem(),JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult ExpiredItems()
        {
            return Json(_toDoItemService.GetExpiredItems(), JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult AddToDo(ToDoItem model)
        {
            _toDoItemService.Insert(model);
            return Json(new { success = true, data = model }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MarkAllDone()
        {
            _toDoItemService.MarkAllDone();
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult MarkTodoDone(Guid id)
        {
            _toDoItemService.MarkTodoDone(id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteItem(Guid id)
        {
            _toDoItemService.Delete(id);
            return Json(new { success = true }, JsonRequestBehavior.AllowGet);
        }
    }
}