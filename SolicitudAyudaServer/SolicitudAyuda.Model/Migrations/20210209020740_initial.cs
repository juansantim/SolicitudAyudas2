﻿using Microsoft.EntityFrameworkCore.Migrations;

namespace SolicitudAyuda.Model.Migrations
{
    public partial class initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Provincias",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(30)", maxLength: 30, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provincias", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TiposSolictudes",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TiposSolictudes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Municipios",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(40)", maxLength: 40, nullable: true),
                    ProvinciaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Municipios", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Municipios_Provincias_ProvinciaId",
                        column: x => x.ProvinciaId,
                        principalTable: "Provincias",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RequisitosTiposSolicitud",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TipoSolicitudId = table.Column<int>(type: "int", nullable: false),
                    FormName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Descripcion = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: true),
                    PossibleValues = table.Column<string>(type: "nvarchar(4000)", maxLength: 4000, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RequisitosTiposSolicitud", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RequisitosTiposSolicitud_TiposSolictudes_TipoSolicitudId",
                        column: x => x.TipoSolicitudId,
                        principalTable: "TiposSolictudes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seccionales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombre = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    MunicipioId = table.Column<int>(type: "int", nullable: false),
                    PresidenteId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seccionales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seccionales_Municipios_MunicipioId",
                        column: x => x.MunicipioId,
                        principalTable: "Municipios",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Maestros",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cedula = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    NombreCompleto = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Sexo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SeccionalId = table.Column<int>(type: "int", nullable: false),
                    Cargo = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maestros", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Maestros_Seccionales_SeccionalId",
                        column: x => x.SeccionalId,
                        principalTable: "Seccionales",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Provincias",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "DISTRITO NACIONAL" },
                    { 32, "SANTO DOMINGO" },
                    { 31, "SAN JOSE DE OCOA" },
                    { 30, "VALVERDE" },
                    { 29, "SANTIAGO RODRIGUEZ" },
                    { 28, "SANTIAGO DE LOS CABALLEROS" },
                    { 27, "SANCHEZ RAMIREZ" },
                    { 26, "SAN PEDRO DE MACORIS" },
                    { 25, "SAN JUAN DE LA MAGUANA" },
                    { 24, "SAN CRISTOBAL" },
                    { 23, "SAMANA" },
                    { 22, "HERMANAS MIRABAL (SALCEDO)" },
                    { 21, "PUERTO PLATA" },
                    { 20, "PERAVIA" },
                    { 19, "PEDERNALES" },
                    { 18, "MONTE PLATA" },
                    { 17, "MONTECRISTI" },
                    { 16, "MONSEÑOR NOUEL" },
                    { 2, "LA ALTAGRACIA" },
                    { 3, "AZUA" },
                    { 4, "BAHORUCO" },
                    { 5, "BARAHONA" },
                    { 6, "DAJABON" },
                    { 7, "DUARTE" },
                    { 8, "EL SEIBO" },
                    { 10, "ESPAILLAT" },
                    { 11, "HATO MAYOR DEL REY" },
                    { 12, "INDEPENDENCIA" },
                    { 13, "LA ROMANA" },
                    { 14, "LA VEGA" },
                    { 15, "MARIA TRINIDAD SANCHEZ" },
                    { 9, "ELIAS PIÑA" }
                });

            migrationBuilder.InsertData(
                table: "TiposSolictudes",
                columns: new[] { "Id", "Nombre" },
                values: new object[,]
                {
                    { 1, "Salud" },
                    { 2, "Construccion" }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 1, "DISTRITO NACIONAL", 1 },
                    { 322, "LAS GALERAS (DM)", 23 },
                    { 262, "ARROYO BARRIL (DM)", 23 },
                    { 218, "EL LIMON (DM)", 23 },
                    { 134, "LAS TERRENAS", 23 },
                    { 66, "SANCHEZ", 23 },
                    { 65, "SAMANA", 23 },
                    { 270, "MONTE LLANO (JAMAO AFUERA) (DM)", 22 },
                    { 193, "BLANCO (DM)", 22 },
                    { 64, "TENARES", 22 },
                    { 2, "SAN CRISTOBAL", 24 },
                    { 55, "SALCEDO", 22 },
                    { 388, "GUALEPE", 21 },
                    { 375, "ESTRECHO DE LUPERON OMAR BROSS (DM)", 21 },
                    { 372, "MAIMON (DM)", 21 },
                    { 346, "RIO GRANDE (DM)", 21 },
                    { 332, "YASICA ARRIBA (DM)", 21 },
                    { 305, "NAVAS (DM)", 21 },
                    { 263, "LA JAIBA (DM)", 21 },
                    { 245, "SABANETA DE YASICA (DM)", 21 },
                    { 244, "CABARETE (DM)", 21 },
                    { 51, "VILLA TAPIA", 22 },
                    { 243, "BELLOSO (DM)", 21 },
                    { 68, "VILLA ALTAGRACIA", 24 },
                    { 83, "SABANA GRANDE DE PALENQUE", 24 },
                    { 292, "SABANETA (DM)", 25 },
                    { 287, "ARROYO CANO (DM)", 25 },
                    { 190, "PEDRO CORTO (DM)", 25 },
                    { 186, "MATAYAYA (DM)", 25 },
                    { 129, "JUAN DE HERRERA", 25 },
                    { 109, "BOHECHIO", 25 },
                    { 108, "VALLEJUELO", 25 },
                    { 14, "EL CERCADO", 25 },
                    { 12, "SAN JUAN DE LA MAGUANA", 25 },
                    { 82, "YAGUATE", 24 },
                    { 11, "LAS MATAS DE FARFAN", 25 },
                    { 306, "HATO DAMAS (DM)", 24 },
                    { 256, "LA CUCHILLA (DM)", 24 },
                    { 255, "MEDINA (DM)", 24 },
                    { 252, "SAN JOSE-PINO HERRADO-EL PUERTO(DM)", 24 },
                    { 234, "EL CARRIL (DM)", 24 },
                    { 140, "SAN GREGORIO DE NIGUA", 24 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 139, "LOS CACAOS", 24 },
                    { 104, "CAMBITA GARABITOS", 24 },
                    { 93, "BAJOS DE HAINA", 24 },
                    { 315, "CAMBITA EL PUEBLECITO (DM)", 24 },
                    { 297, "YAQUE (BUENA VISTA) (DM)", 25 },
                    { 206, "NAVAS (DM)", 21 },
                    { 177, "ESTERO HONDO (DM)", 21 },
                    { 91, "OVIEDO", 19 },
                    { 69, "PEDERNALES", 19 },
                    { 299, "BOYA-EL CENTRO (DM)", 18 },
                    { 254, "CHIRINO (DM)", 18 },
                    { 209, "MAJAGUAL (DM)", 18 },
                    { 179, "LOS BOTADOS (DM)", 18 },
                    { 174, "GONZALO (DM)", 18 },
                    { 153, "PERALVILLO", 18 },
                    { 147, "DON JUAN (DM)", 18 },
                    { 184, "JUANCHO (DM)", 19 },
                    { 90, "SABANA GRANDE DE BOYA", 18 },
                    { 5, "YAMASA", 18 },
                    { 4, "BAYAGUANA", 18 },
                    { 253, "PALO VERDE (EL AHOGADO) (DM)", 17 },
                    { 241, "CANA CHAPETON (DM)", 17 },
                    { 173, "HATILLO PALMA (DM)", 17 },
                    { 171, "VILLA ELISA (DM)", 17 },
                    { 117, "LAS MATAS DE SANTA CRUZ", 17 },
                    { 101, "CASTAÃ‘UELAS", 17 },
                    { 72, "VILLA VASQUEZ", 17 },
                    { 8, "MONTE PLATA", 18 },
                    { 188, "LA ISABELA (DM)", 21 },
                    { 325, "JOSE FRANCISCO PEÃ‘A GOMEZ (DM)", 19 },
                    { 84, "NIZAO", 20 },
                    { 175, "VILLA MONTELLANO", 21 },
                    { 121, "VILLA ISABELA", 21 },
                    { 120, "GUANANICO", 21 },
                    { 102, "LOS HIDALGOS", 21 },
                    { 97, "SOSUA", 21 },
                    { 40, "LUPERON", 21 },
                    { 39, "ALTAMIRA", 21 },
                    { 38, "IMBERT", 21 },
                    { 37, "PUERTO PLATA", 21 },
                    { 3, "BANI", 20 },
                    { 381, "LAS BARIAS (DM)", 20 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 302, "LA CATALINA (DM)", 20 },
                    { 235, "EL CARRETON (DM)", 20 },
                    { 221, "VILLA SOMBRERO (DM)", 20 },
                    { 185, "PAYA (DM)", 20 },
                    { 176, "SANTANA (DM)", 20 },
                    { 170, "PIZARRETE (DM)", 20 },
                    { 158, "SABANA BUEY (DM)", 20 },
                    { 157, "VILLA FUNDACION (DM)", 20 },
                    { 156, "MATANZAS (DM)", 20 },
                    { 358, "EL LIMONAL (DM)", 20 },
                    { 314, "SABANA ALTA (DM)", 25 },
                    { 317, "DERRUMBADERO (EL NUEVO BRAZIL) (DM)", 25 },
                    { 319, "EL ROSARIO (DM)", 25 },
                    { 248, "CRUCE DE GUAYACANES (DM)", 30 },
                    { 232, "LA CAYA (DM)", 30 },
                    { 217, "JAIBÃ“N (DM)", 30 },
                    { 204, "JICOME (DM)", 30 },
                    { 197, "MAIZAL (DM)", 30 },
                    { 196, "GUATAPANAL (DM)", 30 },
                    { 195, "JAIBON (DM)", 30 },
                    { 194, "AMINA (DM)", 30 },
                    { 92, "LAGUNA SALADA", 30 },
                    { 328, "BOCA DE MAO (DM)", 30 },
                    { 34, "MAO", 30 },
                    { 116, "VILLA LOS ALMACIGOS", 29 },
                    { 46, "SAN IGNACIO DE SABANETA", 29 },
                    { 42, "MONCION", 29 },
                    { 374, "CANCA LA PIEDRA (DM)", 28 },
                    { 352, "CANABACOA ABAJO (DM)", 28 },
                    { 351, "GUAYABAL (DM)", 28 },
                    { 350, "PUÃ‘AL", 28 },
                    { 327, "LAS PALOMAS (DM)", 28 },
                    { 308, "EL CAIMITO (DM)", 28 },
                    { 33, "ESPERANZA", 30 },
                    { 269, "LAS PLACETAS (DM)", 28 },
                    { 343, "PARADERO (DM)", 30 },
                    { 150, "SABANA LARGA", 31 },
                    { 313, "PANTOJA (DM)", 32 },
                    { 312, "PALMAREJO (DM)", 32 },
                    { 311, "LA CUABA (DM)", 32 },
                    { 310, "LA GUAYIGA (DM)", 32 },
                    { 307, "HATO VIEJO (DM)", 32 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 291, "SAN LUIS (DM)", 32 },
                    { 286, "LA CALETA (DM)", 32 },
                    { 230, "LA VICTORIA (DM)", 32 },
                    { 229, "LOS ALCARRIZOS", 32 },
                    { 13, "SAN JOSE DE OCOA", 31 },
                    { 228, "PEDRO BRAND", 32 },
                    { 226, "BOCA CHICA", 32 },
                    { 225, "SANTO DOMINGO NORTE", 32 },
                    { 224, "SANTO DOMINGO OESTE", 32 },
                    { 223, "SANTO DOMINGO ESTE", 32 },
                    { 382, "EL NARANJAL (DM)", 31 },
                    { 278, "EL PINAR (DM)", 31 },
                    { 277, "NIZAO-LAS AUYAMAS (DM)", 31 },
                    { 180, "LA CIENAGA (DM)", 31 },
                    { 152, "RANCHO ARRIBA", 31 },
                    { 227, "SAN ANTONIO DE GUERRA", 32 },
                    { 268, "LAS CUESTA (DM)", 28 },
                    { 258, "HATO DEL YAQUE (DM)", 28 },
                    { 246, "EL LIMON (DM)", 28 },
                    { 52, "CEVICOS", 27 },
                    { 49, "COTUI", 27 },
                    { 364, "GUAYACANES", 26 },
                    { 247, "GAUTIER (DM)", 26 },
                    { 200, "EL PUERTO (DM)", 26 },
                    { 146, "QUISQUEYA", 26 },
                    { 138, "CONSUELO", 26 },
                    { 30, "RAMON SANTANA", 26 },
                    { 24, "LOS LLANOS", 26 },
                    { 87, "FANTINO", 27 },
                    { 23, "SAN PEDRO DE MACORIS", 26 },
                    { 366, "JINOVA (DM)", 25 },
                    { 357, "LAS CHARCAS DE MARIA NOVAS (DM)", 25 },
                    { 353, "LAS MAGUANAS-HATO NUEVO (DM)", 25 },
                    { 348, "JORGILLO (DM)", 25 },
                    { 336, "LA JAGUA (DM)", 25 },
                    { 331, "GUANITO (DM)", 25 },
                    { 330, "CARRERA DE YEGUAS (DM)", 25 },
                    { 329, "BATISTA (DM)", 25 },
                    { 326, "HATO DEL PADRE (DM)", 25 },
                    { 390, "LA ZANJA", 25 },
                    { 124, "LA CUEVA (DM)", 27 },
                    { 155, "VILLA LA MATA", 27 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 220, "LA BIJA (DM)", 27 },
                    { 239, "SAN FRANCISCO DE JACAGUA (DM)", 28 },
                    { 219, "PALMAR ARRIBA (DM)", 28 },
                    { 192, "JUNCALITO (DM)", 28 },
                    { 191, "EL RUBIO (DM)", 28 },
                    { 172, "LA CANELA (DM)", 28 },
                    { 161, "BAITOA (DM)", 28 },
                    { 148, "SABANA IGLESIA (DM)", 28 },
                    { 142, "PEDRO GARCIA (DM)", 28 },
                    { 96, "VILLA BISONO -NAVARRETE-", 28 },
                    { 95, "LICEY AL MEDIO", 28 },
                    { 94, "VILLA GONZALEZ", 28 },
                    { 36, "SAN JOSE DE LAS MATAS", 28 },
                    { 35, "JANICO", 28 },
                    { 32, "TAMBORIL", 28 },
                    { 31, "SANTIAGO DE LOS CABALLEROS", 28 },
                    { 384, "HERNANDO ALONZO (DM)", 27 },
                    { 373, "COMEDERO ARRIBA (DM)", 27 },
                    { 369, "CABALLERO (DM)", 27 },
                    { 320, "QUITA SUEÃ‘O (DM)", 27 },
                    { 309, "PLATANAL (DM)", 27 },
                    { 233, "ANGELINA (DM)", 27 },
                    { 45, "GUAYUBIN", 17 },
                    { 41, "MONTECRISTI", 17 },
                    { 86, "PEPILLO SALCEDO", 17 },
                    { 362, "JAYACO (DM)", 16 },
                    { 272, "QUITA CORAZA (DM)", 5 },
                    { 222, "LOS PATOS (DM)", 5 },
                    { 216, "PESCADERIA (DM)", 5 },
                    { 198, "EL CACHON (DM)", 5 },
                    { 167, "JAQUIMEYES", 5 },
                    { 164, "CANOA (DM)", 5 },
                    { 160, "LA CIENAGA", 5 },
                    { 137, "LAS SALINAS", 5 },
                    { 131, "FUNDACION", 5 },
                    { 279, "FONDO NEGRO (DM)", 5 },
                    { 130, "EL PEÃ‘ON", 5 },
                    { 80, "PARAISO", 5 },
                    { 79, "VICENTE NOBLE", 5 },
                    { 21, "ENRIQUILLO", 5 },
                    { 19, "CABRAL", 5 },
                    { 18, "BARAHONA", 5 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 387, "EL SALADO", 4 },
                    { 386, "SANTA BARBARA EL 6", 4 },
                    { 371, "MENA (DM)", 4 },
                    { 333, "CABEZA DE TORO (DM)", 4 },
                    { 111, "POLO", 5 },
                    { 298, "MONSERRAT (DM)", 4 },
                    { 284, "ARROYO DULCE (DM)", 5 },
                    { 301, "BAHORUCO (DM)", 5 },
                    { 383, "LA SALVIA-LOS QUEMADOS (DM)", 16 },
                    { 182, "AGUA SANTA DEL YUNA (DM)", 7 },
                    { 143, "LAS GUARANAS", 7 },
                    { 119, "ARENOSO", 7 },
                    { 63, "EUGENIO MARIA DE HOSTOS", 7 },
                    { 59, "CASTILLO", 7 },
                    { 58, "VILLA RIVA", 7 },
                    { 57, "PIMENTEL", 7 },
                    { 56, "SAN FRANCISCO DE MACORIS", 7 },
                    { 294, "PALO ALTO (DM)", 5 },
                    { 365, "SANTIAGO DE LA CRUZ (DM)", 6 },
                    { 318, "CAPOTILLO (DM)", 6 },
                    { 242, "MANUEL BUENO (DM)", 6 },
                    { 151, "EL PINO", 6 },
                    { 115, "PARTIDO", 6 },
                    { 73, "LOMA DE CABRERA", 6 },
                    { 44, "DAJABON", 6 },
                    { 43, "RESTAURACION", 6 },
                    { 389, "VILLA CENTRAL", 5 },
                    { 356, "LA GUAZARA (DM)", 5 },
                    { 321, "CAÃ‘ONGO (DM)", 6 },
                    { 289, "SANTANA (DM)", 4 },
                    { 288, "LAS CLAVELLINAS (DM)", 4 },
                    { 214, "EL PALMAR (DM)", 4 },
                    { 257, "LOS TOROS (DM)", 3 },
                    { 231, "VILLARPANDO (DM)", 3 },
                    { 207, "PALMAR DE OCOA (DM)", 3 },
                    { 154, "PUEBLO VIEJO", 3 },
                    { 135, "LAS CHARCAS", 3 },
                    { 132, "ESTEBANIA", 3 },
                    { 126, "TABARA ARRIBA", 3 },
                    { 125, "LAS YAYAS DE VIAJAMA", 3 },
                    { 107, "SABANA YEGUA", 3 },
                    { 259, "PROYECTO #4 (DM)", 3 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 106, "PERALTA", 3 },
                    { 17, "PADRE LAS CASAS", 3 },
                    { 10, "AZUA", 3 },
                    { 385, "TURISTICO VERON PUNTA CANA (DM)", 2 },
                    { 249, "BAYAHIBE (DM)", 2 },
                    { 211, "BOCA DE YUMA (DM)", 2 },
                    { 145, "LA OTRA BANDA (DM)", 2 },
                    { 141, "LA LAGUNA DE NISIBON (DM)", 2 },
                    { 85, "SAN RAFAEL DEL YUMA", 2 },
                    { 28, "HIGUEY", 2 },
                    { 105, "GUAYABAL", 3 },
                    { 260, "PROYECTO D-1 GANADERO (DM)", 3 },
                    { 261, "EL ROSARIO (DM)", 3 },
                    { 264, "LAS BARIAS-LA ESTANCIA (DM)", 3 },
                    { 127, "UVILLA (DM)", 4 },
                    { 113, "GALVAN", 4 },
                    { 112, "LOS RIOS", 4 },
                    { 78, "VILLA JARAGUA", 4 },
                    { 76, "TAMAYO", 4 },
                    { 22, "NEYBA", 4 },
                    { 380, "PROYECTO 2-C (DM)", 3 },
                    { 377, "HATO NUEVO CORTES (DM)", 3 },
                    { 370, "LOS FRIOS (DM)", 3 },
                    { 355, "LAS LOMAS (DM)", 3 },
                    { 341, "LAS CLAVELLINAS (DM)", 3 },
                    { 340, "DOÃ‘A EMMA BALAGUER VDA. VALLEJO", 3 },
                    { 339, "MONTE BONITO (DM)", 3 },
                    { 335, "BARRERAS (DM)", 3 },
                    { 334, "PUERTO VIEJO-LOS NEGROS (DM)", 3 },
                    { 304, "LA SIEMBRA (DM)", 3 },
                    { 303, "LAS LAGUNAS (DM)", 3 },
                    { 283, "TABARA ABAJO (DM)", 3 },
                    { 282, "AMIAMA GOMEZ (DM)", 3 },
                    { 276, "BARRO ARRIBA (DM)", 3 },
                    { 267, "LOS JOVILLOS (DM)", 3 },
                    { 189, "LA PEÃ‘A (DM)", 7 },
                    { 205, "CENOVI (DM)", 7 },
                    { 183, "CRISTO REY DE GUARAGUAO (DM)", 7 },
                    { 266, "LAS COLES (DM)", 7 },
                    { 163, "TIREO ARRIBA (DM)", 14 },
                    { 122, "JIMA ABAJO", 14 },
                    { 53, "CONSTANZA", 14 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 50, "JARABACOA", 14 },
                    { 47, "LA VEGA", 14 },
                    { 360, "LA CALETA (DM)", 13 },
                    { 296, "CUMAYASA (DM)", 13 },
                    { 295, "VILLA HERMOSA", 13 },
                    { 103, "GUAYMATE", 13 },
                    { 181, "RIO VERDE ARRIBA (DM)", 14 },
                    { 26, "LA ROMANA", 13 },
                    { 323, "VENGAN A VER (DM)", 12 },
                    { 316, "BOCA DE CACHON (DM)", 12 },
                    { 293, "LA COLONIA (DM)", 12 },
                    { 238, "EL LIMON (DM)", 12 },
                    { 178, "GUAYABAL (DM)", 12 },
                    { 128, "CRISTOBAL", 12 },
                    { 114, "MELLA", 12 },
                    { 265, "LAS TARANAS (DM)", 7 },
                    { 77, "JIMANI", 12 },
                    { 379, "BATEY 8 (DM)", 12 },
                    { 70, "LA DESCUBIERTA", 12 },
                    { 187, "RINCON (DM)", 14 },
                    { 251, "EL RANCHITO (DM)", 14 },
                    { 354, "ARROYO TORO-MASIPEDRO (DM)", 16 },
                    { 281, "JUMA BEJUCAL (DM)", 16 },
                    { 210, "JUAN ADRIAN (DM)", 16 },
                    { 201, "SABANA DEL PUERTO (DM)", 16 },
                    { 199, "VILLA SONADOR (DM)", 16 },
                    { 123, "PIEDRA BLANCA", 16 },
                    { 118, "MAIMON", 16 },
                    { 48, "BONAO", 16 },
                    { 347, "ARROYO AL MEDIO (DM)", 15 },
                    { 250, "LA SABINA (DM)", 14 },
                    { 271, "LAS GORDAS (DM)", 15 },
                    { 212, "LA ENTRADA (DM)", 15 },
                    { 203, "ARROYO SALADO (DM)", 15 },
                    { 165, "SAN JOSE DE MATANZAS (DM)", 15 },
                    { 136, "EL FACTOR", 15 },
                    { 81, "RIO SAN JUAN", 15 },
                    { 71, "NAGUA", 15 },
                    { 60, "CABRERA", 15 },
                    { 349, "MANABAO (DM)", 14 },
                    { 300, "BUENA VISTA (DM)", 14 },
                    { 213, "EL POZO (DM)", 15 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 20, "DUVERGE", 12 },
                    { 99, "POSTRER RIO", 12 },
                    { 202, "MATA PALACIO (DM)", 11 },
                    { 280, "SABANA LARGA (DM)", 9 },
                    { 215, "GUAYABO DULCE (DM)", 11 },
                    { 144, "JUAN SANTIAGO", 9 },
                    { 110, "EL LLANO", 9 },
                    { 75, "HONDO VALLE", 9 },
                    { 74, "PEDRO SANTANA", 9 },
                    { 16, "COMENDADOR", 9 },
                    { 15, "BANICA", 9 },
                    { 378, "SANTA LUCIA-LA HIGUERA (DM)", 8 },
                    { 337, "GUANITO (DM)", 9 },
                    { 367, "SAN FRANCISCO-VICENTILLO (DM)", 8 },
                    { 237, "EL JOVERO (EL CEDRO) (DM)", 8 },
                    { 166, "PEDRO SANCHEZ (DM)", 8 },
                    { 29, "MICHES", 8 },
                    { 25, "EL SEIBO", 8 },
                    { 376, "DON ANTONIO GUZMAN FERNANDEZ (DM)", 7 },
                    { 363, "JAYA (DM)", 7 },
                    { 345, "BARRAQUITO (DM)", 7 },
                    { 344, "EL AGUACATE (DM)", 7 },
                    { 290, "SABANA GRANDE (DM)", 7 },
                    { 324, "LA GINA (DM)", 8 },
                    { 338, "SABANA CRUZ (DM)", 9 },
                    { 159, "RIO LIMPIO (DM)", 9 },
                    { 361, "SABANA HIGUERO (DM)", 9 },
                    { 169, "ELUPINA CORDERO DE LAS CAÃ‘ITAS (DM)", 11 },
                    { 168, "YERBA BUENA (DM)", 11 },
                    { 100, "EL VALLE", 11 },
                    { 67, "SABANA DE LA MAR", 11 },
                    { 27, "HATO MAYOR", 11 },
                    { 342, "VILLA MAGANTE (DM)", 10 },
                    { 359, "GUAYABO (DM)", 9 },
                    { 275, "ORTEGA (DM)", 10 },
                    { 274, "MONTE DE LA JAGUA (DM)", 10 },
                    { 273, "HIGUERITO (DM)", 10 },
                    { 285, "CANCA LA REYNA (DM)", 10 },
                    { 236, "LAS LAGUNAS ABAJO (DM)", 10 },
                    { 368, "RANCHO DE LA GUARDIA (DM)", 9 },
                    { 240, "VERAGUA (DM)", 10 },
                    { 61, "GASPAR HERNANDEZ", 10 }
                });

            migrationBuilder.InsertData(
                table: "Municipios",
                columns: new[] { "Id", "Nombre", "ProvinciaId" },
                values: new object[,]
                {
                    { 88, "CAYETANO GERMOSEN", 10 },
                    { 54, "MOCA", 10 },
                    { 133, "JAMAO AL NORTE", 10 },
                    { 149, "SAN VICTOR (DM)", 10 },
                    { 162, "JOBA ARRIBA (DM)", 10 },
                    { 208, "JUAN LOPEZ ABAJO (EL MAMEY) (DM)", 10 },
                    { 89, "JOSE CONTRERAS (DM)", 10 }
                });

            migrationBuilder.InsertData(
                table: "RequisitosTiposSolicitud",
                columns: new[] { "Id", "Descripcion", "FormName", "PossibleValues", "TipoSolicitudId" },
                values: new object[,]
                {
                    { 7, "Copia de cedula", "rdcopiacedula", "", 2 },
                    { 1, "Comunicacion solicitud del interesado dirigida al CEN", "rdcomunicacion", "", 1 },
                    { 2, "Copia de cedula", "rdcopiacedula", "", 1 },
                    { 3, "Expediente clinico que demuestre diagnostico actualizado", "rdexpendiente", "", 1 },
                    { 4, "Carta aval de la seccional a la que pertenece", "rdcartaaval", "", 1 },
                    { 5, "ARS a que pertenece", "rdars", "ARS CMD,ARS APS,ARS SIMAG,ARS GRUPO MEDICO ASOCIADO,ARS YUNEN,ARS UNIVERSAL,ARS MONUMENTAL,ARS FUTURO,ARS PRIMERA,ARS ASEMAP,ARS SEMMA,ARS RENACER,ARS PALIC-SALUD,ARS PLAN SALUD,ARS SENASA,ARS RESERVAS,ARS METASALUD,ARS SENASA - REGIMEN SUBSIDIADO", 1 },
                    { 6, "Comunicacion solicitud del interesado dirigida al CEN", "rdcomunicacion", "", 2 },
                    { 8, "Carta aval de la seccional a la que pertenece", "rdcartaaval", "", 2 }
                });

            migrationBuilder.InsertData(
                table: "Seccionales",
                columns: new[] { "Id", "MunicipioId", "Nombre", "PresidenteId" },
                values: new object[,]
                {
                    { 123, 1, "Zona Norte", null },
                    { 96, 121, "Villa Isabela", null },
                    { 99, 51, "Villa Tapia", null },
                    { 97, 55, "Salcedo", null },
                    { 98, 64, "Tenares", null },
                    { 100, 65, "Samaná", null },
                    { 104, 65, "Sevicos", null },
                    { 102, 66, "Sánchez", null },
                    { 101, 134, "Las Terrenas", null },
                    { 33, 2, "Municipio San Cristóbal", null },
                    { 39, 68, "Municipio Villa Altagracia", null },
                    { 40, 82, "Municipio Yaguaté", null },
                    { 38, 83, "Municipio Palenque ", null },
                    { 35, 93, "Municipio Haina", null },
                    { 36, 139, "Municipio Los Cacaos", null },
                    { 37, 140, "Municipio Nigua", null },
                    { 91, 120, "Gaunanico", null },
                    { 34, 315, "Municipio Cambita", null },
                    { 93, 102, "Los Hidalgos", null },
                    { 94, 40, "Luperón", null },
                    { 87, 86, "Manzanillo)Pepillo Salcedo", null },
                    { 84, 101, "Castañuela", null },
                    { 86, 117, "Las Matas de Santa Cruz", null },
                    { 143, 4, "Bayaguana", null },
                    { 146, 5, "Yamasa", null },
                    { 142, 8, "Monte Plata", null },
                    { 145, 8, "Sabana Grande de Boyá", null },
                    { 144, 153, "Peralvillo", null },
                    { 29, 69, null, null },
                    { 30, 91, "Municipio Oviedo", null },
                    { 31, 3, "Bani", null },
                    { 32, 84, "Municipio Nizao", null },
                    { 89, 37, "Puerto Plata", null },
                    { 92, 38, "Imbert", null },
                    { 90, 39, "Altamira", null },
                    { 95, 97, "Sosua", null },
                    { 48, 11, "Municipio Las Matas de Farfán", null },
                    { 43, 12, null, null },
                    { 45, 14, "Municipio El Cercado", null },
                    { 111, 142, "Pedro García", null },
                    { 115, 350, "Puñal", null },
                    { 117, 42, "Moción", null }
                });

            migrationBuilder.InsertData(
                table: "Seccionales",
                columns: new[] { "Id", "MunicipioId", "Nombre", "PresidenteId" },
                values: new object[,]
                {
                    { 119, 116, "Los Almácigos", null },
                    { 122, 33, "Esperanza", null },
                    { 120, 34, "de Mao", null },
                    { 121, 92, "Laguna Salada", null },
                    { 42, 150, "Municipio Sabana Larga", null },
                    { 41, 152, "Municipio Rancho Arriba", null },
                    { 152, 223, "Santo Domingo Este ", null },
                    { 154, 224, "Santo Domingo Oeste ", null },
                    { 153, 225, "Santo Domingo Norte ", null },
                    { 147, 226, "Boca Chica ", null },
                    { 148, 227, "San Antonio de Guerrera", null },
                    { 151, 228, "Pedro Brand ", null },
                    { 110, 96, "Navarrete", null },
                    { 109, 95, "Licey al medio", null },
                    { 114, 94, "Villa González", null },
                    { 112, 36, "San José de la Matas", null },
                    { 47, 108, "Municipio Vallejuelo", null },
                    { 44, 109, "Municipio Bohechio", null },
                    { 46, 129, "Municipio Juan de Herrera", null },
                    { 118, 292, "Sabaneta", null },
                    { 127, 23, "San Pedro", null },
                    { 129, 24, "Los Llanos", null },
                    { 131, 30, "Ramón Santana", null },
                    { 88, 72, "Villa Vázquez", null },
                    { 128, 138, "Consuelo", null },
                    { 103, 49, "Cotui", null },
                    { 105, 87, "Fantino", null },
                    { 106, 155, "Villa La Mata", null },
                    { 107, 31, "Santiago", null },
                    { 116, 31, "Sur Oeste Santiago", null },
                    { 113, 32, "Tamboril", null },
                    { 108, 35, "Janico", null },
                    { 130, 146, "Quisqueya", null },
                    { 85, 45, "Guayubin", null },
                    { 83, 41, "Monte Cristi", null },
                    { 82, 123, "Piedra Blanca", null },
                    { 17, 79, "Municipio Vicente Noble", null },
                    { 14, 80, "Municipio Paraíso", null },
                    { 16, 111, "Municipio Polo", null },
                    { 15, 130, "Municipio El Peñón", null },
                    { 18, 131, "Municipio  Fundación", null },
                    { 13, 137, "Municipio Las Salinas", null }
                });

            migrationBuilder.InsertData(
                table: "Seccionales",
                columns: new[] { "Id", "MunicipioId", "Nombre", "PresidenteId" },
                values: new object[,]
                {
                    { 12, 160, "Municipio La Cienaga", null },
                    { 11, 167, "Municipio Jaquimeye", null },
                    { 66, 43, "Restauración", null },
                    { 62, 44, "Dajabón", null },
                    { 64, 73, "Loma de Cabrera", null },
                    { 65, 115, "Partido", null },
                    { 63, 151, "El Pino", null },
                    { 55, 56, "Municipio  San Francisco", null },
                    { 60, 57, "Municipio Pimentel", null },
                    { 10, 21, "Municipio Enriquillo", null },
                    { 9, 19, "Municipio Cabral", null },
                    { 8, 18, "BARAHONA", null },
                    { 20, 113, "Municipio Galván", null },
                    { 124, 1, "Zona Sur", null },
                    { 125, 1, "Zona oeste", null },
                    { 126, 1, "Zona Noroeste", null },
                    { 135, 28, "Higuey", null },
                    { 136, 85, "San Rafael del Yuma", null },
                    { 1, 10, "Municipio Azua", null },
                    { 4, 17, "Municipio Padre Las Casas", null },
                    { 61, 58, "Villa Rivas", null },
                    { 2, 105, "Municipio Guayabal", null },
                    { 6, 107, "Municipio Sabana Yegua", null },
                    { 3, 125, "Municipio Las Yayas", null },
                    { 7, 126, "Municipio Tabara Arriba", null },
                    { 19, 22, "Municipio Neyba", null },
                    { 21, 76, "Municipio Tamayo", null },
                    { 23, 78, "Municipio Villa Jaragua", null },
                    { 22, 112, "Municipio Los Ríos", null },
                    { 5, 106, "Municipio Peralta", null },
                    { 149, 229, "Los Alcarrizos", null },
                    { 56, 59, "Municipio Castillo", null },
                    { 57, 119, "Municipio Arenoso", null },
                    { 53, 114, "Municipio Mella", null },
                    { 51, 128, "Municipio Cristóbal", null },
                    { 132, 26, "De La Romana", null },
                    { 133, 103, "Guaymate", null },
                    { 134, 295, "Villa Hermosa", null },
                    { 72, 47, "LA VEGA", null },
                    { 74, 50, "Jarabacoa", null },
                    { 73, 53, "Constanza", null },
                    { 75, 122, "Jima Abajo", null }
                });

            migrationBuilder.InsertData(
                table: "Seccionales",
                columns: new[] { "Id", "MunicipioId", "Nombre", "PresidenteId" },
                values: new object[,]
                {
                    { 77, 60, "Cabrera", null },
                    { 76, 71, "Nagua", null },
                    { 79, 81, "Rio San Juan", null },
                    { 78, 136, "El Factor", null },
                    { 80, 48, "Bonao", null },
                    { 81, 118, "Maimón", null },
                    { 54, 99, "Municipio Poster Rio", null },
                    { 49, 77, "Jimani", null },
                    { 52, 70, "Municipio La Descubierta", null },
                    { 50, 20, "Municipio Duverge", null },
                    { 59, 143, "Municipio Las Guaranas", null },
                    { 140, 25, "El Seribo", null },
                    { 141, 29, "Miches", null },
                    { 25, 15, "Municipio Banica", null },
                    { 24, 16, "Municipio Comendador", null },
                    { 27, 74, "Municipio Pedro Santana", null },
                    { 26, 75, "Municipio Hondo Valle", null },
                    { 58, 63, "Municipio Hostos", null },
                    { 28, 110, "Municipio El Llano", null },
                    { 69, 61, "Gaspar Hernández", null },
                    { 68, 88, "Cayetano Germosen", null },
                    { 71, 89, "José Contreras (Villa Trina)", null },
                    { 70, 133, "Jamao Al Norte", null },
                    { 137, 27, "Hato Mayor", null },
                    { 139, 27, "Sabana de la Mar", null },
                    { 138, 100, "El Valle", null },
                    { 67, 54, "Moca", null },
                    { 150, 291, "Mendoza San  Luis ", null }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Maestros_SeccionalId",
                table: "Maestros",
                column: "SeccionalId");

            migrationBuilder.CreateIndex(
                name: "IX_Municipios_ProvinciaId",
                table: "Municipios",
                column: "ProvinciaId");

            migrationBuilder.CreateIndex(
                name: "IX_RequisitosTiposSolicitud_TipoSolicitudId",
                table: "RequisitosTiposSolicitud",
                column: "TipoSolicitudId");

            migrationBuilder.CreateIndex(
                name: "IX_Seccionales_MunicipioId",
                table: "Seccionales",
                column: "MunicipioId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Maestros");

            migrationBuilder.DropTable(
                name: "RequisitosTiposSolicitud");

            migrationBuilder.DropTable(
                name: "Seccionales");

            migrationBuilder.DropTable(
                name: "TiposSolictudes");

            migrationBuilder.DropTable(
                name: "Municipios");

            migrationBuilder.DropTable(
                name: "Provincias");
        }
    }
}