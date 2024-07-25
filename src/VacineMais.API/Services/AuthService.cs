using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using VacineMais.API.Data;
using VacineMais.API.DTOs.Auth;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<bool> Cadastrar(CadastroDto dto)
        {
            Usuario usuario = new()
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<UsuarioLogadoDto> Login(LoginDto dto)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Username == dto.Username);

            if (usuario == null 
                || usuario.PasswordHash != HashPassword(dto.Password)
                || !usuario.Ativo)
            {
                return null;
            }

            return new() { Id = usuario.Id, Username = usuario.Username, Email = usuario.Email };
        }

        public async Task<(bool, string)> InativarUsuarioPorUsername(string username)
        {
            var usuario = await GetUsuarioPorUsernameAsync(username);

            if (usuario == null)
            {
                return (false, "Usuário não encontrado");
            }

            usuario.Ativo = false;

            _context.Usuarios.Update(usuario);
            await _context.SaveChangesAsync();
            return (true, "Usuário deletado com sucesso");
        }

        public async Task<bool> VerificaUsername(string username)
        {
            var result = await _context.Usuarios.AnyAsync(u => u.Username == username);
            return result;
        }

        private async Task<Usuario?> GetUsuarioPorUsernameAsync(string username)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Username == username);

            return usuario;
        }

        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
    }
}
