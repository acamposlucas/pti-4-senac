using VacineMais.API.DTOs.Auth;

namespace VacineMais.API.Services.Interfaces
{
    public interface IAuthService
    {
        Task<bool> Cadastrar(CadastroDto dto);
        Task<bool> Login(LoginDto dto);
        Task<bool> VerificaUsername(string username);
    }
}
