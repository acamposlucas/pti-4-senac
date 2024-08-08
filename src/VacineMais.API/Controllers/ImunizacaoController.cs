using Microsoft.AspNetCore.Mvc;
using VacineMais.API.DTOs.Imunizacao;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Controllers
{
    [ApiController]
    [Route("/api/[controller]")]
    public class ImunizacaoController : ControllerBase
    {
        private readonly IImunizacaoService _imunizacaoService;

        public ImunizacaoController(IImunizacaoService imunizacaoService)
        {
            _imunizacaoService = imunizacaoService;
        }

        [HttpGet]
        [Route("{membroId:int}")]
        public async Task<ActionResult<List<GetImunizacaoDTO>>> ListarPorMembro(int membroId)
        {
            var result = await _imunizacaoService.ListarPorMembro(membroId);

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<GetImunizacaoDTO>> Inserir(CreateImunizacaoDTO createImunizacaoDTO)
        {
            var result = await _imunizacaoService.Inserir(createImunizacaoDTO);

            if (result is null)
            {
                return BadRequest("Não foi possível inserir imunização.");
            }

            return Ok(result);
        }

        [HttpPut]
        public async Task<ActionResult<GetImunizacaoDTO>> Atualizar(UpdateImunizacaoDTO updateImunizacaoDTO)
        {
            if (updateImunizacaoDTO.Id == 0 || updateImunizacaoDTO is null)
            {
                return BadRequest();
            }

            var result = await _imunizacaoService.Atualizar(updateImunizacaoDTO);

            if (result is null)
            {
                return BadRequest("Não foi possível inserir imunização.");
            }

            return Ok(result);
        }

        [HttpDelete]
        [Route("{imunizacaoId:int}")]
        public async Task<ActionResult> Deletar(int imunizacaoId)
        {
            if (imunizacaoId == 0)
            {
                return BadRequest();
            }

            var result = await _imunizacaoService.Deletar(imunizacaoId);

            if (!result)
            {
                return BadRequest();
            }

            return NoContent();
        }
    }
}
