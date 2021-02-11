using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class usersAddEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "Usuarios",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "FechaCreacion" },
                values: new object[] { "", new DateTime(2021, 2, 11, 11, 10, 24, 651, DateTimeKind.Local).AddTicks(761) });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "FechaCreacion" },
                values: new object[] { "juanv.santim@gmail.com", new DateTime(2021, 2, 11, 11, 10, 24, 652, DateTimeKind.Local).AddTicks(4483) });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Email",
                table: "Usuarios");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 11, 9, 21, 45, 115, DateTimeKind.Local).AddTicks(6459));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 2, 11, 9, 21, 45, 116, DateTimeKind.Local).AddTicks(9345));
        }
    }
}
