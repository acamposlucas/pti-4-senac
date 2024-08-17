using VacineMais.API.DTOs.Auth;
using VacineMais.API.DTOs.Familia;

namespace VacineMais.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<UsuarioLogadoDto> Cadastrar(CadastroDto dto);
        Task<UsuarioLogadoDto> Login(LoginDto dto);
        Task<bool> VerificaUsername(string username);
        Task<(bool Sucesso, string Mensagem)> InativarUsuarioPorUsername(string username);
    }
}
