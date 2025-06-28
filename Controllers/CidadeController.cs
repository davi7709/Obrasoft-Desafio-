using Microsoft.AspNetCore.Mvc;
using Obrasoft.Models;
using Obrasoft.Service;

namespace Obrasoft.Controllers
{
    public class CidadeController : Controller
    {
        private readonly ICidadeService _cidadeService;

        public CidadeController(ICidadeService cidadeService)
        {
            _cidadeService = cidadeService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCidadeEstado(int estadoId)
        {
            return Json(await _cidadeService.GetCidadeEstado(estadoId));
        }

        [HttpGet]
        public async Task<IActionResult> GetCidade()
        {
            List<Cidade> cidades = await _cidadeService.GetCidade();

            return Json(cidades);
        }
    }
}
