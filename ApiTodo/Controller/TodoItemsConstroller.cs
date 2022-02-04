using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Spx.Adm.Todo.Items;
using Spx.Adm.Todo.Servicos.Interfaces;
using Spx.Adm.TodoContexts;

namespace Spx.Adm.Todo.Controllers
{
    [ApiController]
    [Route("Api/v1/[Controller]")]

    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContextEntidade _context;
        private readonly ITodoItemsServico TodoServico;


        public TodoItemsController(TodoContextEntidade context, ITodoItemsServico todoServico)
        {
            _context = context;
            TodoServico = todoServico;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] TodoItem todoItem)
        {
            var resultado = TodoServico.Adicionar(todoItem);
            return Ok($"Success: {resultado}");
        }

        [HttpGet("Consultar")]
        public ActionResult<IEnumerable<TodoItem>> GetTodoItems()
        {
            var lista = TodoServico.ListarTodos();
            return Ok(lista);
        }

        [HttpPost("Duplicar/{id}")]
        public IActionResult Duplicar(long id)
        {
            var resultado = TodoServico.Duplicar(id);
            return Ok($"Success: {resultado}");
        }

        [HttpPut("Concluir/{id}")]
        public IActionResult Concluir(long id)
        {
            var resultado = TodoServico.Concluir(id);
            return Ok($"Success: {resultado}");
        }


        [HttpGet("ObterJson")]
        public ActionResult<IEnumerable<TodoItem>> GetTodoAdapters()
        {
            var Resumo = TodoServico.Resumo();
            return Ok(Resumo);
        }
    }
}