using System.Diagnostics.CodeAnalysis;
using Microsoft.AspNetCore.Mvc;
using Obrasoft.Models;
using Obrasoft.Service;

namespace Obrasoft.Controllers
{
    public class ClienteController : Controller
    {
        private readonly IClienteService _clienteService;
        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }
        public async Task<IActionResult> Index()
        {
            List<Cliente> clientes = await _clienteService.ListarTodos();
            return View(clientes);
        }

        public async Task<IActionResult> Editar(int id)
        {
            var cliente = await _clienteService.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Editar(Cliente cliente)
        {
            bool atualizado = await _clienteService.Editar(cliente);
            if (!atualizado)
            {
                return NotFound("Erro ao atualizar o cliente.");
            }
            return RedirectToAction("Index");
        }

        public IActionResult Criar()
        {
            return View();
        }

        public async Task<IActionResult> ExcluirConfirmacao(int id)
        {
            var cliente = await _clienteService.ObterPorId(id);
            if (cliente == null)
            {
                return NotFound("Cliente não encontrado.");
            }
            return View(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> Excluir(int id)
        {
            bool excluido = await _clienteService.Deletar(id);

            if (!excluido)
            {
                return NotFound("Erro ao excluir cliente.");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Criar(Cliente cliente)
        {
            await _clienteService.Adicionar(cliente);
            return RedirectToAction("Index");
        }

    }
}
