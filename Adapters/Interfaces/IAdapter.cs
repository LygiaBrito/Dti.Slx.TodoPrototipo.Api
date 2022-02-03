using System;

namespace Spx.Adm.Todo.Adapters.Interfaces
{
    public interface IAdapter
    {
        public void Adapt();

        public String ToJson();
    }
}
