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
  imunobiologicoId: number;
  descricaoImunobiologico: string;
  doseId: number;
  descricaoDose: string;
  proximaDoseEm: string;
}
