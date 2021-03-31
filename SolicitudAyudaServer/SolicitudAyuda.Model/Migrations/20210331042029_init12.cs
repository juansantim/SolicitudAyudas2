using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init12 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitosSolicitudes_RequisitosTiposSolicitud_RequisitoTipoSolicitudId",
                table: "RequisitosSolicitudes");

            migrationBuilder.DropIndex(
                name: "IX_RequisitosSolicitudes_RequisitoTipoSolicitudId",
                table: "RequisitosSolicitudes");

            migrationBuilder.DropColumn(
                name: "RequisitoTipoSolicitudId",
                table: "RequisitosSolicitudes");

            migrationBuilder.AddColumn<bool>(
                name: "ActaMatrimonioUnion",
                table: "SolicitudesAyuda",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "ActaNacimientoHijoHija",
                table: "SolicitudesAyuda",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "CopiaCedulaPadreMadre",
                table: "SolicitudesAyuda",
                type: "bit",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "RequisitosSolicitudes",
                type: "nvarchar(255)",
                maxLength: 255,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 31, 0, 20, 27, 983, DateTimeKind.Local).AddTicks(8293));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 31, 0, 20, 27, 984, DateTimeKind.Local).AddTicks(9994));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 31, 0, 20, 27, 989, DateTimeKind.Local).AddTicks(3575));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 31, 0, 20, 27, 989, DateTimeKind.Local).AddTicks(4050));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 31, 0, 20, 27, 989, DateTimeKind.Local).AddTicks(4186));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 31, 0, 20, 27, 993, DateTimeKind.Local).AddTicks(6009));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 31, 0, 20, 27, 993, DateTimeKind.Local).AddTicks(9206));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 31, 0, 20, 27, 993, DateTimeKind.Local).AddTicks(9242));

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosSolicitudes_RequisitoTiposSolicitudId",
                table: "RequisitosSolicitudes",
                column: "RequisitoTiposSolicitudId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitosSolicitudes_RequisitosTiposSolicitud_RequisitoTiposSolicitudId",
                table: "RequisitosSolicitudes",
                column: "RequisitoTiposSolicitudId",
                principalTable: "RequisitosTiposSolicitud",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitosSolicitudes_RequisitosTiposSolicitud_RequisitoTiposSolicitudId",
                table: "RequisitosSolicitudes");

            migrationBuilder.DropIndex(
                name: "IX_RequisitosSolicitudes_RequisitoTiposSolicitudId",
                table: "RequisitosSolicitudes");

            migrationBuilder.DropColumn(
                name: "ActaMatrimonioUnion",
                table: "SolicitudesAyuda");

            migrationBuilder.DropColumn(
                name: "ActaNacimientoHijoHija",
                table: "SolicitudesAyuda");

            migrationBuilder.DropColumn(
                name: "CopiaCedulaPadreMadre",
                table: "SolicitudesAyuda");

            migrationBuilder.AlterColumn<string>(
                name: "Value",
                table: "RequisitosSolicitudes",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(255)",
                oldMaxLength: 255,
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RequisitoTipoSolicitudId",
                table: "RequisitosSolicitudes",
                type: "int",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 22, 36, 10, 698, DateTimeKind.Local).AddTicks(8079));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 22, 36, 10, 700, DateTimeKind.Local).AddTicks(698));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 22, 36, 10, 709, DateTimeKind.Local).AddTicks(2728));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 22, 36, 10, 709, DateTimeKind.Local).AddTicks(3210));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 22, 36, 10, 709, DateTimeKind.Local).AddTicks(3263));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 22, 36, 10, 713, DateTimeKind.Local).AddTicks(5003));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 22, 36, 10, 713, DateTimeKind.Local).AddTicks(5878));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 22, 36, 10, 713, DateTimeKind.Local).AddTicks(5904));

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosSolicitudes_RequisitoTipoSolicitudId",
                table: "RequisitosSolicitudes",
                column: "RequisitoTipoSolicitudId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitosSolicitudes_RequisitosTiposSolicitud_RequisitoTipoSolicitudId",
                table: "RequisitosSolicitudes",
                column: "RequisitoTipoSolicitudId",
                principalTable: "RequisitosTiposSolicitud",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
