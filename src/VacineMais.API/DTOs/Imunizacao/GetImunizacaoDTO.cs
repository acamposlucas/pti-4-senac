namespace VacineMais.API.DTOs.Imunizacao
{
    public class GetImunizacaoDTO
    {
        public int Id { get; set; }
        public int MembroId { get; set; }
        public int ImunobiologicoId { get; set; }
        public string DescricaoImunobiologico { get; set; }
        public int DoseId { get; set; }
        public string DescricaoDose { get; set; }
        public DateTime? ProximaDoseEm { get; set; }
    }
}
