using Microsoft.EntityFrameworkCore;
using VacineMais.API.Data;
using VacineMais.API.DTOs.Membro;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Services
{
    public class MembroService : IMembroService
    {
        private readonly AppDbContext _context;
        private readonly ICarteiraVacinacaoService _carteiraVacinacaoService;

        public MembroService(AppDbContext context, ICarteiraVacinacaoService carteiraVacinacaoService)
        {
            _context = context;
            _carteiraVacinacaoService = carteiraVacinacaoService;
        }

        public async Task<GetMembroDTO> Buscar(int id)
        {
            Membro? membro = await _context.Membro.FirstOrDefaultAsync(x => x.Id == id);

            if (membro is null)
            {
                return null;
            }

            GetMembroDTO result = new GetMembroDTO()
            {
                Id = membro.Id,
                DataNascimento = membro.DataNascimento,
                FamiliaId = membro.FamiliaId,
                Nome = membro.Nome
            };

            return result;
        }

        public async Task<bool> Deletar(int id)
        {
            Membro? membro = await _context.Membro.FirstOrDefaultAsync(x => x.Id == id);

            if (membro is null)
            {
                return false;
            }

            _context.Membro.Remove(membro);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<GetMembroDTO> Inserir(CreateMembroDTO dto)
        {
            Membro membro = new Membro()
            {
                Nome = dto.Nome,
                DataNascimento = dto.DataNascimento,
                FamiliaId = dto.FamiliaId,
            };

            _context.Membro.Add(membro);
            await _context.SaveChangesAsync();
            var cv = await _carteiraVacinacaoService.Inserir(membro);

            return new GetMembroDTO
            {
                Id = membro.Id,
                Nome = membro.Nome,
                DataNascimento = membro.DataNascimento,
                FamiliaId = membro.FamiliaId,
                CarteiraVacinacaoId = cv.CarteiraVacinacaoId
            };
        }

        public async Task<GetMembroDTO> Update(UpdateMembroDTO dto)
        {
            Membro? membro = await _context.Membro.FirstOrDefaultAsync(x => x.Id == dto.Id);

            if (membro is null)
            {
                return null;
            }

            membro.Nome = dto.Nome;
            membro.DataNascimento = dto.DataNascimento;

            _context.Membro.Update(membro);
            await _context.SaveChangesAsync();

            return new GetMembroDTO
            {
                Id = membro.Id,
                Nome = membro.Nome,
                DataNascimento = membro.DataNascimento,
                FamiliaId = membro.FamiliaId
            };
        }
    }
}
