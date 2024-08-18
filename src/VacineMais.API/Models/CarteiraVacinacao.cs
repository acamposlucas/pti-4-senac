using System.ComponentModel.DataAnnotations;
using VacineMais.API.DTOs.CarteiraVacinacao;
using VacineMais.API.DTOs.Imunizacao;

namespace VacineMais.API.Models;

public class CarteiraVacinacao
{
    [Key]
    public int Id { get; set; }
    public int MembroId { get; set; }

    public Membro Membro { get; set; }
    public List<Imunizacao> Imunizacoes { get; set; } = [];

    public static GetCarteiraVacinacaoDTO ToGetCarteiraDeVacinacaoDTO(CarteiraVacinacao carteiraVacinacao)
    {
        return new GetCarteiraVacinacaoDTO
        {
            Nome = carteiraVacinacao.Membro.Nome,
            Idade = CalculaIdadeMembro(carteiraVacinacao.Membro.DataNascimento),
            Imunizacoes = carteiraVacinacao.Imunizacoes.Select(x => new GetImunizacaoDTO
            {
                Id = x.Id,
                MembroId = x.MembroId,
                DescricaoDose = x.Dose.Descricao,
                DescricaoImunobiologico = x.Imunobiologico.Descricao,
                ProximaDoseEm = x.ProximaDoseEm
            }).ToList(),
            MembroId = carteiraVacinacao.MembroId
        };
    }

    public static int CalculaIdadeMembro(DateTime dataNascimento)
    {
        return DateTime.Now.Year - dataNascimento.Year;
    }
}
