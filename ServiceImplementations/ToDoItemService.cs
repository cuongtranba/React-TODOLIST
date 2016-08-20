using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain.Model;
using LiteDB;
using ServiceInterfaces;

namespace ServiceImplementations
{
    public class ToDoItemService : BaseService<ToDoItem, Guid>, IToDoItemService
    {
        public ToDoItemService(LiteDatabase liteDatabase) : base(liteDatabase)
        {

        }

        public async Task InsertAsyncToDoItem(ToDoItem toDoItem)
        {
            throw new NotImplementedException();
        }

        public List<ToDoItem> GetAllToDoItem()
        {
            var model = this.collection.FindAll().OrderByDescending(c => c.CreateTime.Date).ThenBy(c => c.CreateTime.TimeOfDay).ToList();
            return model;
        }

        public void MarkAllDone()
        {
            var allItems = this.collection.Find(c => c.IsActive).ToList();
            if (allItems.Any())
            {
                foreach (var toDoItem in allItems)
                {
                    toDoItem.IsActive = false;
                }
                this.collection.Update(allItems);
            }
        }

        public void MarkTodoDone(Guid id)
        {
            var item = this.collection.FindOne(c => c.Id == id);
            if (item != null)
            {
                item.IsActive = false;
                this.collection.Update(item);
            }
        }
    }
}
