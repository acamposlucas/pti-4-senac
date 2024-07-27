using Microsoft.EntityFrameworkCore;
using VacineMais.API.Data;
using VacineMais.API.DTOs.Familia;
using VacineMais.API.DTOs.Membro;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Services
{
    public class FamiliaService : IFamiliaService
    {
        private readonly AppDbContext _context;

        public FamiliaService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetFamiliaDTO> Buscar(int familiaId)
        {
            Familia familia = await _context.Familia
                .Include(f => f.Membros)
                .FirstOrDefaultAsync(x => x.Id == familiaId);

            if (familia is null)
            {
                return null;
            }

            var result = new GetFamiliaDTO
            {
                FamiliaId = familia.Id,
                Membros = familia.Membros
                    .Select(m => new GetMembroDTO { Id = m.Id, Nome = m.Nome, DataNascimento = m.DataNascimento, FamiliaId = m.FamiliaId }).ToList(),
                UsuarioId = familia.UsuarioId,
            };

            return result;
        }

        public async Task<GetFamiliaDTO> Inserir(CreateFamiliaDto createFamiliaDto)
        {
            Familia familia = new Familia
            {
                UsuarioId = createFamiliaDto.UsuarioId
            };
            _context.Familia.Add(familia);
            await _context.SaveChangesAsync();

            var familiaDb = await _context.Familia
                .Include(f => f.Membros)
                .FirstOrDefaultAsync(x => x.Id == familia.Id);

            GetFamiliaDTO result = new GetFamiliaDTO
            {
                FamiliaId = familia.Id,
                Membros = familia.Membros
                    .Select(m => new GetMembroDTO { Id = m.Id, Nome = m.Nome, DataNascimento = m.DataNascimento, FamiliaId = m.FamiliaId }).ToList(),
                UsuarioId = familia.UsuarioId
            };

            return result;
        }

        public Task<List<GetFamiliaDTO>> Listar()
        {
            throw new NotImplementedException();
        }
    }
}
