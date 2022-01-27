using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using ApiTodo.Models;
using TodoApi.Models;
using ApiTodo.Servicos;
using Entidades;

namespace ApiTodo.Controller
{
    [ApiController]
    [Route("Api/v1/[Controller]")]

    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly ITodoServico TodoServico;

        public TodoItemsController(TodoContext context, ITodoServico todoServico)
        {
            _context = context;
            TodoServico = todoServico;
        }

        [HttpPost("TodoItem")]
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

        [HttpGet("{id}")]
        public IActionResult GetResult([FromRoute]long id, [FromQuery] bool isResumo)
        {
            return Ok();
        }
                   
            
          
        

    
    }
}