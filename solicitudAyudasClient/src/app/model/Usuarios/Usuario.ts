import { ComisionAprobacionUsuario } from "./ComisionAprobacionUsuario";
import { PermisoUsuario } from "./PermisoUsuario";
import { UsuarioBase } from "./UsuarioBase";

export interface Usuario extends UsuarioBase {
    Cedula:string;
    Direccion:string;
    TelefonoLabora:string;
    TelefonoCelular:string;
    TelefonoResidencial:string;
    Sexo:string;
    FechaNacimiento:Date;
    Host:string;
    Cargo:string;
    PermisosUsuario: PermisoUsuario[];
    ComisionesAprobacion: ComisionAprobacionUsuario[]
}
