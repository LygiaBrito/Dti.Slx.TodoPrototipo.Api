
using Spx.Adm.Todo.Adapters;
using Spx.Adm.Todo.Items;
using Spx.Adm.Todo.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Spx.Adm.Todo.Servicos
{
    public class TodoItemsServico : ITodoItemsServico
    {
        List<TodoItem> TaskList;
        //Construtor
        public TodoItemsServico()  
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

        public List<string> Resumo()
        {
            //var list = this.TaskList.Select(task => JsonConvert.SerializeObject(task)).ToList();
            List<string> adapterList = new List<string>();
            foreach (TodoItem item in TaskList)
            {
                var adapter = new TodoAdapter(item.Id, item.Name, item.Description, item.IsComplete);
                adapter.Adapt();
                adapterList.Add(adapter.ToJson());
            }
            return adapterList; 
        }
    }
}

