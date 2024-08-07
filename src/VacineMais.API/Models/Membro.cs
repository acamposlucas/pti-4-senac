using System.ComponentModel.DataAnnotations;

namespace VacineMais.API.Models
{
    public class Membro
    {
        [Key]
        public int Id { get; set; }
        public int FamiliaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }

        public Familia Familia { get; set; }
        public ICollection<Imunizacao> Imunizacoes { get; set; } = [];
    }
}