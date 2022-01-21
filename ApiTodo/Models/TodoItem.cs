using System;

namespace ApiTodo.Models
{
    public class TodoItem
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public bool IsComplete { get; set; }
        public DateTime DataConclusao { get; set; }

        internal void Remove(TodoItem todoItem)
        {
            throw new NotImplementedException();
        }
    }
}
