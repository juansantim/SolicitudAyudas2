using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class usersConfigurationSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 11, 9, 21, 45, 115, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.InsertData(
                table: "Usuarios",
                columns: new[] { "Id", "DebeCambiarPassword", "Disponible", "FechaCreacion", "FechaInactivacion", "Login", "NombreCompleto", "Password", "TempPassword", "UsuarioIdInactivacion" },
                values: new object[] { 2, false, true, new DateTime(2021, 2, 11, 9, 21, 45, 116, DateTimeKind.Local).AddTicks(9345), null, "jsanti", "Juan Santi", "ai????n5&`?6", null, null });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 11, 9, 17, 3, 152, DateTimeKind.Local).AddTicks(4602));
        }
    }
}
