export class CreacionUsuarioDTO {
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
    public PermisosUsuario:Array<PermisoUsuario> = [];
}

export class PermisoUsuario{
    UsuarioId: number;
    PermisoId: number;
}