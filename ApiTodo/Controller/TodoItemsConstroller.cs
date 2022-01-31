using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiTodo.Models;
using TodoApi.Models;
using ApiTodo.Servicos;
using Spx.Adm.Todo.Adapters.Interfaces;

namespace ApiTodo.Controller
{
    [ApiController]
    [Route("Api/v1/[Controller]")]

    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContextEntidade _context;
        private readonly ITodoServico TodoServico;
        private readonly IAdapter TodoAdapter;
       

        public TodoItemsController(TodoContextEntidade context, ITodoServico todoServico, IAdapter adapter)
        {
            _context = context;
            TodoServico = todoServico;
            TodoAdapter = adapter;
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

        
        [HttpGet("ObterJson/{id}")]
        public ActionResult<IEnumerable<TodoItem>> GetObterJson([FromRoute] long id)
        {
            var resumo = TodoAdapter.ToJson(id);
            return Ok(resumo);
        }

    }
}