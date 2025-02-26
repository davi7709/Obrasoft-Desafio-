using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Obrasoft.Models;
using Obrasoft.Repositories;

namespace Obrasoft.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteRepository _clienteRepository;
        public ClienteController(IClienteRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }
        public IActionResult Index()
        {
            List<Cliente> clientes = _clienteRepository.ObterTodos();
            return View(clientes);
        }

        public IActionResult Criar()
        {
            return View();
        }

        public IActionResult Editar(int id)
        {
            var cliente = _clienteRepository.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return View(cliente);
        }

        [HttpPost]
        public IActionResult Editar(Cliente cliente)
        {
            bool atualizado = _clienteRepository.Editar(cliente);
            if (!atualizado)
            {
                return NotFound("Erro ao atualizar o cliente.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult ExcluirConfirmacao()
        {
            return View();
        }

        public IActionResult Excluir()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Criar(Cliente cliente)
        {
            _clienteRepository.Adicionar(cliente);
            return RedirectToAction("Index");
        }

    }
}
