using VacineMais.API.Models;

namespace VacineMais.API.DTOs.Familia
{
    public class GetFamiliaDTO
    {
        public int FamiliaId { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<Membro> Membros { get; set; } = new List<Membro>();
    }
}
