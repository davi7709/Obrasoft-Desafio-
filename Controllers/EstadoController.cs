using Microsoft.AspNetCore.Mvc;
using Obrasoft.Models;
using Obrasoft.Repositories;
using Obrasoft.Service;

namespace Obrasoft.Controllers
{
    public class EstadoController : Controller
    {
        private readonly IEstadoService _estadoService;

        public EstadoController(IEstadoService estadoService)
        {
            _estadoService = estadoService;
        }
        [HttpGet]
        public async Task<IActionResult> GetEstado()
        {
            List<Estado> estados = await _estadoService.GetEstado();
            return Json(estados);
        }

    }
}
