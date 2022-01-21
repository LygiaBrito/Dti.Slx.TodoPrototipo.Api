using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTodo.Models;
using TodoApi.Models;
using static ApiTodo.Models.TodoItem;

namespace ApiTodo.UseCases
{
    public class Todo
    {
        List<TodoItem> TaskList;

        //Construtor
        public Todo() 
        {
            TaskList = new List<TodoItem>();
        }

        //Metodo Adicionar
        public bool Adicionar(TodoItem todoItem)
        {
            
            if (todoItem != null)
            {
                if (todoItem.Name.Count() >= 5)
                {
                    if (todoItem.Description.Count() >= 5)
                    {
                        TaskList.Add(todoItem);
                        return true;
                    }
                }
            }
            return false;
        }

        //Metodo Listar Todas as Atividades
        public List<TodoItem> ListarTodos()
        {
            return TaskList;
        }

        //Metodo excluir
        public bool Exluir(TodoItem todoItem)
        {
            for (int i = 0; i < todoItem.Id; i++)
            {
                TaskList.Remove(todoItem);
                return true;
            }
            return false;
        }

        //Metodo  Duplicar
        public bool Duplicar(long id)
        {
            var todoItem = TaskList?.Where(x => x.Id.Equals(id))?.FirstOrDefault();
            TaskList.Add(todoItem);
            return true;
        }

        //Metodo Concluir
        public bool Concluir(long id)
        {
            var todoItem = TaskList.Where(x => x.Id.Equals(id)).FirstOrDefault();
            todoItem.DataConclusao = DateTime.Now;
            todoItem.IsComplete = true;
            return true;
        }
    }
}
