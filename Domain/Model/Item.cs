using System;

namespace Domain.Model
{
    public class ToDoItem:BaseModel
    {
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
