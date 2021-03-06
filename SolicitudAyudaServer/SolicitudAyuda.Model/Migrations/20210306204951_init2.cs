using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class init2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitosTiposSolicitud_TiposSolictudes_TipoSolicitudId",
                table: "RequisitosTiposSolicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesAyuda_TiposSolictudes_TipoSolicitudId",
                table: "SolicitudesAyuda");

            migrationBuilder.DropForeignKey(
                name: "FK_TiposSolictudes_CategoriasTiposSolicitudes_CategoriaId",
                table: "TiposSolictudes");

            migrationBuilder.DropForeignKey(
                name: "FK_TiposSolictudes_ComisionesAprobacion_ComisionAprobacionId",
                table: "TiposSolictudes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposSolictudes",
                table: "TiposSolictudes");

            migrationBuilder.RenameTable(
                name: "TiposSolictudes",
                newName: "TiposSolicitudes");

            migrationBuilder.RenameIndex(
                name: "IX_TiposSolictudes_ComisionAprobacionId",
                table: "TiposSolicitudes",
                newName: "IX_TiposSolicitudes_ComisionAprobacionId");

            migrationBuilder.RenameIndex(
                name: "IX_TiposSolictudes_CategoriaId",
                table: "TiposSolicitudes",
                newName: "IX_TiposSolicitudes_CategoriaId");

            migrationBuilder.AddColumn<int>(
                name: "MaestroId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SeccionalId",
                table: "Usuarios",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SecconalId",
                table: "Usuarios",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposSolicitudes",
                table: "TiposSolicitudes",
                column: "Id");

            migrationBuilder.InsertData(
                table: "Permisos",
                columns: new[] { "Id", "Nombre" },
                values: new object[] { 8, "Gestionar Usuarios" });

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 6, 16, 49, 49, 689, DateTimeKind.Local).AddTicks(4147));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 6, 16, 49, 49, 690, DateTimeKind.Local).AddTicks(6334));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 6, 16, 49, 49, 695, DateTimeKind.Local).AddTicks(2173));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 6, 16, 49, 49, 695, DateTimeKind.Local).AddTicks(2791));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 6, 16, 49, 49, 695, DateTimeKind.Local).AddTicks(2845));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 6, 16, 49, 49, 699, DateTimeKind.Local).AddTicks(4626));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 6, 16, 49, 49, 699, DateTimeKind.Local).AddTicks(5562));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 6, 16, 49, 49, 699, DateTimeKind.Local).AddTicks(5588));

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_MaestroId",
                table: "Usuarios",
                column: "MaestroId");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_SeccionalId",
                table: "Usuarios",
                column: "SeccionalId");

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitosTiposSolicitud_TiposSolicitudes_TipoSolicitudId",
                table: "RequisitosTiposSolicitud",
                column: "TipoSolicitudId",
                principalTable: "TiposSolicitudes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesAyuda_TiposSolicitudes_TipoSolicitudId",
                table: "SolicitudesAyuda",
                column: "TipoSolicitudId",
                principalTable: "TiposSolicitudes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TiposSolicitudes_CategoriasTiposSolicitudes_CategoriaId",
                table: "TiposSolicitudes",
                column: "CategoriaId",
                principalTable: "CategoriasTiposSolicitudes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposSolicitudes_ComisionesAprobacion_ComisionAprobacionId",
                table: "TiposSolicitudes",
                column: "ComisionAprobacionId",
                principalTable: "ComisionesAprobacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Maestros_MaestroId",
                table: "Usuarios",
                column: "MaestroId",
                principalTable: "Maestros",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Usuarios_Seccionales_SeccionalId",
                table: "Usuarios",
                column: "SeccionalId",
                principalTable: "Seccionales",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RequisitosTiposSolicitud_TiposSolicitudes_TipoSolicitudId",
                table: "RequisitosTiposSolicitud");

            migrationBuilder.DropForeignKey(
                name: "FK_SolicitudesAyuda_TiposSolicitudes_TipoSolicitudId",
                table: "SolicitudesAyuda");

            migrationBuilder.DropForeignKey(
                name: "FK_TiposSolicitudes_CategoriasTiposSolicitudes_CategoriaId",
                table: "TiposSolicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_TiposSolicitudes_ComisionesAprobacion_ComisionAprobacionId",
                table: "TiposSolicitudes");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Maestros_MaestroId",
                table: "Usuarios");

            migrationBuilder.DropForeignKey(
                name: "FK_Usuarios_Seccionales_SeccionalId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_MaestroId",
                table: "Usuarios");

            migrationBuilder.DropIndex(
                name: "IX_Usuarios_SeccionalId",
                table: "Usuarios");

            migrationBuilder.DropPrimaryKey(
                name: "PK_TiposSolicitudes",
                table: "TiposSolicitudes");

            migrationBuilder.DeleteData(
                table: "Permisos",
                keyColumn: "Id",
                keyValue: 8);

            migrationBuilder.DropColumn(
                name: "MaestroId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SeccionalId",
                table: "Usuarios");

            migrationBuilder.DropColumn(
                name: "SecconalId",
                table: "Usuarios");

            migrationBuilder.RenameTable(
                name: "TiposSolicitudes",
                newName: "TiposSolictudes");

            migrationBuilder.RenameIndex(
                name: "IX_TiposSolicitudes_ComisionAprobacionId",
                table: "TiposSolictudes",
                newName: "IX_TiposSolictudes_ComisionAprobacionId");

            migrationBuilder.RenameIndex(
                name: "IX_TiposSolicitudes_CategoriaId",
                table: "TiposSolictudes",
                newName: "IX_TiposSolictudes_CategoriaId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_TiposSolictudes",
                table: "TiposSolictudes",
                column: "Id");

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 2, 11, 33, 39, 145, DateTimeKind.Local).AddTicks(9585));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 2, 11, 33, 39, 148, DateTimeKind.Local).AddTicks(2000));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 2, 11, 33, 39, 155, DateTimeKind.Local).AddTicks(6910));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 4,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 2, 11, 33, 39, 155, DateTimeKind.Local).AddTicks(7388));

            migrationBuilder.UpdateData(
                table: "Usuarios",
                keyColumn: "Id",
                keyValue: 5,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 2, 11, 33, 39, 155, DateTimeKind.Local).AddTicks(7425));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 1,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 2, 11, 33, 39, 163, DateTimeKind.Local).AddTicks(5160));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 2,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 2, 11, 33, 39, 163, DateTimeKind.Local).AddTicks(6905));

            migrationBuilder.UpdateData(
                table: "UsuariosComisionesAprobacion",
                keyColumn: "Id",
                keyValue: 3,
                column: "FechaCreacion",
                value: new DateTime(2021, 3, 2, 11, 33, 39, 163, DateTimeKind.Local).AddTicks(6966));

            migrationBuilder.AddForeignKey(
                name: "FK_RequisitosTiposSolicitud_TiposSolictudes_TipoSolicitudId",
                table: "RequisitosTiposSolicitud",
                column: "TipoSolicitudId",
                principalTable: "TiposSolictudes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_SolicitudesAyuda_TiposSolictudes_TipoSolicitudId",
                table: "SolicitudesAyuda",
                column: "TipoSolicitudId",
                principalTable: "TiposSolictudes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_TiposSolictudes_CategoriasTiposSolicitudes_CategoriaId",
                table: "TiposSolictudes",
                column: "CategoriaId",
                principalTable: "CategoriasTiposSolicitudes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_TiposSolictudes_ComisionesAprobacion_ComisionAprobacionId",
                table: "TiposSolictudes",
                column: "ComisionAprobacionId",
                principalTable: "ComisionesAprobacion",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
