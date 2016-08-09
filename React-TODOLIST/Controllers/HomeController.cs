using System;
using System.Web.Mvc;
using Domain.Model;
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
            var model=new ToDoItem()
            {
                CreateTime = DateTime.Now,
                Description = "test01",
                Name = "test01"
            };
            _toDoItemService.Insert(model);
            return View();
        }
    }
}