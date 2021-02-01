using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class seccionales : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

            migrationBuilder.CreateIndex(
                name: "IX_Maestros_SeccionalId",
                table: "Maestros",
                column: "SeccionalId");

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
                name: "Seccionales");
        }
    }
}
