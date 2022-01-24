using System;
using NUnit.Framework;
using ApiTodo.UseCases;
using ApiTodo.Models;

namespace TodoApi.Test
{
    public class Tests
    {
        [Test]
        public void AdicionarNovaTask() //Este metodo testa o cadastro e listagem por quantidade de itens na lista.
        {
            //Objetos instanciados para que fossem acessados localmente.
            var todo = new Todo();
            var todoItem = new TodoItemEntiddade()
            //Parametros para instanciar o objeto todoItem.
            {
                DataConclusao = DateTime.Now,
                Description = "Minha Descrição teste",
                Id = 1,
                IsComplete = false,
                Name = "Teste"
            };
            //O medoto Adicionar esta recebendo os parametros para que possa executado, ou seja para adicionar a atividade a lista.
            todo.Adicionar(todoItem);
            //A variavel ListaDeTarefas esta recebendo o valor retornado pelo metodo listarTodos, para que possamos ter acesso a lista para as verificacoes abaixo.
            var listaDeTarefas = todo.ListarTodos();

            //Compara se o esperado(de quantidade de intens, ou seja 1) e igual a da lista, representada pela variavel listaDeTarefas
            Assert.AreEqual(1, listaDeTarefas.Count);
            //Compara se o campo esperado(de descricao) e igual a da lista, representada pela variavel listaDeTarefas(consta tambem a posicao na lista
            Assert.AreEqual("Minha Descrição teste", listaDeTarefas[0].Description);
        }



        [Test]
        public void AcicionarTaskComDescricaoMenorQue5()
        {
            //Objetos instanciados para que fossem acessados localmente.
            var todo = new Todo();
            var todoItem = new TodoItemEntiddade()
            //Parametros para instanciar o objeto todoItem.
            {
                DataConclusao = DateTime.Now,
                Description = "Fail",
                Id = 1,
                IsComplete = false,
                Name = "Teste"
            };
            //A variavel isAdded recebe o valor retornado pelo metodo adicionar.
            var isAdded = todo.Adicionar(todoItem);
            //Comparando se o retorno do metodo adicionar/isAdded e false
            Assert.IsFalse(isAdded);
        }



        [Test]
        public void AcicionarTaskComNameMenorQue5()
        {
            //Objetos instanciados para que fossem acessados localmente.
            var todo = new Todo();
            var todoItem = new TodoItemEntiddade()
            //Parametros para instanciar o objeto todoItem.
            {
                DataConclusao = DateTime.Now,
                Description = "Minha Descrição teste",
                Id = 1,
                IsComplete = false,
                Name = "Fail"
            };
            //A variavel isAdded recebe o valor retornado pelo metodo adicionar.
            var isAdded = todo.Adicionar(todoItem);
            //Comparando se o retorno do metodo adicionar/isAdded e false
            Assert.IsFalse(isAdded);
        }

        [Test]
        public void AcicionarTaskNull()
        {
            //Objetos instanciados para que fossem acessados localmente.
            var todo = new Todo();
            //A variavel isAdded o valor retornado pelo metodo adicionar.
            var isAdded = todo.Adicionar(null);
            //Comparando se o retorno do metodo adicionar/isAdded e igual a false(primeiro parametro) 
            Assert.AreEqual(false, isAdded);
        }


        [Test]
        public void DuplicarTaskId()
        {
            //Objetos instanciados para que fossem acessados localmente.
            var todo = new Todo();
            var todoItem = new TodoItemEntiddade()
            //Parametros para instanciar o objeto todoItem.
            {
                DataConclusao = DateTime.Now,
                Description = "Minha Descrição teste",
                Id = 1,
                IsComplete = false,
                Name = "Teste"
            };
            //A variavel isAdded o valor retornado pelo metodo adicionar.
            var isAdded = todo.Adicionar(todoItem);

            bool NovaLista = todo.Duplicar(1);
            var listaDeTarefas = todo.ListarTodos();
            //Comparando se o retorno do metodo adicionar/isAdded e igual a false(primeiro parametro) 
            Assert.AreEqual(2, listaDeTarefas.Count);
        }
    }
}



//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using TodoApi;

//namespace Testes
//{
//    [TestClass]
//    public class BankAccountTests
//    {
//        [TestMethod]
//        public void TestMethod1()
//        {
//        }
//    }
//}