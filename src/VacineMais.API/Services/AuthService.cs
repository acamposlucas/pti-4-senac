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

        public async Task<bool> Login(LoginDto dto)
        {
            var usuario = await _context.Usuarios.SingleOrDefaultAsync(u => u.Username == dto.Username);

            if (usuario == null || usuario.PasswordHash != HashPassword(dto.Password))
            {
                return false;
            }

            return true;
        }

        public async Task<bool> VerificaUsername(string username)
        {
            var result = await _context.Usuarios.AnyAsync(u => u.Username == username);
            return result;
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
