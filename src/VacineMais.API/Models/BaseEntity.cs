namespace VacineMais.API.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime CriadoEm = DateTime.Now;
        public DateTime AtualizadoEm = DateTime.Now;
    }
}
