using System;

namespace Domain.Model
{
    public class ToDoItem : BaseModel<Guid>
    {
        public string Name { get; set; }
        public DateTime CreateTime { get; set; }
        public string Description { get; set; }
        public bool IsActive { get; set; }

        public ToDoItem()
        {
            this.Id = Guid.NewGuid();
            IsActive = true;
            CreateTime = DateTime.Now;
        }
    }
}
