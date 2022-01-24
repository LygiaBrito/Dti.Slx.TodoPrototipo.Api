using ApiTodo.Models;
using System.Collections.Generic;

namespace ApiTodo.Servicos
{
    public interface ITodoServico
    {
        public bool Adicionar(TodoItemEntiddade todoItem);

        public List<TodoItemEntiddade> ListarTodos();

        public bool Duplicar(long id);

        public bool Concluir(long id);

    }
}
