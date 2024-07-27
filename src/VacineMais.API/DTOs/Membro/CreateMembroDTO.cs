namespace VacineMais.API.DTOs.Membro
{
    public class CreateMembroDTO
    {
        public int FamiliaId { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
