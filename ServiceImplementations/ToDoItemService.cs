using System;
using System.Collections.Generic;
using System.Configuration;
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

        public void DeActiveTaskWhenExpired(int expiredTime)
        {
            var activeItems = this.collection.Find(c => c.IsActive).ToList();
            var updateItems=new List<ToDoItem>();
            if (activeItems.Any())
            {
                foreach (var activeItem in activeItems)
                {
                    var value = activeItem.CreateTime.AddSeconds(expiredTime);
                    if (value <= DateTime.Now)
                    {
                        activeItem.IsActive = false;
                        updateItems.Add(activeItem);
                    }
                }
            }
            if (updateItems.Any())
            {
                this.collection.Update(updateItems);
            }
        }
    }
}
