using Microsoft.EntityFrameworkCore;
using VacineMais.API.Data;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Services
{
    public class DoseService : IDoseService
    {
        private readonly AppDbContext _context;

        public DoseService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<List<Dose>> Buscar(string descricaoOuSigla)
        {
            var result = new List<Dose>();

            result = await _context.Dose
                .Where(x => x.Descricao.ToLower().Contains(descricaoOuSigla) || x.Sigla.ToLower().Contains(descricaoOuSigla))
                .OrderBy(x => x.Codigo)
                .ToListAsync();

            return result;
        }

        public async Task<List<Dose>> Listar()
        {
            var result = new List<Dose>();

            result = await _context.Dose.ToListAsync();

            return result;
        }
    }
}
