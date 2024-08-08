using Microsoft.EntityFrameworkCore;
using VacineMais.API.Data;
using VacineMais.API.DTOs.Imunizacao;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Services
{
    public class ImunizacaoService : IImunizacaoService
    {
        private readonly AppDbContext _context;

        public ImunizacaoService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<GetImunizacaoDTO> Atualizar(UpdateImunizacaoDTO updateImunizacaoDTO)
        {
            Imunizacao? imunizacao = _context.Imunizacao.FirstOrDefault(x => x.Id == updateImunizacaoDTO.Id);

            if (imunizacao is null)
            {
                return null;
            }

            imunizacao.ImunobiologicoId = updateImunizacaoDTO.ImunobiologicoId;
            imunizacao.DoseId = updateImunizacaoDTO.DoseId;
            imunizacao.ProximaDoseEm = updateImunizacaoDTO.ProximaDoseEm;

            _context.Imunizacao.Update(imunizacao);
            await _context.SaveChangesAsync();

            var result = _context.Imunizacao
                .Include(x => x.Imunobiologico)
                .Include(x => x.Dose)
                .FirstOrDefault(x => x.Id == imunizacao.Id);

            return new GetImunizacaoDTO
            {
                Id = result.Id,
                MembroId = result.MembroId,
                DescricaoDose = result.Dose.Descricao,
                DescricaoImunobiologico = result.Imunobiologico.Descricao,
                ProximaDoseEm = result.ProximaDoseEm,
            };
        }

        public async Task<bool> Deletar(int imunizacaoId)
        {
            Imunizacao? imunizacao = _context.Imunizacao.FirstOrDefault(x => x.Id == imunizacaoId);

            if (imunizacao is null)
            {
                return false;
            }

            _context.Imunizacao.Remove(imunizacao);
            await _context.SaveChangesAsync();

            return true;
        }

        public async Task<GetImunizacaoDTO> Inserir(CreateImunizacaoDTO createImunizacaoDTO)
        {
            Imunizacao imunizacao = new Imunizacao
            {
                MembroId = createImunizacaoDTO.MembroId,
                ImunobiologicoId = createImunizacaoDTO.ImunobiologicoId,
                DoseId = createImunizacaoDTO.DoseId,
                ProximaDoseEm = createImunizacaoDTO.ProximaDoseEm
            };

            _context.Imunizacao.Add(imunizacao);
            await _context.SaveChangesAsync();

            var result = _context.Imunizacao
                .Include(x => x.Imunobiologico)
                .Include(x => x.Dose)
                .FirstOrDefault(x => x.Id == imunizacao.Id);

            if (result is null)
            {
                return null;
            }

            return new GetImunizacaoDTO
            {
                Id = result.Id,
                DescricaoDose = result.Dose.Descricao,
                DescricaoImunobiologico = result.Imunobiologico.Descricao,
                MembroId = result.MembroId,
            };
        }

        public async Task<List<GetImunizacaoDTO>> ListarPorMembro(int membroId)
        {
            var result = await _context.Imunizacao
                .Where(x => x.MembroId == membroId)
                .Include(x => x.Imunobiologico)
                .Include(x => x.Dose)
                .OrderBy(x => x.Imunobiologico.Descricao)
                .ThenBy(x => x.Dose.Descricao)
                .ToListAsync();

            if (result.Count > 0)
            {
                return result.Select(x => new GetImunizacaoDTO
                {
                    Id = x.Id,
                    MembroId = x.MembroId,
                    DescricaoDose = x.Dose.Descricao,
                    DescricaoImunobiologico = x.Imunobiologico.Descricao,
                    ProximaDoseEm = x.ProximaDoseEm
                }).ToList();
            }

            return [];
        }
    }
}
