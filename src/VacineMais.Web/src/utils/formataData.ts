export function formataData(data: Date | string) {
  const d: Date = typeof data === "string" ? new Date(data) : data;

  return d.toLocaleDateString();
}
