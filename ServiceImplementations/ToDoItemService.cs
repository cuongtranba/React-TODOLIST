using System.Threading.Tasks;
using Domain.Model;
using LiteDB;
using ServiceInterfaces;
namespace ServiceImplementations
{
    public class ToDoItemService: BaseService<ToDoItem, int>, IToDoItemService
    {
        public ToDoItemService(LiteDatabase liteDatabase) : base(liteDatabase)
        {

        }

        public async Task InsertAsyncToDoItem(ToDoItem toDoItem)
        {
            throw new System.NotImplementedException();
        }
        
    }
}
