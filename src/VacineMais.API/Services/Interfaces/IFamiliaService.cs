using VacineMais.API.DTOs.Familia;

namespace VacineMais.API.Services.Interfaces
{
    public interface IFamiliaService
    {
        Task<List<GetFamiliaDTO>> Listar();
        Task<GetFamiliaDTO> Buscar(int familiaId);
        Task<GetFamiliaDTO> Inserir(CreateFamiliaDto createFamiliaDto);
    }
}
