export interface SolicitudAyuda {
     Id:number;
     NumeroExpediente: number;
     CedulaSolicitante:string;
     MaestroId: number;
     Maestro:string;
     Edad: number;
     Cargo:string;
     SexoMaestro:string;
     CategoriaId: number;
     SeccionalId:number;     
     Seccional:string;
     Celular:string;
     TelefonoCasa:string;
     TelefonoTrabajo:string;
     Email:string;
     QuienRecibeAyuda: number;
     FechaSolicitud:Date;
     FechaAprobacion:Date;
     FechaCreacion:Date;
     TipoSolicitudId:number;
     TipoSolicitud:string;
     OtroTipoSolicitud:string;
     concepto:string;
     MontoSolicitado:number;     
     MontoAprobado:number;
     UsuarioId:number;     
     EstadoId:number;
     Estado:string;     
     Direccion:string;
     BancoId:number;     
     Banco:string;
     NumeroCuentaBanco:string;
     ActaNacimientoHijoHija:boolean;
     CopiaCedulaPadreMadre:boolean;
     ActaMatrimonioUnion:boolean;
     EsJubiladoInabima:boolean;
     EstadoCuenta:boolean;     

     Requisitos: RequisitoSolicitud[];
     Adjuntos: AdjuntoSolicitud[];
     DatosAprobacion: DatoAprobacion[];
     ProcesadaPorUsuario: boolean;
     SubTipoSolicitud:string;

}

export interface RequisitoSolicitud {
     Id: number;
     FormName:string;
     PossibleValues:string;
     Descripcion:string;
     Value:string;
     Values: string[];
}

export interface AdjuntoSolicitud {
     Id: number;
     ContentType:string;
     SizeMB: number;   
     DisplayName:string;
}

export interface DatoAprobacion {
     EstadoId:number;
     Usuario:string;
     Fecha: Date;
     Estado:string;
     Comentario:string;
}