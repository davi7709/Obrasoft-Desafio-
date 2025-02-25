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

        [HttpPut]
        public IActionResult Editar()
        {
            return View();
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
