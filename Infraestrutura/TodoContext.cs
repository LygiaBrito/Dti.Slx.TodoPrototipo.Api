using Microsoft.EntityFrameworkCore;
using Spx.Adm.Todo.Items;

namespace Spx.Adm.TodoContexts
{
    public class TodoContextEntidade : DbContext
    {
        public TodoContextEntidade(DbContextOptions<TodoContextEntidade> options)
            : base(options)
        {
        }
        public DbSet<TodoItem> TodoItems { get; set; }
    }
}