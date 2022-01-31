using ApiTodo.Models;
using ApiTodo.Servicos;
using Newtonsoft.Json;
using Spx.Adm.Todo.Adapters.Interfaces;
namespace Spx.Adm.Todo.Adapters 
{
    public class TodoAdapter : IAdapter

    {
        private string _todoJson;
        private ITodoServico todoServico;

        public TodoAdapter(ITodoServico todoServico)
        {
            this.todoServico = todoServico;
        }

        public string ToJson(long id)
        {
            TodoItem tudoItemBusca = todoServico.Buscar(id);
            
            this._todoJson = $" {id}, {tudoItemBusca.Name}, {tudoItemBusca.Description}, {tudoItemBusca.IsComplete}";
            var objeto = new
            {
                json = this._todoJson
            };
            
            return JsonConvert.SerializeObject(objeto);
        }

    }
}
