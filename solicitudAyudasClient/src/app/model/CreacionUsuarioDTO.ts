import { ComisionAprobacionUsuarioDTO } from "./ComisionAprobacionUsuarioDTO";
import { PermisoUsuarioDTO } from "./PermisoUsuarioDTO";

export class CreacionUsuarioDTO {
    public Id:number;
    public Login: string;
    public Cedula: string;
    public NombreCompleto: string;
    public SeccionalId: number;
    public Email: string;
    public Direccion: string;
    public TelefonoLabora: string;
    public TelefonoCelular: string;
    public TelefonoResidencial: string;
    public Sexo: string;
    public FechaNacimiento: Date;
    public Cargo: string;
    public Host:string;
    public PermisosUsuario:Array<PermisoUsuarioDTO> = [];
    public ComisionesAprobacion:Array<ComisionAprobacionUsuarioDTO> = [];
}
