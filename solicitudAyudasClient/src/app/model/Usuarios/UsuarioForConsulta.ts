import { UsuarioBase } from "./UsuarioBase";

export interface UsuarioForConsulta extends UsuarioBase {    
    Permisos:string[]; 
    Comisiones:string[];
}