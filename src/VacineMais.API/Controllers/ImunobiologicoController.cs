using Microsoft.AspNetCore.Mvc;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ImunobiologicoController
    {
        private IImunobiologicoService _imunobiologicoService { get; set; }

        public ImunobiologicoController(IImunobiologicoService imunobiologicoService)
        {
            _imunobiologicoService = imunobiologicoService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Imunobiologico>>> Listar([FromQuery] string? descricaoOuSigla)
        {
            if (!string.IsNullOrEmpty(descricaoOuSigla))
            {
                return await _imunobiologicoService.Buscar(descricaoOuSigla.ToLower());
            }
            return await _imunobiologicoService.Listar();
        }
    }
}
