import { calculaIdade } from "./calculaIdade";

export function formataIdade(dataNascimento: Date | string) {
  const idade = calculaIdade(dataNascimento);

  return idade <= 1 ? `${idade} ano` : `${idade} anos`;
}
