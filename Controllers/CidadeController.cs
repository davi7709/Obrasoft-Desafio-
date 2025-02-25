using Microsoft.AspNetCore.Mvc;
using Obrasoft.Models;
using Obrasoft.Repositories;

namespace Obrasoft.Controllers
{
    public class CidadeController : Controller
    {
        private readonly ICidadeRepository _cidadeRepository;

        public CidadeController(ICidadeRepository cidadeRepository)
        {
            _cidadeRepository = cidadeRepository;
        }

        [HttpGet]
        public IActionResult GetCidadeEstado(int estadoId) 
        {
            List<Cidade> cidades = _cidadeRepository.GetCidadeEstado(estadoId);
            return Json(cidades);
        }
    }
}
