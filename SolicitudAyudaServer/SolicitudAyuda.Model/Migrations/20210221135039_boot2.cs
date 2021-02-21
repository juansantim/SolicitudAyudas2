using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class boot2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 11,
                column: "TipoSolicitudId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 12,
                column: "TipoSolicitudId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 13,
                column: "TipoSolicitudId",
                value: 3);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 50, 38, 751, DateTimeKind.Local).AddTicks(6023));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 50, 38, 752, DateTimeKind.Local).AddTicks(9737));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 50, 38, 757, DateTimeKind.Local).AddTicks(2056));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 50, 38, 757, DateTimeKind.Local).AddTicks(2507));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 50, 38, 761, DateTimeKind.Local).AddTicks(8789));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 50, 38, 761, DateTimeKind.Local).AddTicks(9741));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 11,
                column: "TipoSolicitudId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 12,
                column: "TipoSolicitudId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "RequisitosTiposSolicitud",
                keyColumn: "Id",
                keyValue: 13,
                column: "TipoSolicitudId",
                value: 2);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 44, 18, 550, DateTimeKind.Local).AddTicks(914));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 44, 18, 551, DateTimeKind.Local).AddTicks(5290));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 44, 18, 556, DateTimeKind.Local).AddTicks(3202));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 44, 18, 556, DateTimeKind.Local).AddTicks(3781));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 44, 18, 561, DateTimeKind.Local).AddTicks(628));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 21, 9, 44, 18, 561, DateTimeKind.Local).AddTicks(1612));
        }
    }
}
