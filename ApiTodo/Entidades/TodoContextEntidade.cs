﻿
using ApiTodo.Models;
using Microsoft.EntityFrameworkCore;

    namespace TodoApi.Models
    {
        public class TodoContextEntidade : DbContext
        {
            public TodoContextEntidade(DbContextOptions<TodoContextEntidade> options)
                : base(options)
            {
            }
            public DbSet<TodoItemEntiddade> TodoItems { get; set; }
        }
    }