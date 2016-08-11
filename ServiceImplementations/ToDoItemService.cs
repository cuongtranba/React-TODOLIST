using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using LiteDB;
using ServiceInterfaces;
namespace ServiceImplementations
{
    public class ToDoItemService: BaseService<ToDoItem, Guid>, IToDoItemService
    {
        public ToDoItemService(LiteDatabase liteDatabase) : base(liteDatabase)
        {

        }

        public async Task InsertAsyncToDoItem(ToDoItem toDoItem)
        {
            throw new System.NotImplementedException();
        }

        public List<ToDoItem> GetAllToDoItem()
        {
            return this.collection.FindAll().ToList();
        }
    }
}
