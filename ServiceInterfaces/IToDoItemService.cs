using System.Threading.Tasks;
using Domain.Model;

namespace ServiceInterfaces
{
    public interface IToDoItemService:IService<ToDoItem,int>
    {
        Task InsertAsyncToDoItem(ToDoItem toDoItem);
    }
}
