using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class updateTipoSolictudes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
                name: "RequisitosTiposSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    Nombre = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true)
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

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosTiposSolicitud_TipoSolicitudId",
                table: "RequisitosTiposSolicitud",
                column: "TipoSolicitudId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RequisitosTiposSolicitud");

            migrationBuilder.DropTable(
                name: "TiposSolictudes");
        }
    }
}
