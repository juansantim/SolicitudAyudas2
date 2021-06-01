export interface TipoSolicitud {
    Id: number;
    Nombre:string;
    CategoriaId: number;
    Requisitos: RequisitoTipoSolicitud[]
}

export interface RequisitoTipoSolicitud {
    Id: number;
    Descripcion: string;
    FormName:string;
    Value:string;
    Values: string[]
}