using System.ComponentModel.DataAnnotations;

namespace VacineMais.API.Models
{
    public class Imunizacao
    {
        [Key]
        public int Id { get; set; }
        public int MembroId { get; set; }
        public int CarteiraVacinacaoId { get; set; }
        public int ImunobiologicoId { get; set; }
        public int DoseId { get; set; }
        public DateTime? ProximaDoseEm { get; set; }

        public Membro Membro { get; set; }
        public CarteiraVacinacao CarteiraVacinacao { get; set; }
        public Imunobiologico Imunobiologico { get; set; }
        public Dose Dose { get; set; }
    }
}
