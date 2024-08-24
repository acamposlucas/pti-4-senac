export interface CarteiraVacinacao {
  carteiraVacinacaoId: number;
  membroId: number;
  nome: string;
  idade: number;
  imunizacoes: Imunizacao[];
}

export interface Imunizacao {
  id: number;
  membroId: number;
  descricaoImunobiologico: string;
  descricaoDose: string;
  proximaDoseEm: string;
}
