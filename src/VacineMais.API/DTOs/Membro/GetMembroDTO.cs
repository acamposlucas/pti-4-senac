namespace VacineMais.API.DTOs.Membro
{
    public class GetMembroDTO
    {
        public int Id { get; set; }
        public int FamiliaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
