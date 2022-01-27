
using ApiTodo.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity;
using DbContext = Microsoft.EntityFrameworkCore.DbContext;

namespace TodoApi.Models
    {
        public class TodoContext : DbContext
        {
        public TodoContext(DbContextOptions<TodoContext> options)
                : base(options)
            {
            }
        public Microsoft.EntityFrameworkCore.DbSet<TodoItem> TodoItems { get; set; }
        }
    }