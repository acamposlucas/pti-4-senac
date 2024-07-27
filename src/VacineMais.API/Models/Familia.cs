using System.ComponentModel.DataAnnotations;

namespace VacineMais.API.Models
{
    public class Familia
    {
        [Key]
        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public Usuario Usuario { get; set; }
        public ICollection<Membro> Membros { get; } = new List<Membro>();
    }
}
