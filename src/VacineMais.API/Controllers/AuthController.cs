using Microsoft.AspNetCore.Mvc;
using VacineMais.API.DTOs.Auth;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("cadastrar")]
        public async Task<IActionResult> Cadastrar(CadastroDto dto)
        {
            if (await VerificaUsername(dto.Username))
            {
                return BadRequest("Já existe registro com esse usuário");
            }

            var result = _authService.Cadastrar(dto);
            return Ok(result);
        }

        [HttpPost("login")]
        public async Task<ActionResult<UsuarioLogadoDto>> Login(LoginDto dto)
        {
            var result = await _authService.Login(dto);
            if (result is null)
            {
                return BadRequest("Credenciais inválidas");
            }

            return Ok(result);
        }

        [HttpDelete("inativar")]
        public async Task<ActionResult> InativarUsuarioPorUsername([FromBody] InativarLoginDto dto)
        {
            if (dto.Username == null)
            {
                return BadRequest();
            }

            var result = await _authService.InativarUsuarioPorUsername(dto.Username);

            if (!result.Sucesso)
            {
                return BadRequest(result.Mensagem);
            }

            return Ok(result.Mensagem);
        }

        private async Task<bool> VerificaUsername(string username)
        {
            return await _authService.VerificaUsername(username);
        }
    }

}
