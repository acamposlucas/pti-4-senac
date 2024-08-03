using VacineMais.API.Models;

namespace VacineMais.API.Services.Interfaces
{
    public interface IImunobiologicoService
    {
        Task<List<Imunobiologico>> Listar();
        Task<List<Imunobiologico>> Buscar(string descricaoOuSigla);
    }
}
