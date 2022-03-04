using agenda.Models;
using agenda.Repositorio;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace agenda.Controllers
{
    public class ContatoController : Controller
    {
        private readonly IContatoRepositorio _contatoRepositorio;

        public ContatoController(IContatoRepositorio contatoRepositorio)
        {
            _contatoRepositorio = contatoRepositorio;
        }
       
        public IActionResult Index()
        {
           List<ContatoModel> contatos = _contatoRepositorio.BuscarTodos();
            return View(contatos);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);
            return View(contato);
        }

        public IActionResult Apagar(int id)
        {
            ContatoModel contato = _contatoRepositorio.ListarPorId(id);  
            return View(contato);
        }
        public IActionResult ApagarContato(int id)
        {
            _contatoRepositorio.ApagarContato(id);
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Criar(ContatoModel Contato)
        {
            _contatoRepositorio.Adicionar(Contato);
            return RedirectToAction("Index"); 
        }

        [HttpPost]
        public IActionResult Alterar(ContatoModel Contato)
        {
            _contatoRepositorio.Atualizar(Contato);
            return RedirectToAction("Index"); 
        }
    }
}
