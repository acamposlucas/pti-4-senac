using Microsoft.EntityFrameworkCore;
using VacineMais.API.Data;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Services
{
    public class ImunobiologicoService : IImunobiologicoService
    {
        private readonly AppDbContext _context;

        public ImunobiologicoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Imunobiologico>> Buscar(string descricaoOuSigla)
        {
            var result = new List<Imunobiologico>();

            result = await _context.Imunobiologico
                .Where(x => x.Descricao.ToLower().Contains(descricaoOuSigla) || x.Sigla.ToLower().Contains(descricaoOuSigla))
                .OrderBy(x => x.Codigo)
                .ToListAsync();

            return result;
        }

        public async Task<List<Imunobiologico>> Listar()
        {
            var result = new List<Imunobiologico>();

            result = await _context.Imunobiologico.ToListAsync();

            return result;
        }
    }
}
