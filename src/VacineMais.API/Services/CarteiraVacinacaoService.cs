using Microsoft.EntityFrameworkCore;
using VacineMais.API.Data;
using VacineMais.API.DTOs.CarteiraVacinacao;
using VacineMais.API.Models;
using VacineMais.API.Services.Interfaces;

namespace VacineMais.API.Services;

public class CarteiraVacinacaoService : ICarteiraVacinacaoService
{
    private readonly AppDbContext _context;

    public CarteiraVacinacaoService(AppDbContext context)
    {
        _context = context;
    }

    public async Task<GetCarteiraVacinacaoDTO> BuscarPorMembro(int membroId)
    {
        var result = await _context.CarteiraVacinacao
                            .Include(x => x.Membro)
                            .Include(x => x.Imunizacoes)
                                .ThenInclude(x => x.Imunobiologico)
                            .Include(x => x.Imunizacoes)
                                .ThenInclude(x => x.Dose)
                            .FirstOrDefaultAsync(x => x.MembroId == membroId);

        if (result is null)
        {
            return null;
        }

        return CarteiraVacinacao.ToGetCarteiraDeVacinacaoDTO(result);
    }

    public async Task<GetCarteiraVacinacaoDTO> Inserir(Membro membro)
    {
        CarteiraVacinacao carteiraVacinacao = new CarteiraVacinacao
        {
            MembroId = membro.Id
        };


        var result = _context.CarteiraVacinacao.Add(carteiraVacinacao);
        await _context.SaveChangesAsync();

        membro.CarteiraVacinacaoId = carteiraVacinacao.Id;
        _context.Membro.Update(membro);
        await _context.SaveChangesAsync();

        return new GetCarteiraVacinacaoDTO
        {
            CarteiraVacinacaoId = carteiraVacinacao.Id,
            MembroId = membro.Id,
        };
    }
}
