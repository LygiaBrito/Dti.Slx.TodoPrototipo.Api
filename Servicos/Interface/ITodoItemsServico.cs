using Spx.Adm.Todo.Items;
using System.Collections.Generic;

namespace Spx.Adm.Todo.Servicos.Interfaces
{ 
    public interface ITodoItemsServico
    {
        public bool Adicionar(TodoItem todoItem);

        public List<TodoItem> ListarTodos();

        public bool Duplicar(long id);

        public bool Concluir(long id);

        public List<string> Resumo();
    }
}
