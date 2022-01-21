using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ApiTodo.Models;
using TodoApi.Models;
using ApiTodo.UseCases;
using NuGet;
using System.Text;

namespace ApiTodo.Controller
{
    [ApiController]
    [Route("Api/[Controller]")]

    public class TodoItemsController : ControllerBase
    {
        private readonly TodoContext _context;
        private readonly Todo _service;

        public TodoItemsController(TodoContext context, Todo todo)
        {
            _context = context;
            _service = todo;
        }

        [HttpPost("Cadastrar")]
        public IActionResult Cadastrar([FromBody] TodoItem todoItem)
        {
            var resultado = _service.Adicionar(todoItem);
            return Ok($"Success: {resultado}");
        }

        [HttpGet("Consultar")]
        public async Task<ActionResult<IEnumerable<TodoItem>>> GetTodoItems()
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

        //[HttpDelete("Excluir/{id}")]
        //public IActionResult Excluir(long id)
        //{
        //    var resultado = _service.Exluir(id);
        //    return Ok($"Success: {resultado}");
        //}
    }
}