﻿using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography;
using System.Text;
using VacineMais.API.Data;
using VacineMais.API.DTOs.Auth;
using VacineMais.API.DTOs.Familia;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Services
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;
        private readonly IFamiliaService _familiaService;

        public AuthService(AppDbContext context, IFamiliaService familiaService)
        {
            _context = context;
            _familiaService = familiaService;
        }

        public async Task<UsuarioLogadoDto> Cadastrar(CadastroDto dto)
        {
            Usuario usuario = new()
            {
                Username = dto.Username,
                Email = dto.Email,
                PasswordHash = HashPassword(dto.Password)
            };

            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();
            var familia = await _familiaService.Inserir(new CreateFamiliaDto() { UsuarioId = usuario.Id });

            var result = new UsuarioLogadoDto
            {
                Email = usuario.Email,
                Username = usuario.Username,
                FamiliaId = familia.FamiliaId,
                UsuarioId = usuario.Id
            };

            return result;
        }

        public async Task<UsuarioLogadoDto> Login(LoginDto dto)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Username == dto.Username);

            if (usuario == null
                || usuario.PasswordHash != HashPassword(dto.Password)
                || !usuario.Ativo)
            {
                return null;
            }

            var result = await RetornaUsuarioLogado(usuario.Id);

            return result;
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

        private async Task<UsuarioLogadoDto> RetornaUsuarioLogado(int usuarioId)
        {
            var familia = await _familiaService.BuscarPorUsuarioId(usuarioId);
            var usuario = await _context.Usuarios.FindAsync(usuarioId);

            if (usuario is null || familia is null)
            {
                return null;
            }

            return new UsuarioLogadoDto
            {
                UsuarioId = usuarioId,
                FamiliaId = familia.Id,
                Email = usuario.Email,
                Username = usuario.Username
            };
        }
    }
}
