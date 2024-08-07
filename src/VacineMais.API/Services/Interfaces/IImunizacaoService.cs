using VacineMais.API.DTOs.Imunizacao;

namespace VacineMais.API.Services.Interfaces
{
    public interface IImunizacaoService
    {
        Task<GetImunizacaoDTO> Inserir(CreateImunizacaoDTO createImunizacaoDTO);
        Task<List<GetImunizacaoDTO>> ListarPorMembro(int membroId);
        Task<GetImunizacaoDTO> Atualizar(UpdateImunizacaoDTO updateImunizacaoDTO);
        Task Deletar(int imunizacaoId);
    }
}
