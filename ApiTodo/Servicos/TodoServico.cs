using System;
using System.Collections.Generic;
using System.Linq;
using ApiTodo.Models;

namespace ApiTodo.Servicos
{
    public class Todo
    {
        List<TodoItemEntiddade> TaskList;

        //Construtor
        public Todo() 
        {
            TaskList = new List<TodoItemEntiddade>();
        }

        //Metodo Adicionar
        public bool Adicionar(TodoItemEntiddade todoItem)
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
        public List<TodoItemEntiddade> ListarTodos()
        {
            return TaskList;
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
