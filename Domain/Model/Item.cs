using System;

namespace Domain.Model
{
    public class ToDoItem:BaseModel<int>
    {
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
