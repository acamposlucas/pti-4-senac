namespace VacineMais.API.DTOs.Imunizacao
{
    public class UpdateImunizacaoDTO
    {
        public int Id { get; set; }
        public int MembroId { get; set; }
        public int ImunobiologicoId { get; set; }
        public int DoseId { get; set; }
        public DateTime? ProximaDoseEm { get; set; }
    }
}
