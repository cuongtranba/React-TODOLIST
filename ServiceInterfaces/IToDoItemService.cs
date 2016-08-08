using Domain.Model;

namespace ServiceInterfaces
{
    public interface IToDoItemService:IService<ToDoItem,int>
    {
        void InsertAsyncToDoItem(ToDoItem toDoItem);
    }
}
