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
        public async Task<IActionResult> Login(LoginDto dto)
        {
            if (!await _authService.Login(dto))
            {
                return BadRequest("Credenciais inválidas");
            }

            return Ok();
        }

        private async Task<bool> VerificaUsername(string username)
        {
            return await _authService.VerificaUsername(username);
        }
    }

}
