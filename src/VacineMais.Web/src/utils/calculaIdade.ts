export function calculaIdade(dataNascimento: Date | string): number {
  const nascimento =
    typeof dataNascimento === "string"
      ? new Date(dataNascimento)
      : dataNascimento;

  const hoje = new Date();
  let idade = hoje.getFullYear() - nascimento.getFullYear();
  const diferencaMeses = hoje.getMonth() - nascimento.getMonth();

  if (
    diferencaMeses < 0 ||
    (diferencaMeses === 0 && hoje.getDate() < nascimento.getDate())
  ) {
    idade--;
  }

  return idade;
}
