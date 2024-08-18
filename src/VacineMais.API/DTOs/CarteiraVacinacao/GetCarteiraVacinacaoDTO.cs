using VacineMais.API.DTOs.Imunizacao;

namespace VacineMais.API.DTOs.CarteiraVacinacao;

public class GetCarteiraVacinacaoDTO
{
    public int CarteiraVacinacaoId { get; set; }
    public int MembroId { get; set; }
    public string Nome { get; set; }
    public int Idade { get; set; }
    public List<GetImunizacaoDTO> Imunizacoes { get; set; } = [];
}
