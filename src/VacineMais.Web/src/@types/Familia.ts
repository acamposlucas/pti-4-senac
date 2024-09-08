import { Membro } from "./Membro";

export interface Familia {
  familiaId: number;
  usuarioId: number;
  membros: Membro[];
}
