using System;

namespace Domain.Model
{
    public class ToDoItem:BaseModel<int>
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }
    }
}
