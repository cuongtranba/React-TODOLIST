using Domain.Model;

namespace ServiceInterfaces
{
    public interface IToDoItemService
    {
        void InsertAsyncToDoItem(ToDoItem toDoItem);
    }
}
