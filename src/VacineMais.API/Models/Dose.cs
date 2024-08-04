using System.ComponentModel.DataAnnotations;

namespace VacineMais.API.Models
{
    public class Dose
    {
        public Dose() { }

        public Dose(int id, int codigo, string descricao, string sigla)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            Sigla = sigla;
        }

        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; } = string.Empty;
        public string Sigla { get; set; } = string.Empty;
    }
}
