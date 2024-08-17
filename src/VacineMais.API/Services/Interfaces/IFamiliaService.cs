using VacineMais.API.DTOs.Familia;
using VacineMais.API.Models;

namespace VacineMais.API.Services.Interfaces
{
    public interface IFamiliaService
    {
        Task<List<GetFamiliaDTO>> Listar();
        Task<GetFamiliaDTO> Buscar(int familiaId);
        Task<Familia> BuscarPorUsuarioId(int usuarioId);
        Task<GetFamiliaDTO> Inserir(CreateFamiliaDto createFamiliaDto);
    }
}
