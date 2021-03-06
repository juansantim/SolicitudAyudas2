using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "dbo");

            migrationBuilder.CreateSequence<int>(
                name: "NumeroExpendiente",
                schema: "dbo");

            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "CategoriasTiposSolicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CategoriasTiposSolicitudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ComisionesAprobacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComisionesAprobacion", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "EstadoSolicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EstadoSolicitudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Movimientos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Entidad = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Key = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(1000)", maxLength: 1000, nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movimientos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Permisos",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permisos", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposSolicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    ComisionAprobacionId = table.Column<int>(type: "int", nullable: false),
                    CategoriaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSolicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_TiposSolicitudes_CategoriasTiposSolicitudes_CategoriaId",
                        column: x => x.CategoriaId,
                        principalTable: "CategoriasTiposSolicitudes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_TiposSolicitudes_ComisionesAprobacion_ComisionAprobacionId",
                        column: x => x.ComisionAprobacionId,
                        principalTable: "ComisionesAprobacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Cambio",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MovimientoId = table.Column<int>(type: "int", nullable: false),
                    Propiedad = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true),
                    Antes = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true),
                    Despues = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cambio", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Cambio_Movimientos_MovimientoId",
                        column: x => x.MovimientoId,
                        principalTable: "Movimientos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitosTiposSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PossibleValues = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosTiposSolicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosTiposSolicitud_TiposSolicitudes_TipoSolicitudId",
                        column: x => x.TipoSolicitudId,
                        principalTable: "TiposSolicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seccionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    PresidenteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccionales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seccionales_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Sexo = table.Column<string>(type: "nvarchar(1)", maxLength: 1, nullable: true),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Direccion = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    TelefonoCelular = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TelefonoLabora = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TelefonoResidencial = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maestros_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NombreCompleto = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Login = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Password = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ChangePasswordCode = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ChangePasswordCodeExpiration = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    FechaInactivacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    UsuarioIdInactivacion = table.Column<int>(type: "int", nullable: true),
                    MaestroId = table.Column<int>(type: "int", nullable: true),
                    SeccionalId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Usuarios_Maestros_MaestroId",
                        column: x => x.MaestroId,
                        principalTable: "Maestros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "PermisosUsuarios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    PermisoId = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermisosUsuarios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PermisosUsuarios_Permisos_PermisoId",
                        column: x => x.PermisoId,
                        principalTable: "Permisos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_PermisosUsuarios_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SolicitudesAyuda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NumeroExpediente = table.Column<int>(type: "int", nullable: false, defaultValueSql: "NEXT VALUE FOR dbo.NumeroExpendiente"),
                    CedulaSolicitante = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    MaestroId = table.Column<int>(type: "int", nullable: false),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TelefonoCasa = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    TelefonoTrabajo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    QuienRecibeAyuda = table.Column<byte>(type: "tinyint", nullable: true),
                    FechaSolicitud = table.Column<DateTime>(type: "datetime2", nullable: false),
                    FechaAprobacion = table.Column<DateTime>(type: "datetime2", nullable: true),
                    TipoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    Concepto = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    MontoSolicitado = table.Column<decimal>(type: "decimal(10,2)", nullable: false),
                    MontoAprobado = table.Column<decimal>(type: "decimal(10,2)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Direccion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    BancoId = table.Column<int>(type: "int", nullable: false, defaultValue: 1),
                    NumeroCuentaBanco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ActaNacimientoHijoHija = table.Column<bool>(type: "bit", nullable: true),
                    CopiaCedulaPadreMadre = table.Column<bool>(type: "bit", nullable: true),
                    ActaMatrimonioUnion = table.Column<bool>(type: "bit", nullable: true),
                    EsJubiladoInabima = table.Column<bool>(type: "bit", nullable: true),
                    EstadoCuenta = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SolicitudesAyuda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_SolicitudesAyuda_Banco_BancoId",
                        column: x => x.BancoId,
                        principalTable: "Banco",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesAyuda_EstadoSolicitudes_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoSolicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesAyuda_Maestros_MaestroId",
                        column: x => x.MaestroId,
                        principalTable: "Maestros",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesAyuda_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_SolicitudesAyuda_TiposSolicitudes_TipoSolicitudId",
                        column: x => x.TipoSolicitudId,
                        principalTable: "TiposSolicitudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_SolicitudesAyuda_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UsuariosComisionesAprobacion",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ComisionAprobacionId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    Disponible = table.Column<bool>(type: "bit", nullable: false),
                    FechaCreacion = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UsuarioCreacionId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuariosComisionesAprobacion", x => x.Id);
                    table.ForeignKey(
                        name: "FK_UsuariosComisionesAprobacion_ComisionesAprobacion_ComisionAprobacionId",
                        column: x => x.ComisionAprobacionId,
                        principalTable: "ComisionesAprobacion",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UsuariosComisionesAprobacion_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "AdjuntosSolicitudesAyuda",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudAyudaId = table.Column<int>(type: "int", nullable: false),
                    DisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    URL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SizeMB = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AdjuntosSolicitudesAyuda", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AdjuntosSolicitudesAyuda_SolicitudesAyuda_SolicitudAyudaId",
                        column: x => x.SolicitudAyudaId,
                        principalTable: "SolicitudesAyuda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AprobacionesSolicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudAyudaId = table.Column<int>(type: "int", nullable: false),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    Fecha = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AprobacionesSolicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AprobacionesSolicitudes_EstadoSolicitudes_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "EstadoSolicitudes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_AprobacionesSolicitudes_SolicitudesAyuda_SolicitudAyudaId",
                        column: x => x.SolicitudAyudaId,
                        principalTable: "SolicitudesAyuda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AprobacionesSolicitudes_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ComentarioSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Comentario = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UsuarioId = table.Column<int>(type: "int", nullable: false),
                    SolicitudAyudaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ComentarioSolicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ComentarioSolicitud_SolicitudesAyuda_SolicitudAyudaId",
                        column: x => x.SolicitudAyudaId,
                        principalTable: "SolicitudesAyuda",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ComentarioSolicitud_Usuarios_UsuarioId",
                        column: x => x.UsuarioId,
                        principalTable: "Usuarios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitosSolicitudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SolicitudAyudaId = table.Column<int>(type: "int", nullable: false),
                    RequisitoTiposSolicitudId = table.Column<int>(type: "int", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosSolicitudes", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosSolicitudes_RequisitosTiposSolicitud_RequisitoTiposSolicitudId",
                        column: x => x.RequisitoTiposSolicitudId,
                        principalTable: "RequisitosTiposSolicitud",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_RequisitosSolicitudes_SolicitudesAyuda_SolicitudAyudaId",
                        column: x => x.SolicitudAyudaId,
                        principalTable: "SolicitudesAyuda",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Banco",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "BanReservas (Banco de Reservas)" },
                    { 29, "Banco Del Caribe" },
                    { 30, "Banco Inmobiliario (Banaci)" },
                    { 31, "Banco Gruficorp" },
                    { 32, "Banco Cofaci" },
                    { 33, "Banco Bonanza" },
                    { 34, "Banco Fihogar" },
                    { 35, "Banco Federal" },
                    { 36, "Banco Micro" },
                    { 37, "Banco Union" },
                    { 38, "Asociación Popular" },
                    { 28, "Banco Rio" },
                    { 39, "Asociación Popular de Ahorros y Préstamos" },
                    { 41, "Asociación Nortena" },
                    { 42, "Asociación Peravia" },
                    { 43, "Asociación Romana" },
                    { 44, "Asociación Higuamo" },
                    { 45, "Asociación La Vega Real" },
                    { 46, "Asociación Duarte" },
                    { 47, "Asociación Barahona" },
                    { 48, "Asociación Maguana" },
                    { 49, "Asociación Mocana" },
                    { 50, "Asociación Bonao" },
                    { 40, "Asociación Cibao" },
                    { 27, "Banco Motor Crédito" },
                    { 51, "Asociación La Nacional" },
                    { 25, "Banco Confisa" },
                    { 2, "Banco Popular Dominicano" },
                    { 3, "Banco Agrícola" },
                    { 4, "Banco BHD León" },
                    { 5, "Banco Vimenca" },
                    { 26, "Banco Empire" },
                    { 7, "Banco Caribe" },
                    { 8, "Banco BDI" },
                    { 9, "Banco López de Haro" },
                    { 10, "Banco Ademi" },
                    { 11, "Banco BELLBANK" },
                    { 12, "Banco Múltiple Activo Dominicana" },
                    { 6, "Banco Santa Cruz" },
                    { 14, "Citibank" },
                    { 15, "Banco Promerica" },
                    { 16, "Banesco" }
                });

            migrationBuilder.InsertData(
                table: "Banco",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 17, "Bancamerica" },
                    { 18, "Banco Atlántico" },
                    { 19, "Banco Bancotui" },
                    { 20, "Banco BDA" },
                    { 21, "Banco Adopem" },
                    { 22, "Banco Agrícola De La República Dominicana" },
                    { 23, "Banco Pyme Bhd" },
                    { 24, "Banco Capital" },
                    { 13, "Scotiabank" }
                });

            migrationBuilder.InsertData(
                table: "CategoriasTiposSolicitudes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 3, "Otros" },
                    { 1, "Ayudas de Salud" },
                    { 2, "Ayudas de Infraestructura y Construcción" }
                });

            migrationBuilder.InsertData(
                table: "ComisionesAprobacion",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Comision de Salud" },
                    { 2, "Comision de Infraestructura" }
                });

            migrationBuilder.InsertData(
                table: "EstadoSolicitudes",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 1, "La solicitud se encuentra en cola para ser atendida.", "Solicitado" },
                    { 2, "La solicitud ha sido aprobada al menos por 1 miembro de la comisión", "Proceso de Aprobación" },
                    { 3, "La solicitud ha sido aprobada y se encuentra en proceso de ser aplicada.", "Aprobado" },
                    { 4, "La solicitud no procede según las políticas establecidas.", "Rechazado" },
                    { 5, "Solicitud fue descartada.", "Anulado" }
                });

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[,]
                {
                    { 9, "Modificar, monto solicitado, banco y numero de cuenta de la solicitud", "Modificar Solicitud" },
                    { 8, "Crear, modificar y deshabilitar usuarios", "Gestionar Usuarios" },
                    { 7, "Generar reportes", "Generar Estadísticas" },
                    { 6, "Consultar informaciones de afiliado", "Ver record de Afiliado" },
                    { 3, null, "Aprobar Solicitudes" },
                    { 4, "Rechazar solicitud por cualquier motivo", "Rechazar Solicitudes" },
                    { 2, "Registrar una solicitud", "Crear Solicitudes" },
                    { 1, "Entrar y consultar por diferentes criterios", "Consultar Solicitudes" },
                    { 5, "Anular una solicitud, siempre y cuando no se encuentre aprobada", "Anular Solicitudes" }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 17, "MONTECRISTI" },
                    { 18, "MONTE PLATA" },
                    { 19, "PEDERNALES" },
                    { 20, "PERAVIA" },
                    { 21, "PUERTO PLATA" },
                    { 22, "HERMANAS MIRABAL (SALCEDO)" },
                    { 24, "SAN CRISTOBAL" },
                    { 25, "SAN JUAN DE LA MAGUANA" },
                    { 26, "SAN PEDRO DE MACORIS" },
                    { 27, "SANCHEZ RAMIREZ" },
                    { 28, "SANTIAGO DE LOS CABALLEROS" },
                    { 29, "SANTIAGO RODRIGUEZ" },
                    { 30, "VALVERDE" },
                    { 23, "SAMANA" }
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 16, "MONSEÑOR NOUEL" },
                    { 14, "LA VEGA" },
                    { 13, "LA ROMANA" },
                    { 12, "INDEPENDENCIA" },
                    { 11, "HATO MAYOR DEL REY" },
                    { 10, "ESPAILLAT" },
                    { 9, "ELIAS PIÑA" },
                    { 8, "EL SEIBO" },
                    { 7, "DUARTE" },
                    { 6, "DAJABON" },
                    { 5, "BARAHONA" },
                    { 4, "BAHORUCO" },
                    { 3, "AZUA" },
                    { 2, "LA ALTAGRACIA" },
                    { 1, "DISTRITO NACIONAL" },
                    { 31, "SAN JOSE DE OCOA" },
                    { 15, "MARIA TRINIDAD SANCHEZ" },
                    { 32, "SANTO DOMINGO" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 354, "ARROYO TORO-MASIPEDRO (DM)", 16 },
                    { 134, "LAS TERRENAS", 23 },
                    { 66, "SANCHEZ", 23 },
                    { 65, "SAMANA", 23 },
                    { 270, "MONTE LLANO (JAMAO AFUERA) (DM)", 22 },
                    { 193, "BLANCO (DM)", 22 },
                    { 64, "TENARES", 22 },
                    { 55, "SALCEDO", 22 },
                    { 51, "VILLA TAPIA", 22 },
                    { 388, "GUALEPE", 21 },
                    { 218, "EL LIMON (DM)", 23 },
                    { 375, "ESTRECHO DE LUPERON OMAR BROSS (DM)", 21 },
                    { 346, "RIO GRANDE (DM)", 21 },
                    { 332, "YASICA ARRIBA (DM)", 21 },
                    { 305, "NAVAS (DM)", 21 },
                    { 263, "LA JAIBA (DM)", 21 },
                    { 245, "SABANETA DE YASICA (DM)", 21 },
                    { 244, "CABARETE (DM)", 21 },
                    { 243, "BELLOSO (DM)", 21 },
                    { 206, "NAVAS (DM)", 21 },
                    { 188, "LA ISABELA (DM)", 21 },
                    { 372, "MAIMON (DM)", 21 },
                    { 177, "ESTERO HONDO (DM)", 21 },
                    { 262, "ARROYO BARRIL (DM)", 23 },
                    { 2, "SAN CRISTOBAL", 24 },
                    { 186, "MATAYAYA (DM)", 25 },
                    { 129, "JUAN DE HERRERA", 25 },
                    { 109, "BOHECHIO", 25 },
                    { 108, "VALLEJUELO", 25 },
                    { 14, "EL CERCADO", 25 },
                    { 12, "SAN JUAN DE LA MAGUANA", 25 },
                    { 11, "LAS MATAS DE FARFAN", 25 },
                    { 315, "CAMBITA EL PUEBLECITO (DM)", 24 },
                    { 306, "HATO DAMAS (DM)", 24 },
                    { 322, "LAS GALERAS (DM)", 23 },
                    { 256, "LA CUCHILLA (DM)", 24 },
                    { 252, "SAN JOSE-PINO HERRADO-EL PUERTO(DM)", 24 },
                    { 234, "EL CARRIL (DM)", 24 },
                    { 140, "SAN GREGORIO DE NIGUA", 24 },
                    { 139, "LOS CACAOS", 24 },
                    { 104, "CAMBITA GARABITOS", 24 },
                    { 93, "BAJOS DE HAINA", 24 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 83, "SABANA GRANDE DE PALENQUE", 24 },
                    { 82, "YAGUATE", 24 },
                    { 68, "VILLA ALTAGRACIA", 24 },
                    { 255, "MEDINA (DM)", 24 },
                    { 175, "VILLA MONTELLANO", 21 },
                    { 121, "VILLA ISABELA", 21 },
                    { 120, "GUANANICO", 21 },
                    { 209, "MAJAGUAL (DM)", 18 },
                    { 179, "LOS BOTADOS (DM)", 18 },
                    { 174, "GONZALO (DM)", 18 },
                    { 153, "PERALVILLO", 18 },
                    { 147, "DON JUAN (DM)", 18 },
                    { 90, "SABANA GRANDE DE BOYA", 18 },
                    { 8, "MONTE PLATA", 18 },
                    { 5, "YAMASA", 18 },
                    { 4, "BAYAGUANA", 18 },
                    { 254, "CHIRINO (DM)", 18 },
                    { 253, "PALO VERDE (EL AHOGADO) (DM)", 17 },
                    { 173, "HATILLO PALMA (DM)", 17 },
                    { 171, "VILLA ELISA (DM)", 17 },
                    { 117, "LAS MATAS DE SANTA CRUZ", 17 },
                    { 101, "CASTAÃ‘UELAS", 17 },
                    { 86, "PEPILLO SALCEDO", 17 },
                    { 72, "VILLA VASQUEZ", 17 },
                    { 45, "GUAYUBIN", 17 },
                    { 41, "MONTECRISTI", 17 },
                    { 383, "LA SALVIA-LOS QUEMADOS (DM)", 16 },
                    { 241, "CANA CHAPETON (DM)", 17 },
                    { 299, "BOYA-EL CENTRO (DM)", 18 },
                    { 69, "PEDERNALES", 19 },
                    { 91, "OVIEDO", 19 },
                    { 102, "LOS HIDALGOS", 21 },
                    { 97, "SOSUA", 21 },
                    { 40, "LUPERON", 21 },
                    { 39, "ALTAMIRA", 21 },
                    { 38, "IMBERT", 21 },
                    { 37, "PUERTO PLATA", 21 },
                    { 381, "LAS BARIAS (DM)", 20 },
                    { 358, "EL LIMONAL (DM)", 20 },
                    { 302, "LA CATALINA (DM)", 20 },
                    { 235, "EL CARRETON (DM)", 20 },
                    { 221, "VILLA SOMBRERO (DM)", 20 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 185, "PAYA (DM)", 20 },
                    { 176, "SANTANA (DM)", 20 },
                    { 170, "PIZARRETE (DM)", 20 },
                    { 158, "SABANA BUEY (DM)", 20 },
                    { 157, "VILLA FUNDACION (DM)", 20 },
                    { 156, "MATANZAS (DM)", 20 },
                    { 84, "NIZAO", 20 },
                    { 3, "BANI", 20 },
                    { 325, "JOSE FRANCISCO PEÃ‘A GOMEZ (DM)", 19 },
                    { 184, "JUANCHO (DM)", 19 },
                    { 190, "PEDRO CORTO (DM)", 25 },
                    { 287, "ARROYO CANO (DM)", 25 },
                    { 292, "SABANETA (DM)", 25 },
                    { 297, "YAQUE (BUENA VISTA) (DM)", 25 },
                    { 204, "JICOME (DM)", 30 },
                    { 197, "MAIZAL (DM)", 30 },
                    { 196, "GUATAPANAL (DM)", 30 },
                    { 195, "JAIBON (DM)", 30 },
                    { 194, "AMINA (DM)", 30 },
                    { 92, "LAGUNA SALADA", 30 },
                    { 34, "MAO", 30 },
                    { 33, "ESPERANZA", 30 },
                    { 116, "VILLA LOS ALMACIGOS", 29 },
                    { 217, "JAIBÃ“N (DM)", 30 },
                    { 46, "SAN IGNACIO DE SABANETA", 29 },
                    { 374, "CANCA LA PIEDRA (DM)", 28 },
                    { 352, "CANABACOA ABAJO (DM)", 28 },
                    { 351, "GUAYABAL (DM)", 28 },
                    { 350, "PUÃ‘AL", 28 },
                    { 327, "LAS PALOMAS (DM)", 28 },
                    { 308, "EL CAIMITO (DM)", 28 },
                    { 269, "LAS PLACETAS (DM)", 28 },
                    { 268, "LAS CUESTA (DM)", 28 },
                    { 258, "HATO DEL YAQUE (DM)", 28 },
                    { 42, "MONCION", 29 },
                    { 232, "LA CAYA (DM)", 30 },
                    { 248, "CRUCE DE GUAYACANES (DM)", 30 },
                    { 328, "BOCA DE MAO (DM)", 30 },
                    { 311, "LA CUABA (DM)", 32 },
                    { 310, "LA GUAYIGA (DM)", 32 },
                    { 307, "HATO VIEJO (DM)", 32 },
                    { 291, "SAN LUIS (DM)", 32 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 286, "LA CALETA (DM)", 32 },
                    { 230, "LA VICTORIA (DM)", 32 },
                    { 229, "LOS ALCARRIZOS", 32 },
                    { 228, "PEDRO BRAND", 32 },
                    { 227, "SAN ANTONIO DE GUERRA", 32 },
                    { 226, "BOCA CHICA", 32 },
                    { 225, "SANTO DOMINGO NORTE", 32 },
                    { 224, "SANTO DOMINGO OESTE", 32 },
                    { 223, "SANTO DOMINGO ESTE", 32 },
                    { 382, "EL NARANJAL (DM)", 31 },
                    { 278, "EL PINAR (DM)", 31 },
                    { 277, "NIZAO-LAS AUYAMAS (DM)", 31 },
                    { 180, "LA CIENAGA (DM)", 31 },
                    { 152, "RANCHO ARRIBA", 31 },
                    { 150, "SABANA LARGA", 31 },
                    { 13, "SAN JOSE DE OCOA", 31 },
                    { 343, "PARADERO (DM)", 30 },
                    { 246, "EL LIMON (DM)", 28 },
                    { 362, "JAYACO (DM)", 16 },
                    { 239, "SAN FRANCISCO DE JACAGUA (DM)", 28 },
                    { 192, "JUNCALITO (DM)", 28 },
                    { 247, "GAUTIER (DM)", 26 },
                    { 200, "EL PUERTO (DM)", 26 },
                    { 146, "QUISQUEYA", 26 },
                    { 138, "CONSUELO", 26 },
                    { 30, "RAMON SANTANA", 26 },
                    { 24, "LOS LLANOS", 26 },
                    { 23, "SAN PEDRO DE MACORIS", 26 },
                    { 390, "LA ZANJA", 25 },
                    { 366, "JINOVA (DM)", 25 },
                    { 364, "GUAYACANES", 26 },
                    { 357, "LAS CHARCAS DE MARIA NOVAS (DM)", 25 },
                    { 348, "JORGILLO (DM)", 25 },
                    { 336, "LA JAGUA (DM)", 25 },
                    { 331, "GUANITO (DM)", 25 },
                    { 330, "CARRERA DE YEGUAS (DM)", 25 },
                    { 329, "BATISTA (DM)", 25 },
                    { 326, "HATO DEL PADRE (DM)", 25 },
                    { 319, "EL ROSARIO (DM)", 25 },
                    { 317, "DERRUMBADERO (EL NUEVO BRAZIL) (DM)", 25 },
                    { 314, "SABANA ALTA (DM)", 25 },
                    { 353, "LAS MAGUANAS-HATO NUEVO (DM)", 25 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 49, "COTUI", 27 },
                    { 52, "CEVICOS", 27 },
                    { 87, "FANTINO", 27 },
                    { 191, "EL RUBIO (DM)", 28 },
                    { 172, "LA CANELA (DM)", 28 },
                    { 161, "BAITOA (DM)", 28 },
                    { 148, "SABANA IGLESIA (DM)", 28 },
                    { 142, "PEDRO GARCIA (DM)", 28 },
                    { 96, "VILLA BISONO -NAVARRETE-", 28 },
                    { 95, "LICEY AL MEDIO", 28 },
                    { 94, "VILLA GONZALEZ", 28 },
                    { 36, "SAN JOSE DE LAS MATAS", 28 },
                    { 35, "JANICO", 28 },
                    { 32, "TAMBORIL", 28 },
                    { 31, "SANTIAGO DE LOS CABALLEROS", 28 },
                    { 384, "HERNANDO ALONZO (DM)", 27 },
                    { 373, "COMEDERO ARRIBA (DM)", 27 },
                    { 369, "CABALLERO (DM)", 27 },
                    { 320, "QUITA SUEÃ‘O (DM)", 27 },
                    { 309, "PLATANAL (DM)", 27 },
                    { 233, "ANGELINA (DM)", 27 },
                    { 220, "LA BIJA (DM)", 27 },
                    { 155, "VILLA LA MATA", 27 },
                    { 124, "LA CUEVA (DM)", 27 },
                    { 219, "PALMAR ARRIBA (DM)", 28 },
                    { 312, "PALMAREJO (DM)", 32 },
                    { 313, "PANTOJA (DM)", 32 },
                    { 210, "JUAN ADRIAN (DM)", 16 },
                    { 216, "PESCADERIA (DM)", 5 },
                    { 198, "EL CACHON (DM)", 5 },
                    { 167, "JAQUIMEYES", 5 },
                    { 164, "CANOA (DM)", 5 },
                    { 160, "LA CIENAGA", 5 },
                    { 137, "LAS SALINAS", 5 },
                    { 131, "FUNDACION", 5 },
                    { 130, "EL PEÃ‘ON", 5 },
                    { 111, "POLO", 5 },
                    { 222, "LOS PATOS (DM)", 5 },
                    { 80, "PARAISO", 5 },
                    { 21, "ENRIQUILLO", 5 },
                    { 19, "CABRAL", 5 },
                    { 18, "BARAHONA", 5 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 387, "EL SALADO", 4 },
                    { 386, "SANTA BARBARA EL 6", 4 },
                    { 371, "MENA (DM)", 4 },
                    { 333, "CABEZA DE TORO (DM)", 4 },
                    { 298, "MONSERRAT (DM)", 4 },
                    { 289, "SANTANA (DM)", 4 },
                    { 79, "VICENTE NOBLE", 5 },
                    { 288, "LAS CLAVELLINAS (DM)", 4 },
                    { 272, "QUITA CORAZA (DM)", 5 },
                    { 284, "ARROYO DULCE (DM)", 5 },
                    { 143, "LAS GUARANAS", 7 },
                    { 119, "ARENOSO", 7 },
                    { 63, "EUGENIO MARIA DE HOSTOS", 7 },
                    { 59, "CASTILLO", 7 },
                    { 58, "VILLA RIVA", 7 },
                    { 57, "PIMENTEL", 7 },
                    { 56, "SAN FRANCISCO DE MACORIS", 7 },
                    { 365, "SANTIAGO DE LA CRUZ (DM)", 6 },
                    { 321, "CAÃ‘ONGO (DM)", 6 },
                    { 279, "FONDO NEGRO (DM)", 5 },
                    { 318, "CAPOTILLO (DM)", 6 },
                    { 151, "EL PINO", 6 },
                    { 115, "PARTIDO", 6 },
                    { 73, "LOMA DE CABRERA", 6 },
                    { 44, "DAJABON", 6 },
                    { 43, "RESTAURACION", 6 },
                    { 389, "VILLA CENTRAL", 5 },
                    { 356, "LA GUAZARA (DM)", 5 },
                    { 301, "BAHORUCO (DM)", 5 },
                    { 294, "PALO ALTO (DM)", 5 },
                    { 242, "MANUEL BUENO (DM)", 6 },
                    { 281, "JUMA BEJUCAL (DM)", 16 },
                    { 214, "EL PALMAR (DM)", 4 },
                    { 113, "GALVAN", 4 },
                    { 231, "VILLARPANDO (DM)", 3 },
                    { 207, "PALMAR DE OCOA (DM)", 3 },
                    { 154, "PUEBLO VIEJO", 3 },
                    { 135, "LAS CHARCAS", 3 },
                    { 132, "ESTEBANIA", 3 },
                    { 126, "TABARA ARRIBA", 3 },
                    { 125, "LAS YAYAS DE VIAJAMA", 3 },
                    { 107, "SABANA YEGUA", 3 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 106, "PERALTA", 3 },
                    { 257, "LOS TOROS (DM)", 3 },
                    { 105, "GUAYABAL", 3 },
                    { 10, "AZUA", 3 },
                    { 385, "TURISTICO VERON PUNTA CANA (DM)", 2 },
                    { 249, "BAYAHIBE (DM)", 2 },
                    { 211, "BOCA DE YUMA (DM)", 2 },
                    { 145, "LA OTRA BANDA (DM)", 2 },
                    { 141, "LA LAGUNA DE NISIBON (DM)", 2 },
                    { 85, "SAN RAFAEL DEL YUMA", 2 },
                    { 28, "HIGUEY", 2 },
                    { 1, "DISTRITO NACIONAL", 1 },
                    { 17, "PADRE LAS CASAS", 3 },
                    { 127, "UVILLA (DM)", 4 },
                    { 259, "PROYECTO #4 (DM)", 3 },
                    { 261, "EL ROSARIO (DM)", 3 },
                    { 112, "LOS RIOS", 4 },
                    { 78, "VILLA JARAGUA", 4 },
                    { 76, "TAMAYO", 4 },
                    { 22, "NEYBA", 4 },
                    { 380, "PROYECTO 2-C (DM)", 3 },
                    { 377, "HATO NUEVO CORTES (DM)", 3 },
                    { 370, "LOS FRIOS (DM)", 3 },
                    { 355, "LAS LOMAS (DM)", 3 },
                    { 341, "LAS CLAVELLINAS (DM)", 3 },
                    { 260, "PROYECTO D-1 GANADERO (DM)", 3 },
                    { 340, "DOÃ‘A EMMA BALAGUER VDA. VALLEJO", 3 },
                    { 335, "BARRERAS (DM)", 3 },
                    { 334, "PUERTO VIEJO-LOS NEGROS (DM)", 3 },
                    { 304, "LA SIEMBRA (DM)", 3 },
                    { 303, "LAS LAGUNAS (DM)", 3 },
                    { 283, "TABARA ABAJO (DM)", 3 },
                    { 282, "AMIAMA GOMEZ (DM)", 3 },
                    { 276, "BARRO ARRIBA (DM)", 3 },
                    { 267, "LOS JOVILLOS (DM)", 3 },
                    { 264, "LAS BARIAS-LA ESTANCIA (DM)", 3 },
                    { 339, "MONTE BONITO (DM)", 3 },
                    { 183, "CRISTO REY DE GUARAGUAO (DM)", 7 },
                    { 182, "AGUA SANTA DEL YUNA (DM)", 7 },
                    { 205, "CENOVI (DM)", 7 },
                    { 50, "JARABACOA", 14 },
                    { 47, "LA VEGA", 14 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 360, "LA CALETA (DM)", 13 },
                    { 296, "CUMAYASA (DM)", 13 },
                    { 295, "VILLA HERMOSA", 13 },
                    { 103, "GUAYMATE", 13 },
                    { 26, "LA ROMANA", 13 },
                    { 379, "BATEY 8 (DM)", 12 },
                    { 323, "VENGAN A VER (DM)", 12 },
                    { 53, "CONSTANZA", 14 },
                    { 316, "BOCA DE CACHON (DM)", 12 },
                    { 238, "EL LIMON (DM)", 12 },
                    { 178, "GUAYABAL (DM)", 12 },
                    { 128, "CRISTOBAL", 12 },
                    { 114, "MELLA", 12 },
                    { 99, "POSTRER RIO", 12 },
                    { 77, "JIMANI", 12 },
                    { 70, "LA DESCUBIERTA", 12 },
                    { 20, "DUVERGE", 12 },
                    { 215, "GUAYABO DULCE (DM)", 11 },
                    { 293, "LA COLONIA (DM)", 12 },
                    { 189, "LA PEÃ‘A (DM)", 7 },
                    { 122, "JIMA ABAJO", 14 },
                    { 181, "RIO VERDE ARRIBA (DM)", 14 },
                    { 201, "SABANA DEL PUERTO (DM)", 16 },
                    { 199, "VILLA SONADOR (DM)", 16 },
                    { 123, "PIEDRA BLANCA", 16 },
                    { 118, "MAIMON", 16 },
                    { 48, "BONAO", 16 },
                    { 347, "ARROYO AL MEDIO (DM)", 15 },
                    { 271, "LAS GORDAS (DM)", 15 },
                    { 213, "EL POZO (DM)", 15 },
                    { 212, "LA ENTRADA (DM)", 15 },
                    { 163, "TIREO ARRIBA (DM)", 14 },
                    { 203, "ARROYO SALADO (DM)", 15 },
                    { 136, "EL FACTOR", 15 },
                    { 81, "RIO SAN JUAN", 15 },
                    { 71, "NAGUA", 15 },
                    { 60, "CABRERA", 15 },
                    { 349, "MANABAO (DM)", 14 },
                    { 300, "BUENA VISTA (DM)", 14 },
                    { 251, "EL RANCHITO (DM)", 14 },
                    { 250, "LA SABINA (DM)", 14 },
                    { 187, "RINCON (DM)", 14 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 165, "SAN JOSE DE MATANZAS (DM)", 15 },
                    { 169, "ELUPINA CORDERO DE LAS CAÃ‘ITAS (DM)", 11 },
                    { 202, "MATA PALACIO (DM)", 11 },
                    { 100, "EL VALLE", 11 },
                    { 144, "JUAN SANTIAGO", 9 },
                    { 110, "EL LLANO", 9 },
                    { 75, "HONDO VALLE", 9 },
                    { 74, "PEDRO SANTANA", 9 },
                    { 16, "COMENDADOR", 9 },
                    { 15, "BANICA", 9 },
                    { 378, "SANTA LUCIA-LA HIGUERA (DM)", 8 },
                    { 367, "SAN FRANCISCO-VICENTILLO (DM)", 8 },
                    { 324, "LA GINA (DM)", 8 },
                    { 168, "YERBA BUENA (DM)", 11 },
                    { 237, "EL JOVERO (EL CEDRO) (DM)", 8 },
                    { 29, "MICHES", 8 },
                    { 25, "EL SEIBO", 8 },
                    { 376, "DON ANTONIO GUZMAN FERNANDEZ (DM)", 7 },
                    { 363, "JAYA (DM)", 7 },
                    { 345, "BARRAQUITO (DM)", 7 },
                    { 344, "EL AGUACATE (DM)", 7 },
                    { 290, "SABANA GRANDE (DM)", 7 },
                    { 266, "LAS COLES (DM)", 7 },
                    { 265, "LAS TARANAS (DM)", 7 },
                    { 166, "PEDRO SANCHEZ (DM)", 8 },
                    { 280, "SABANA LARGA (DM)", 9 },
                    { 159, "RIO LIMPIO (DM)", 9 },
                    { 338, "SABANA CRUZ (DM)", 9 },
                    { 67, "SABANA DE LA MAR", 11 },
                    { 27, "HATO MAYOR", 11 },
                    { 342, "VILLA MAGANTE (DM)", 10 },
                    { 285, "CANCA LA REYNA (DM)", 10 },
                    { 275, "ORTEGA (DM)", 10 },
                    { 274, "MONTE DE LA JAGUA (DM)", 10 },
                    { 273, "HIGUERITO (DM)", 10 },
                    { 240, "VERAGUA (DM)", 10 },
                    { 337, "GUANITO (DM)", 9 },
                    { 208, "JUAN LOPEZ ABAJO (EL MAMEY) (DM)", 10 },
                    { 236, "LAS LAGUNAS ABAJO (DM)", 10 },
                    { 149, "SAN VICTOR (DM)", 10 },
                    { 133, "JAMAO AL NORTE", 10 },
                    { 89, "JOSE CONTRERAS (DM)", 10 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 88, "CAYETANO GERMOSEN", 10 },
                    { 61, "GASPAR HERNANDEZ", 10 },
                    { 54, "MOCA", 10 },
                    { 368, "RANCHO DE LA GUARDIA (DM)", 9 },
                    { 361, "SABANA HIGUERO (DM)", 9 },
                    { 359, "GUAYABO (DM)", 9 },
                    { 162, "JOBA ARRIBA (DM)", 10 }
                });

            migrationBuilder.InsertData(
                table: "TiposSolicitudes",
                columns: new[] { "Id", "CategoriaId", "ComisionAprobacionId", "Nombre" },
                values: new object[,]
                {
                    { 4, 3, 2, "Otros" },
                    { 3, 2, 2, "Construccion" },
                    { 2, 1, 1, "Covid" },
                    { 1, 1, 1, "Cancer" }
                });

            migrationBuilder.InsertData(
                table: "RequisitosTiposSolicitud",
                columns: new[] { "Id", "Descripcion", "FormName", "PossibleValues", "TipoSolicitudId" },
                values: new object[,]
                {
                    { 1, "Comunicacion solicitud del interesado dirigida al CEN", "rdcomunicacion", "", 1 },
                    { 13, "Carta aval de la seccional a la que pertenece", "rdcartaaval", "", 3 },
                    { 12, "Copia de cedula", "rdcopiacedula", "", 3 },
                    { 11, "Comunicacion solicitud del interesado dirigida al CEN", "rdcomunicacion", "", 3 },
                    { 9, "Carta aval de la seccional a la que pertenece", "rdcartaaval", "", 2 },
                    { 8, "Expediente clinico que demuestre diagnostico actualizado", "rdexpendiente", "", 2 },
                    { 10, "ARS a que pertenece", "rdars", "ARS CMD,ARS APS,ARS SIMAG,ARS GRUPO MEDICO ASOCIADO,ARS YUNEN,ARS UNIVERSAL,ARS MONUMENTAL,ARS FUTURO,ARS PRIMERA,ARS ASEMAP,ARS SEMMA,ARS RENACER,ARS PALIC-SALUD,ARS PLAN SALUD,ARS SENASA,ARS RESERVAS,ARS METASALUD,ARS SENASA - REGIMEN SUBSIDIADO", 2 },
                    { 6, "Comunicacion solicitud del interesado dirigida al CEN", "rdcomunicacion", "", 2 },
                    { 5, "ARS a que pertenece", "rdars", "ARS CMD,ARS APS,ARS SIMAG,ARS GRUPO MEDICO ASOCIADO,ARS YUNEN,ARS UNIVERSAL,ARS MONUMENTAL,ARS FUTURO,ARS PRIMERA,ARS ASEMAP,ARS SEMMA,ARS RENACER,ARS PALIC-SALUD,ARS PLAN SALUD,ARS SENASA,ARS RESERVAS,ARS METASALUD,ARS SENASA - REGIMEN SUBSIDIADO", 1 },
                    { 4, "Carta aval de la seccional a la que pertenece", "rdcartaaval", "", 1 },
                    { 3, "Expediente clinico que demuestre diagnostico actualizado", "rdexpendiente", "", 1 },
                    { 2, "Copia de cedula", "rdcopiacedula", "", 1 },
                    { 7, "Copia de cedula", "rdcopiacedula", "", 2 }
                });

            migrationBuilder.InsertData(
                table: "Seccionales",
                columns: new[] { "Id", "MunicipioId", "Nombre", "PresidenteId" },
                values: new object[,]
                {
                    { 104, 65, "Sevicos", null },
                    { 96, 121, "Villa Isabela", null },
                    { 99, 51, "Villa Tapia", null },
                    { 97, 55, "Salcedo", null },
                    { 98, 64, "Tenares", null },
                    { 100, 65, "Samaná", null },
                    { 102, 66, "Sánchez", null },
                    { 36, 139, "Municipio Los Cacaos", null },
                    { 33, 2, "Municipio San Cristóbal", null },
                    { 39, 68, "Municipio Villa Altagracia", null },
                    { 40, 82, "Municipio Yaguaté", null },
                    { 38, 83, "Municipio Palenque ", null },
                    { 35, 93, "Municipio Haina", null },
                    { 91, 120, "Gaunanico", null },
                    { 37, 140, "Municipio Nigua", null },
                    { 101, 134, "Las Terrenas", null },
                    { 93, 102, "Los Hidalgos", null },
                    { 31, 3, "Bani", null },
                    { 94, 40, "Luperón", null },
                    { 88, 72, "Villa Vázquez", null },
                    { 87, 86, "Manzanillo)Pepillo Salcedo", null },
                    { 84, 101, "Castañuela", null },
                    { 86, 117, "Las Matas de Santa Cruz", null },
                    { 143, 4, "Bayaguana", null },
                    { 146, 5, "Yamasa", null },
                    { 142, 8, "Monte Plata", null },
                    { 95, 97, "Sosua", null },
                    { 145, 8, "Sabana Grande de Boyá", null },
                    { 29, 69, null, null }
                });

            migrationBuilder.InsertData(
                table: "Seccionales",
                columns: new[] { "Id", "MunicipioId", "Nombre", "PresidenteId" },
                values: new object[,]
                {
                    { 30, 91, "Municipio Oviedo", null },
                    { 34, 315, "Municipio Cambita", null },
                    { 32, 84, "Municipio Nizao", null },
                    { 89, 37, "Puerto Plata", null },
                    { 92, 38, "Imbert", null },
                    { 90, 39, "Altamira", null },
                    { 144, 153, "Peralvillo", null },
                    { 48, 11, "Municipio Las Matas de Farfán", null },
                    { 118, 292, "Sabaneta", null },
                    { 45, 14, "Municipio El Cercado", null },
                    { 111, 142, "Pedro García", null },
                    { 115, 350, "Puñal", null },
                    { 117, 42, "Moción", null },
                    { 119, 116, "Los Almácigos", null },
                    { 122, 33, "Esperanza", null },
                    { 120, 34, "de Mao", null },
                    { 121, 92, "Laguna Salada", null },
                    { 42, 150, "Municipio Sabana Larga", null },
                    { 41, 152, "Municipio Rancho Arriba", null },
                    { 152, 223, "Santo Domingo Este ", null },
                    { 154, 224, "Santo Domingo Oeste ", null },
                    { 153, 225, "Santo Domingo Norte ", null },
                    { 147, 226, "Boca Chica ", null },
                    { 148, 227, "San Antonio de Guerrera", null },
                    { 151, 228, "Pedro Brand ", null },
                    { 110, 96, "Navarrete", null },
                    { 109, 95, "Licey al medio", null },
                    { 114, 94, "Villa González", null },
                    { 112, 36, "San José de la Matas", null },
                    { 47, 108, "Municipio Vallejuelo", null },
                    { 44, 109, "Municipio Bohechio", null },
                    { 46, 129, "Municipio Juan de Herrera", null },
                    { 85, 45, "Guayubin", null },
                    { 127, 23, "San Pedro", null },
                    { 129, 24, "Los Llanos", null },
                    { 131, 30, "Ramón Santana", null },
                    { 43, 12, null, null },
                    { 128, 138, "Consuelo", null },
                    { 103, 49, "Cotui", null },
                    { 105, 87, "Fantino", null },
                    { 106, 155, "Villa La Mata", null },
                    { 107, 31, "Santiago", null }
                });

            migrationBuilder.InsertData(
                table: "Seccionales",
                columns: new[] { "Id", "MunicipioId", "Nombre", "PresidenteId" },
                values: new object[,]
                {
                    { 116, 31, "Sur Oeste Santiago", null },
                    { 113, 32, "Tamboril", null },
                    { 108, 35, "Janico", null },
                    { 130, 146, "Quisqueya", null },
                    { 83, 41, "Monte Cristi", null },
                    { 76, 71, "Nagua", null },
                    { 81, 118, "Maimón", null },
                    { 10, 21, "Municipio Enriquillo", null },
                    { 17, 79, "Municipio Vicente Noble", null },
                    { 14, 80, "Municipio Paraíso", null },
                    { 16, 111, "Municipio Polo", null },
                    { 15, 130, "Municipio El Peñón", null },
                    { 18, 131, "Municipio  Fundación", null },
                    { 13, 137, "Municipio Las Salinas", null },
                    { 12, 160, "Municipio La Cienaga", null },
                    { 11, 167, "Municipio Jaquimeye", null },
                    { 66, 43, "Restauración", null },
                    { 62, 44, "Dajabón", null },
                    { 64, 73, "Loma de Cabrera", null },
                    { 65, 115, "Partido", null },
                    { 63, 151, "El Pino", null },
                    { 55, 56, "Municipio  San Francisco", null },
                    { 9, 19, "Municipio Cabral", null },
                    { 8, 18, "BARAHONA", null },
                    { 20, 113, "Municipio Galván", null },
                    { 22, 112, "Municipio Los Ríos", null },
                    { 123, 1, "Zona Norte", null },
                    { 124, 1, "Zona Sur", null },
                    { 125, 1, "Zona oeste", null },
                    { 126, 1, "Zona Noroeste", null },
                    { 135, 28, "Higuey", null },
                    { 136, 85, "San Rafael del Yuma", null },
                    { 1, 10, "Municipio Azua", null },
                    { 60, 57, "Municipio Pimentel", null },
                    { 4, 17, "Municipio Padre Las Casas", null },
                    { 5, 106, "Municipio Peralta", null },
                    { 6, 107, "Municipio Sabana Yegua", null },
                    { 3, 125, "Municipio Las Yayas", null },
                    { 7, 126, "Municipio Tabara Arriba", null },
                    { 19, 22, "Municipio Neyba", null },
                    { 21, 76, "Municipio Tamayo", null },
                    { 23, 78, "Municipio Villa Jaragua", null }
                });

            migrationBuilder.InsertData(
                table: "Seccionales",
                columns: new[] { "Id", "MunicipioId", "Nombre", "PresidenteId" },
                values: new object[,]
                {
                    { 2, 105, "Municipio Guayabal", null },
                    { 82, 123, "Piedra Blanca", null },
                    { 61, 58, "Villa Rivas", null },
                    { 58, 63, "Municipio Hostos", null },
                    { 54, 99, "Municipio Poster Rio", null },
                    { 53, 114, "Municipio Mella", null },
                    { 51, 128, "Municipio Cristóbal", null },
                    { 132, 26, "De La Romana", null },
                    { 133, 103, "Guaymate", null },
                    { 134, 295, "Villa Hermosa", null },
                    { 72, 47, "LA VEGA", null },
                    { 74, 50, "Jarabacoa", null },
                    { 73, 53, "Constanza", null },
                    { 75, 122, "Jima Abajo", null },
                    { 77, 60, "Cabrera", null },
                    { 149, 229, "Los Alcarrizos", null },
                    { 79, 81, "Rio San Juan", null },
                    { 78, 136, "El Factor", null },
                    { 80, 48, "Bonao", null },
                    { 49, 77, "Jimani", null },
                    { 52, 70, "Municipio La Descubierta", null },
                    { 50, 20, "Municipio Duverge", null },
                    { 138, 100, "El Valle", null },
                    { 57, 119, "Municipio Arenoso", null },
                    { 59, 143, "Municipio Las Guaranas", null },
                    { 140, 25, "El Seribo", null },
                    { 141, 29, "Miches", null },
                    { 25, 15, "Municipio Banica", null },
                    { 24, 16, "Municipio Comendador", null },
                    { 27, 74, "Municipio Pedro Santana", null },
                    { 56, 59, "Municipio Castillo", null },
                    { 26, 75, "Municipio Hondo Valle", null },
                    { 67, 54, "Moca", null },
                    { 69, 61, "Gaspar Hernández", null },
                    { 68, 88, "Cayetano Germosen", null },
                    { 71, 89, "José Contreras (Villa Trina)", null },
                    { 70, 133, "Jamao Al Norte", null },
                    { 137, 27, "Hato Mayor", null },
                    { 139, 27, "Sabana de la Mar", null },
                    { 28, 110, "Municipio El Llano", null },
                    { 150, 291, "Mendoza San  Luis ", null }
                });

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "ChangePasswordCode", "ChangePasswordCodeExpiration", "Disponible", "Email", "FechaCreacion", "FechaInactivacion", "Login", "MaestroId", "NombreCompleto", "Password", "SeccionalId", "UsuarioIdInactivacion" },
                values: new object[,]
                {
                    { 1, null, null, false, "", new DateTime(2021, 4, 10, 7, 31, 18, 951, DateTimeKind.Local).AddTicks(1743), null, "Sistema", null, "El Sistema", "", 2, null },
                    { 2, null, null, true, "juanv.santim@gmail.com", new DateTime(2021, 4, 10, 7, 31, 18, 952, DateTimeKind.Local).AddTicks(5617), null, "jsanti", null, "Juan Santi", "ai????n5&`?6", 2, null },
                    { 3, null, null, true, "miembro1@gmail.com", new DateTime(2021, 4, 10, 7, 31, 18, 956, DateTimeKind.Local).AddTicks(9291), null, "miembro1", null, "miembro comision 1", "ai????n5&`?6", 2, null },
                    { 4, null, null, true, "miembro2@gmail.com", new DateTime(2021, 4, 10, 7, 31, 18, 957, DateTimeKind.Local).AddTicks(103), null, "miembro2", null, "miembro comision 2", "ai????n5&`?6", 2, null },
                    { 5, null, null, true, "miembro3@gmail.com", new DateTime(2021, 4, 10, 7, 31, 18, 957, DateTimeKind.Local).AddTicks(171), null, "miembro3", null, "miembro comision 3", "ai????n5&`?6", 2, null }
                });

            migrationBuilder.InsertData(
                table: "PermisosUsuarios",
                columns: new[] { "Id", "Disponible", "PermisoId", "UsuarioId" },
                values: new object[,]
                {
                    { 1, true, 1, 1 },
                    { 2, true, 2, 1 },
                    { 3, true, 3, 1 },
                    { 4, true, 4, 1 },
                    { 5, true, 5, 1 },
                    { 6, true, 6, 1 },
                    { 7, true, 7, 1 },
                    { 8, true, 8, 2 }
                });

            migrationBuilder.InsertData(
                table: "UsuariosComisionesAprobacion",
                columns: new[] { "Id", "ComisionAprobacionId", "Disponible", "FechaCreacion", "UsuarioCreacionId", "UsuarioId" },
                values: new object[,]
                {
                    { 3, 1, true, new DateTime(2021, 4, 10, 7, 31, 18, 961, DateTimeKind.Local).AddTicks(9608), 0, 2 },
                    { 1, 1, true, new DateTime(2021, 4, 10, 7, 31, 18, 961, DateTimeKind.Local).AddTicks(8628), 0, 3 },
                    { 2, 1, true, new DateTime(2021, 4, 10, 7, 31, 18, 961, DateTimeKind.Local).AddTicks(9580), 0, 4 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AdjuntosSolicitudesAyuda_SolicitudAyudaId",
                table: "AdjuntosSolicitudesAyuda",
                column: "SolicitudAyudaId");

            migrationBuilder.CreateIndex(
                name: "IX_AprobacionesSolicitudes_EstadoId",
                table: "AprobacionesSolicitudes",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_AprobacionesSolicitudes_SolicitudAyudaId",
                table: "AprobacionesSolicitudes",
                column: "SolicitudAyudaId");

            migrationBuilder.CreateIndex(
                name: "IX_AprobacionesSolicitudes_UsuarioId",
                table: "AprobacionesSolicitudes",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Cambio_MovimientoId",
                table: "Cambio",
                column: "MovimientoId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioSolicitud_SolicitudAyudaId",
                table: "ComentarioSolicitud",
                column: "SolicitudAyudaId");

            migrationBuilder.CreateIndex(
                name: "IX_ComentarioSolicitud_UsuarioId",
                table: "ComentarioSolicitud",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_Maestros_SeccionalId",
                table: "Maestros",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosUsuarios_PermisoId",
                table: "PermisosUsuarios",
                column: "PermisoId");

            migrationBuilder.CreateIndex(
                name: "IX_PermisosUsuarios_UsuarioId",
                table: "PermisosUsuarios",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosSolicitudes_RequisitoTiposSolicitudId",
                table: "RequisitosSolicitudes",
                column: "RequisitoTiposSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosSolicitudes_SolicitudAyudaId",
                table: "RequisitosSolicitudes",
                column: "SolicitudAyudaId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosTiposSolicitud_TipoSolicitudId",
                table: "RequisitosTiposSolicitud",
                column: "TipoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Seccionales_MunicipioId",
                table: "Seccionales",
                column: "MunicipioId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAyuda_BancoId",
                table: "SolicitudesAyuda",
                column: "BancoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAyuda_EstadoId",
                table: "SolicitudesAyuda",
                column: "EstadoId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAyuda_MaestroId",
                table: "SolicitudesAyuda",
                column: "MaestroId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAyuda_SeccionalId",
                table: "SolicitudesAyuda",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAyuda_TipoSolicitudId",
                table: "SolicitudesAyuda",
                column: "TipoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAyuda_UsuarioId",
                table: "SolicitudesAyuda",
                column: "UsuarioId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposSolicitudes_CategoriaId",
                table: "TiposSolicitudes",
                column: "CategoriaId");

            migrationBuilder.CreateIndex(
                name: "IX_TiposSolicitudes_ComisionAprobacionId",
                table: "TiposSolicitudes",
                column: "ComisionAprobacionId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MaestroId",
                table: "Usuarios",
                column: "MaestroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SeccionalId",
                table: "Usuarios",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComisionesAprobacion_ComisionAprobacionId",
                table: "UsuariosComisionesAprobacion",
                column: "ComisionAprobacionId");

            migrationBuilder.CreateIndex(
                name: "IX_UsuariosComisionesAprobacion_UsuarioId",
                table: "UsuariosComisionesAprobacion",
                column: "UsuarioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AdjuntosSolicitudesAyuda");

            migrationBuilder.DropTable(
                name: "AprobacionesSolicitudes");

            migrationBuilder.DropTable(
                name: "Cambio");

            migrationBuilder.DropTable(
                name: "ComentarioSolicitud");

            migrationBuilder.DropTable(
                name: "PermisosUsuarios");

            migrationBuilder.DropTable(
                name: "RequisitosSolicitudes");

            migrationBuilder.DropTable(
                name: "UsuariosComisionesAprobacion");

            migrationBuilder.DropTable(
                name: "Movimientos");

            migrationBuilder.DropTable(
                name: "Permisos");

            migrationBuilder.DropTable(
                name: "RequisitosTiposSolicitud");

            migrationBuilder.DropTable(
                name: "SolicitudesAyuda");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropTable(
                name: "EstadoSolicitudes");

            migrationBuilder.DropTable(
                name: "TiposSolicitudes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "CategoriasTiposSolicitudes");

            migrationBuilder.DropTable(
                name: "ComisionesAprobacion");

            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropTable(
                name: "Seccionales");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Provincias");

            migrationBuilder.DropSequence(
                name: "NumeroExpendiente",
                schema: "dbo");
        }
    }
}
