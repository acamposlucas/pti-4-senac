using VacineMais.API.DTOs.CarteiraVacinacao;
using VacineMais.API.Models;

namespace VacineMais.API.Services.Interfaces;

public interface ICarteiraVacinacaoService
{
    Task<GetCarteiraVacinacaoDTO> Inserir(Membro membro);
    Task<GetCarteiraVacinacaoDTO> BuscarPorMembro(int membroId);
}
