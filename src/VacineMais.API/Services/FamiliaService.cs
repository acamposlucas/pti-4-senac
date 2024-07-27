using Microsoft.EntityFrameworkCore;
using VacineMais.API.Data;
using VacineMais.API.DTOs.Familia;
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

        public Task<GetFamiliaDTO> Buscar(int familiaId)
        {
            throw new NotImplementedException();
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
                Membros = familia.Membros,
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
