using Domain.Model;
using ServiceInterfaces;
namespace ServiceImplementations
{
    public class ToDoItemService: BaseService<ToDoItem, int>, IToDoItemService
    {
        public void InsertAsyncToDoItem(ToDoItem toDoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
