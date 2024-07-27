using Microsoft.AspNetCore.Mvc;
using VacineMais.API.DTOs.Membro;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MembroController : ControllerBase
    {
        private readonly IMembroService _membroService;

        public MembroController(IMembroService membroService)
        {
            _membroService = membroService;
        }

        [HttpPost]
        public async Task<ActionResult<GetMembroDTO>> Inserir(CreateMembroDTO dto)
        {
            var result = await _membroService.Inserir(dto);

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<GetMembroDTO>> Atualizar(UpdateMembroDTO dto)
        {
            if (dto.Id == 0 || dto.Id == null)
            {
                return BadRequest();
            }

            if (await _membroService.Buscar(dto.Id) == null)
            {
                return BadRequest("Membro não encontrado");
            }

            var result = await _membroService.Update(dto);

            return Ok(result);
        }

        [HttpDelete]
        [Route("{id:int}")]
        public async Task<ActionResult> Deletar([FromRoute] int id)
        {
            if (id == 0 || id == null)
            {
                return BadRequest();
            }

            if (await _membroService.Buscar(id) == null)
            {
                return BadRequest("Membro não encontrado");
            }

            var result = await _membroService.Deletar(id);

            return NoContent();
        }
    }
}
