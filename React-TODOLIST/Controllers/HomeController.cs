using System;
using System.Collections.Generic;
using System.Web.Mvc;
using Domain.Model;
using ServiceInterfaces;

namespace React_TODOLIST.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private readonly IToDoItemService _toDoItemService;

        public HomeController(IToDoItemService toDoItemService)
        {
            _toDoItemService = toDoItemService;
        }

        public ActionResult Index()
        {
            return View(_toDoItemService.GetAllToDoItem());
        }

        [HttpPost]
        public ActionResult AddToDo(ToDoItem model)
        {
            _toDoItemService.Insert(model);
            return Json(new { success = true, data = model });
        }

        [HttpPost]
        public ActionResult MarkAllDone()
        {
            _toDoItemService.MarkAllDone();
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult MarkTodoDone(Guid id)
        {
            _toDoItemService.MarkTodoDone(id);
            return Json(new { success = true });
        }

        [HttpPost]
        public ActionResult DeleteItem(Guid id)
        {
            _toDoItemService.Delete(id);
            return Json(new { success = true });
        }
    }
}