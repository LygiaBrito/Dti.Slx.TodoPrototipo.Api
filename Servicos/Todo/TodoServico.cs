
using Spx.Adm.Todo.Adapters;
using Spx.Adm.Todo.Items;
using Spx.Adm.Todo.Servicos.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using TodoApi.Validators;

namespace Spx.Adm.Todo.Servicos
{
    public class TodoServico : ITodoItemsServico
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
            var ValidarAdicionar = new TodoItemValidator();
            var resultado = ValidarAdicionar.Validate(todoItem);
            if(resultado.IsValid)
            {
                TaskList.Add(todoItem);
            }
            return resultado.IsValid;
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
            List<string> adapterList = new List<string>();
            foreach (TodoItem item in TaskList)
            {
                var adapter = new TodoAdapter(item.Id, item.Name, item.Description, item.IsComplete);
                adapterList.Add(adapter.ToJson());
            }
            return adapterList; 
        }
    }
}

