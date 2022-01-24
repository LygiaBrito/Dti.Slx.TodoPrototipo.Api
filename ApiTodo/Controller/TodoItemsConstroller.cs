using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiTodo.Models;
using TodoApi.Models;
using ApiTodo.Servicos;


namespace ApiTodo.Controller
{
    [ApiController]
    [Route("Api/[Controller]")]

    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContextEntidade _context;
        private readonly Todo _service;

        public TodoItemsController(TodoContextEntidade context, Todo todo)
        {
            _context = context;
            _service = todo;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] TodoItemEntiddade todoItem)
        {
            var resultado = _service.Adicionar(todoItem);
            return Ok($"Success: {resultado}");
        }

        [HttpGet("Consultar")]
        public ActionResult<IEnumerable<TodoItemEntiddade>> GetTodoItems()
        {
            var lista = _service.ListarTodos();
            return Ok(lista);
        }

        [HttpPost("Duplicar/{id}")]
        public IActionResult Duplicar(long id)
        {
            var resultado = _service.Duplicar(id);
            return Ok($"Success: {resultado}");
        }

        [HttpPut("Concluir/{id}")]
        public IActionResult Concluir(long id)
        {
            var resultado = _service.Concluir(id);
            return Ok($"Success: {resultado}");
        }
    }
}