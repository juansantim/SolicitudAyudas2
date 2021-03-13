using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init6 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Seccionales_SeccionalId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_SeccionalId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SeccionalId",
                table: "Usuarios");

            migrationBuilder.CreateTable(
                name: "Banco",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Banco", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Banco",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "BanReservas (Banco de Reservas)" },
                    { 29, "Banco Del Caribe" },
                    { 31, "Banco Gruficorp" },
                    { 32, "Banco Cofaci" },
                    { 33, "Banco Bonanza" },
                    { 34, "Banco Fihogar" },
                    { 35, "Banco Federal" },
                    { 36, "Banco Micro" },
                    { 37, "Banco Union" },
                    { 38, "Asociación Popular" },
                    { 39, "Asociación Popular de Ahorros y Préstamos" },
                    { 28, "Banco Rio" },
                    { 40, "Asociación Cibao" },
                    { 42, "Asociación Peravia" },
                    { 43, "Asociación Romana" },
                    { 44, "Asociación Higuamo" },
                    { 45, "Asociación La Vega Real" },
                    { 46, "Asociación Duarte" },
                    { 47, "Asociación Barahona" },
                    { 48, "Asociación Maguana" },
                    { 49, "Asociación Mocana" },
                    { 50, "Asociación Bonao" },
                    { 51, "Asociación La Nacional" },
                    { 41, "Asociación Nortena" },
                    { 27, "Banco Motor Crédito" },
                    { 30, "Banco Inmobiliario (Banaci)" },
                    { 25, "Banco Confisa" },
                    { 2, "Banco Popular Dominicano" },
                    { 3, "Banco Agrícola" },
                    { 4, "Banco BHD León" },
                    { 5, "Banco Vimenca" },
                    { 6, "Banco Santa Cruz" },
                    { 7, "Banco Caribe" },
                    { 8, "Banco BDI" },
                    { 9, "Banco López de Haro" },
                    { 26, "Banco Empire" },
                    { 11, "Banco BELLBANK" },
                    { 12, "Banco Múltiple Activo Dominicana" },
                    { 13, "Scotiabank" },
                    { 10, "Banco Ademi" },
                    { 15, "Banco Promerica" },
                    { 24, "Banco Capital" }
                });

            migrationBuilder.InsertData(
                table: "Banco",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 14, "Citibank" },
                    { 22, "Banco Agrícola De La República Dominicana" },
                    { 21, "Banco Adopem" },
                    { 23, "Banco Pyme Bhd" },
                    { 19, "Banco Bancotui" },
                    { 18, "Banco Atlántico" },
                    { 17, "Bancamerica" },
                    { 16, "Banesco" },
                    { 20, "Banco BDA" }
                });

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SecconalId",
                table: "Usuarios",
                column: "SecconalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Seccionales_SecconalId",
                table: "Usuarios",
                column: "SecconalId",
                principalTable: "Seccionales",
                principalColumn: "Id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Seccionales_SecconalId",
                table: "Usuarios");

            migrationBuilder.DropTable(
                name: "Banco");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_SecconalId",
                table: "Usuarios");

            migrationBuilder.AddColumn<int>(
                name: "SeccionalId",
                table: "Usuarios",
                type: "int",
                nullable: true);

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

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SeccionalId",
                table: "Usuarios",
                column: "SeccionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Seccionales_SeccionalId",
                table: "Usuarios",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id");
        }
    }
}
