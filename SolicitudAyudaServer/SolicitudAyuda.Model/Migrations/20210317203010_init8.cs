using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init8 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BancoId",
                table: "SolicitudesAyuda",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "NumeroCuentaBanco",
                table: "SolicitudesAyuda",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 17, 16, 30, 9, 28, DateTimeKind.Local).AddTicks(2345));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 17, 16, 30, 9, 29, DateTimeKind.Local).AddTicks(6741));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 17, 16, 30, 9, 34, DateTimeKind.Local).AddTicks(4189));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 17, 16, 30, 9, 34, DateTimeKind.Local).AddTicks(4592));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 17, 16, 30, 9, 34, DateTimeKind.Local).AddTicks(4627));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 17, 16, 30, 9, 38, DateTimeKind.Local).AddTicks(4871));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 17, 16, 30, 9, 38, DateTimeKind.Local).AddTicks(5742));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 17, 16, 30, 9, 38, DateTimeKind.Local).AddTicks(5765));

            migrationBuilder.CreateIndex(
                name: "IX_SolicitudesAyuda_BancoId",
                table: "SolicitudesAyuda",
                column: "BancoId");

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesAyuda_Banco_BancoId",
                table: "SolicitudesAyuda",
                column: "BancoId",
                principalTable: "Banco",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesAyuda_Banco_BancoId",
                table: "SolicitudesAyuda");

            migrationBuilder.DropIndex(
                name: "IX_SolicitudesAyuda_BancoId",
                table: "SolicitudesAyuda");

            migrationBuilder.DropColumn(
                name: "BancoId",
                table: "SolicitudesAyuda");

            migrationBuilder.DropColumn(
                name: "NumeroCuentaBanco",
                table: "SolicitudesAyuda");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 9, 4, 12, 323, DateTimeKind.Local).AddTicks(2717));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 9, 4, 12, 324, DateTimeKind.Local).AddTicks(7161));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 9, 4, 12, 330, DateTimeKind.Local).AddTicks(1208));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 9, 4, 12, 330, DateTimeKind.Local).AddTicks(1674));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 9, 4, 12, 330, DateTimeKind.Local).AddTicks(1728));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 9, 4, 12, 334, DateTimeKind.Local).AddTicks(4217));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 9, 4, 12, 334, DateTimeKind.Local).AddTicks(5740));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 9, 4, 12, 334, DateTimeKind.Local).AddTicks(5811));
        }
    }
}
