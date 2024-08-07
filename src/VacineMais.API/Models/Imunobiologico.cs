using System.ComponentModel.DataAnnotations;

namespace VacineMais.API.Models
{
    public class Imunobiologico
    {
        public Imunobiologico(int id, int codigo, string descricao, string sigla)
        {
            Id = id;
            Codigo = codigo;
            Descricao = descricao;
            Sigla = sigla;
        }

        [Key]
        public int Id { get; set; }
        public int Codigo { get; set; }
        public string Descricao { get; set; }
        public string Sigla { get; set; }

        public ICollection<Imunizacao> Imunizacoes { get; set; } = [];
    }
}
