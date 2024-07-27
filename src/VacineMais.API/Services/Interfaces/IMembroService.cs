using System.Linq.Expressions;
using VacineMais.API.DTOs.Membro;

namespace VacineMais.API.Services.Interfaces
{
    public interface IMembroService
    {
        Task<GetMembroDTO> Inserir(CreateMembroDTO dto);
        Task<GetMembroDTO> Buscar(int id);
        Task<GetMembroDTO> Update(UpdateMembroDTO dto);
        Task<bool> Deletar(int id);
    }
}
