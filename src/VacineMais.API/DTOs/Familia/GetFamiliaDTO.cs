using VacineMais.API.DTOs.Membro;

namespace VacineMais.API.DTOs.Familia
{
    public class GetFamiliaDTO
    {
        public int FamiliaId { get; set; }
        public int UsuarioId { get; set; }
        public ICollection<GetMembroDTO> Membros { get; set; } = new List<GetMembroDTO>();
    }
}
