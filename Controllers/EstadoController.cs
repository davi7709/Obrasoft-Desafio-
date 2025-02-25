using Microsoft.AspNetCore.Mvc;
using Obrasoft.Models;
using Obrasoft.Repositories;

namespace Obrasoft.Controllers
{
    public class EstadoController : Controller
    {
        private readonly IEstadoRepository _estadoRepository;

        public EstadoController(IEstadoRepository estadoRepository)
        {
            _estadoRepository = estadoRepository;
        }
        [HttpGet]
        public IActionResult GetEstado()
        {
            List<Estado> estados= _estadoRepository.GetEstado().ToList();
            return Json(estados);
        }

    }
}
