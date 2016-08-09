using System.Threading.Tasks;
using Domain.Model;
using ServiceInterfaces;
namespace ServiceImplementations
{
    public class ToDoItemService: BaseService<ToDoItem, int>, IToDoItemService
    {
        public async Task InsertAsyncToDoItem(ToDoItem toDoItem)
        {
            throw new System.NotImplementedException();
        }
    }
}
