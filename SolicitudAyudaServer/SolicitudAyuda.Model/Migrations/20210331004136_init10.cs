using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init10 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Permisos",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 1,
                column: "Descripcion",
                value: "Entrar y consultar por diferentes criterios");

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 2,
                column: "Descripcion",
                value: "Registrar una solicitud");

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 4,
                column: "Descripcion",
                value: "Rechazar solicitud por cualquier motivo");

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 5,
                column: "Descripcion",
                value: "Anular una solicitud, siempre y cuando no se encuentre aprobada");

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 6,
                column: "Descripcion",
                value: "Consultar informaciones de afiliado");

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 7,
                column: "Descripcion",
                value: "Generar reportes");

            migrationBuilder.UpdateData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 8,
                column: "Descripcion",
                value: "Crear, modificar y deshabilitar usuarios");

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "Descripcion", "Nombre" },
                values: new object[] { 9, "Modificar, monto solicitado, banco y numero de cuenta de la solicitud", "Modificar Solicitud" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 20, 41, 35, 100, DateTimeKind.Local).AddTicks(5577));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 20, 41, 35, 101, DateTimeKind.Local).AddTicks(7747));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 20, 41, 35, 110, DateTimeKind.Local).AddTicks(9273));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 20, 41, 35, 110, DateTimeKind.Local).AddTicks(9660));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 20, 41, 35, 110, DateTimeKind.Local).AddTicks(9711));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 20, 41, 35, 115, DateTimeKind.Local).AddTicks(428));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 20, 41, 35, 115, DateTimeKind.Local).AddTicks(1344));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 30, 20, 41, 35, 115, DateTimeKind.Local).AddTicks(1374));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 9);

            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Permisos");

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
    }
}
