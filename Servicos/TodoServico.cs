using ApiTodo.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ApiTodo.Servicos
{
    public class TodoServico : ITodoServico
    {
        List<TodoItem> TaskList;

        //Construtor
        public TodoServico()  
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

        public TodoItem Buscar(long id)
        {
            return TaskList.Where(x => x.Id.Equals(id)).FirstOrDefault();
        }
    }
}
