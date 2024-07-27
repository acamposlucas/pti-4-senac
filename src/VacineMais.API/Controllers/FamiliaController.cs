using Microsoft.AspNetCore.Mvc;
using VacineMais.API.DTOs.Familia;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class FamiliaController : ControllerBase
    {
        private readonly IFamiliaService _familiaService;

        public FamiliaController(IFamiliaService familiaService)
        {
            _familiaService = familiaService;
        }

        [HttpGet]
        [Route("{id:int}")]
        public async Task<ActionResult<GetFamiliaDTO>> Buscar([FromRoute] int id)
        {
            var result = await _familiaService.Buscar(id);

            if (result == null) { 
                return BadRequest();
            }

            return Ok(result);
        }
    }
}
