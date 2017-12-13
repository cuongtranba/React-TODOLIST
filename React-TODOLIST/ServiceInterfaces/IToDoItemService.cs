using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Model;

namespace ServiceInterfaces
{
    public interface IToDoItemService:IService<ToDoItem,Guid>
    {
        List<ToDoItem> GetAllToDoItem();
        void MarkAllDone();
        void MarkTodoDone(Guid id);
        void DeActiveTaskWhenExpired(int expiredTime);
        List<ToDoItem> GetExpiredItems();
    }
}
