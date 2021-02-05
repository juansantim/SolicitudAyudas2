using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class boon2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Nombre",
                table: "RequisitosTiposSolicitud",
                newName: "Descripcion");

            migrationBuilder.AddColumn<string>(
                name: "FormName",
                table: "RequisitosTiposSolicitud",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 1,
                column: "FormName",
                value: "rdcomunicacion");

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 2,
                column: "FormName",
                value: "rdcopiacedula");

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 3,
                column: "FormName",
                value: "rdexpendiente");

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 4,
                column: "FormName",
                value: "rdcartaaval");

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 5,
                column: "FormName",
                value: "rdars");

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 6,
                column: "FormName",
                value: "rdcomunicacion");

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 7,
                column: "FormName",
                value: "rdcopiacedula");

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 8,
                column: "FormName",
                value: "rdcartaaval");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FormName",
                table: "RequisitosTiposSolicitud");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "RequisitosTiposSolicitud",
                newName: "Nombre");
        }
    }
}
