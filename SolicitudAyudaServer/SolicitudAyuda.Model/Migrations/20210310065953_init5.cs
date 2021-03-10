using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 59, 52, 110, DateTimeKind.Local).AddTicks(4682));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 59, 52, 111, DateTimeKind.Local).AddTicks(7667));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 59, 52, 116, DateTimeKind.Local).AddTicks(1285));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 59, 52, 116, DateTimeKind.Local).AddTicks(1716));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 59, 52, 116, DateTimeKind.Local).AddTicks(1767));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 59, 52, 120, DateTimeKind.Local).AddTicks(3837));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 59, 52, 120, DateTimeKind.Local).AddTicks(6321));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 10, 2, 59, 52, 120, DateTimeKind.Local).AddTicks(6392));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
        }
    }
}
