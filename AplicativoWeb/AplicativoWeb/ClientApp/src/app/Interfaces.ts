export interface MyResponse {
  Success: number;
  Data: any;
  Message: string;
}

export class Cliente {
  Id: number;
  Nombre: string;
  Correo: string;
  tipoAlmacenamiento: string;
}
