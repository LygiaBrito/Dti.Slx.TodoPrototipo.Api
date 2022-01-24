using System;

namespace ApiTodo.Models
{
    public class TodoItemEntiddade
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; } 
        public bool IsComplete { get; set; }
        public DateTime DataConclusao { get; set; }

        internal void Remove(TodoItemEntiddade todoItem)
        {
            throw new NotImplementedException();
        }

        internal bool IsNullOrEmpty(object text)
        {
            throw new NotImplementedException();
        }
    }
}
