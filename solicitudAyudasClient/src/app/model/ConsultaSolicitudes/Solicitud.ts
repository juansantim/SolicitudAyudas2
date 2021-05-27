export interface Solicitud {
    id:number;
    cedula:string;
    seccional:string;
    tipoSolicitud:string;
    solicitante:string;
    montoSolicitado:number;
    montoAprobado:number;
    estado:string;
    estadoId:number;
    fechaSolicitud:Date;
    fechaAprobacion:Date;
}