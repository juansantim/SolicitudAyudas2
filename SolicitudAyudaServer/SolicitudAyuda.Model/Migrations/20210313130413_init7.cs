using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init7 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Seccionales_SecconalId",
                table: "Usuarios");

            migrationBuilder.RenameColumn(
                name: "SecconalId",
                table: "Usuarios",
                newName: "SeccionalId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_SecconalId",
                table: "Usuarios",
                newName: "IX_Usuarios_SeccionalId");

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

            migrationBuilder.RenameColumn(
                name: "SeccionalId",
                table: "Usuarios",
                newName: "SecconalId");

            migrationBuilder.RenameIndex(
                name: "IX_Usuarios_SeccionalId",
                table: "Usuarios",
                newName: "IX_Usuarios_SecconalId");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 8, 57, 42, 559, DateTimeKind.Local).AddTicks(1460));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 8, 57, 42, 560, DateTimeKind.Local).AddTicks(3853));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 8, 57, 42, 565, DateTimeKind.Local).AddTicks(6778));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 8, 57, 42, 565, DateTimeKind.Local).AddTicks(7267));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 8, 57, 42, 565, DateTimeKind.Local).AddTicks(7317));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 8, 57, 42, 569, DateTimeKind.Local).AddTicks(7268));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 8, 57, 42, 569, DateTimeKind.Local).AddTicks(8346));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 13, 8, 57, 42, 569, DateTimeKind.Local).AddTicks(8370));

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Seccionales_SecconalId",
                table: "Usuarios",
                column: "SecconalId",
                principalTable: "Seccionales",
                principalColumn: "Id");
        }
    }
}
