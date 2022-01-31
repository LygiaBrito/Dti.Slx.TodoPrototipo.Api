using ApiTodo.Models;
using System.Collections.Generic;

namespace ApiTodo.Servicos
{
    public interface ITodoServico
    {
        public bool Adicionar(TodoItem todoItem);

        public List<TodoItem> ListarTodos();

        public bool Duplicar(long id);

        public bool Concluir(long id);

        public TodoItem Buscar(long id);

    }
}
