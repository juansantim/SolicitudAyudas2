using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class boon : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "TiposSolictudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSolictudes", x => x.Id);
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
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PossibleValues = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosTiposSolicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosTiposSolicitud_TiposSolictudes_TipoSolicitudId",
                        column: x => x.TipoSolicitudId,
                        principalTable: "TiposSolictudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seccionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
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
                    Nombre = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PrimeroApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SegundoApellido = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeccionalId = table.Column<int>(type: "int", nullable: true),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maestros_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "TiposSolictudes",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 1, "Salud" });

            migrationBuilder.InsertData(
                table: "TiposSolictudes",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 2, "Construccion" });

            migrationBuilder.InsertData(
                table: "RequisitosTiposSolicitud",
                columns: new[] { "Id", "Nombre", "PossibleValues", "TipoSolicitudId" },
                values: new object[,]
                {
                    { 1, "Comunicacion solicitud del interesado dirigida al CEN", "", 1 },
                    { 2, "Copia de cedula", "", 1 },
                    { 3, "Expediente clinico que demuestre diagnostico actualizado", "", 1 },
                    { 4, "Carta aval de la seccional a la que pertenece", "", 1 },
                    { 5, "ARS a que pertenece", "ARS CMD,ARS APS,ARS SIMAG,ARS GRUPO MEDICO ASOCIADO,ARS YUNEN,ARS UNIVERSAL,ARS MONUMENTAL,ARS FUTURO,ARS PRIMERA,ARS ASEMAP,ARS SEMMA,ARS RENACER,ARS PALIC-SALUD,ARS PLAN SALUD,ARS SENASA,ARS RESERVAS,ARS METASALUD,ARS SENASA - REGIMEN SUBSIDIADO", 1 },
                    { 6, "Comunicacion solicitud del interesado dirigida al CEN", "", 2 },
                    { 7, "Copia de cedula", "", 2 },
                    { 8, "Carta aval de la seccional a la que pertenece", "", 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maestros_SeccionalId",
                table: "Maestros",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosTiposSolicitud_TipoSolicitudId",
                table: "RequisitosTiposSolicitud",
                column: "TipoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Seccionales_MunicipioId",
                table: "Seccionales",
                column: "MunicipioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropTable(
                name: "RequisitosTiposSolicitud");

            migrationBuilder.DropTable(
                name: "Seccionales");

            migrationBuilder.DropTable(
                name: "TiposSolictudes");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}
