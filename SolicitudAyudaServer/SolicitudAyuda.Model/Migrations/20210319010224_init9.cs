using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init9 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DebeCambiarPassword",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "TempPassword",
                table: "Usuarios");

            migrationBuilder.AddColumn<string>(
                name: "ChangePasswordCode",
                table: "Usuarios",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "ChangePasswordCodeExpiration",
                table: "Usuarios",
                type: "datetime2",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 18, 21, 2, 23, 147, DateTimeKind.Local).AddTicks(7214));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 18, 21, 2, 23, 149, DateTimeKind.Local).AddTicks(6));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 18, 21, 2, 23, 156, DateTimeKind.Local).AddTicks(6320));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 18, 21, 2, 23, 156, DateTimeKind.Local).AddTicks(6802));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 18, 21, 2, 23, 156, DateTimeKind.Local).AddTicks(6858));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 18, 21, 2, 23, 161, DateTimeKind.Local).AddTicks(1338));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 18, 21, 2, 23, 161, DateTimeKind.Local).AddTicks(2231));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 18, 21, 2, 23, 161, DateTimeKind.Local).AddTicks(2257));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ChangePasswordCode",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "ChangePasswordCodeExpiration",
                table: "Usuarios");

            migrationBuilder.AddColumn<bool>(
                name: "DebeCambiarPassword",
                table: "Usuarios",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "TempPassword",
                table: "Usuarios",
                type: "nvarchar(10)",
                maxLength: 10,
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
        }
    }
}
