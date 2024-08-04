using Microsoft.AspNetCore.Mvc;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DoseController
    {
        private IDoseService _doseService { get; set; }

        public DoseController(IDoseService doseService)
        {
            _doseService = doseService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Dose>>> Listar([FromQuery] string? descricaoOuSigla)
        {
            if (!string.IsNullOrEmpty(descricaoOuSigla))
            {
                return await _doseService.Buscar(descricaoOuSigla.ToLower());
            }
            return await _doseService.Listar();
        }
    }
}
