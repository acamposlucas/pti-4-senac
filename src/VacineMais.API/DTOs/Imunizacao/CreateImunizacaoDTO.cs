namespace VacineMais.API.DTOs.Imunizacao
{
    public class CreateImunizacaoDTO
    {
        public int MembroId { get; set; }
        public int ImunobiologicoId { get; set; }
        public int DoseId { get; set; }
        public DateTime? ProximaDoseEm { get; set; }
        public int CarteiraVacinacaoId { get; set; }
    }
}
