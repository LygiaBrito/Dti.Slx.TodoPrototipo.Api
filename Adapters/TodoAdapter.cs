using Newtonsoft.Json;
using Spx.Adm.Todo.Adapters.Interfaces;
using Spx.Adm.Todo.Items;

namespace Spx.Adm.Todo.Adapters
{
    public class TodoAdapter : TodoItem, IAdapter
    {
        private string _todoJson { get; set; }

        public TodoAdapter(long id, string name, string description, bool isComplete)
        {
            this.Id = id;
            this.Name = name;
            this.Description = description;
            this.IsComplete = isComplete;
            this.Adapt();
        }

        public void Adapt()
        {  
            this._todoJson = $" {this.Id}, {this.Name}, {this.Description}, {this.IsComplete}";
        }

        public string ToJson()
        {
            var objeto = new
            {
                json = this._todoJson
            };

            return JsonConvert.SerializeObject(objeto);
        }
    }
}