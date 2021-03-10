using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Seccionales_SeccionalId",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 54, 32, 98, DateTimeKind.Local).AddTicks(899));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 54, 32, 99, DateTimeKind.Local).AddTicks(4299));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 54, 32, 103, DateTimeKind.Local).AddTicks(8554));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 54, 32, 103, DateTimeKind.Local).AddTicks(9012));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 54, 32, 103, DateTimeKind.Local).AddTicks(9062));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 54, 32, 107, DateTimeKind.Local).AddTicks(8914));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 54, 32, 107, DateTimeKind.Local).AddTicks(9810));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 54, 32, 107, DateTimeKind.Local).AddTicks(9837));

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Seccionales_SeccionalId",
                table: "Usuarios",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Seccionales_SeccionalId",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 8, 15, 2, 2, 637, DateTimeKind.Local).AddTicks(174));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 8, 15, 2, 2, 638, DateTimeKind.Local).AddTicks(5145));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 8, 15, 2, 2, 647, DateTimeKind.Local).AddTicks(1002));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 8, 15, 2, 2, 647, DateTimeKind.Local).AddTicks(1607));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 8, 15, 2, 2, 647, DateTimeKind.Local).AddTicks(1649));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 8, 15, 2, 2, 652, DateTimeKind.Local).AddTicks(9575));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 8, 15, 2, 2, 653, DateTimeKind.Local).AddTicks(1269));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 8, 15, 2, 2, 653, DateTimeKind.Local).AddTicks(1320));

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Seccionales_SeccionalId",
                table: "Usuarios",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
