using VacineMais.API.Models;

namespace VacineMais.API.Services.Interfaces
{
    public interface IDoseService
    {
        Task<List<Dose>> Listar();
        Task<List<Dose>> Buscar(string descricaoOuSigla);
    }
}
