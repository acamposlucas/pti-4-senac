using Microsoft.AspNetCore.Mvc;
using VacineMais.API.DTOs.CarteiraVacinacao;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CarteiraVacinacaoController : ControllerBase
{
    private readonly ICarteiraVacinacaoService _carteiraVacinacaoService;

    public CarteiraVacinacaoController(ICarteiraVacinacaoService carteiraVacinacaoService)
    {
        _carteiraVacinacaoService = carteiraVacinacaoService;
    }

    [HttpGet]
    [Route("{membroId:int}")]
    public async Task<ActionResult<GetCarteiraVacinacaoDTO>> BuscarPorMembro([FromRoute] int membroId)
    {
        if (membroId == 0)
        {
            return BadRequest();
        }

        var result = await _carteiraVacinacaoService.BuscarPorMembro(membroId);

        if (result is null)
        {
            return BadRequest();
        }

        return Ok(result);
    }
}
