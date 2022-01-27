using ApiTodo.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entidades
{
    public class ResumoServico
    {
        public TodoResumo Obter(TodoItem todoItem)
        {
            TodoResumo resumo = new TodoResumo();
            resumo.Resumo = $" Possui dados - {todoItem.Id}, {todoItem.Name}, {todoItem.Description}, {todoItem.IsComplete}, {todoItem.DataConclusao}";
            return resumo;
        }

    }
}

