using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class nuevamod : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Entrenadores_TecnicoId",
                table: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_TecnicoId",
                table: "Equipos");

            migrationBuilder.DropColumn(
                name: "TecnicoId",
                table: "Equipos");

            migrationBuilder.AlterColumn<string>(
                name: "Apellidos",
                table: "Entrenadores",
                type: "nvarchar(20)",
                maxLength: 20,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(15)",
                oldMaxLength: 15);

            migrationBuilder.AddColumn<int>(
                name: "EquipoId",
                table: "Entrenadores",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Deportistas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nombres = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Apellidos = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    Genero = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Modalidad = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: false),
                    FechaNacimiento = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Rh = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EPS = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Celular = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Correo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    EquipoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Deportistas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TorneoEquipos",
                columns: table => new
                {
                    EquipoId = table.Column<int>(type: "int", nullable: false),
                    TorneoId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TorneoEquipos", x => new { x.TorneoId, x.EquipoId });
                    table.ForeignKey(
                        name: "FK_TorneoEquipos_Equipos_EquipoId",
                        column: x => x.EquipoId,
                        principalTable: "Equipos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_TorneoEquipos_Torneos_TorneoId",
                        column: x => x.TorneoId,
                        principalTable: "Torneos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_PatrocinadorId",
                table: "Equipos",
                column: "PatrocinadorId");

            migrationBuilder.CreateIndex(
                name: "IX_Entrenadores_EquipoId",
                table: "Entrenadores",
                column: "EquipoId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_TorneoEquipos_EquipoId",
                table: "TorneoEquipos",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Entrenadores_Equipos_EquipoId",
                table: "Entrenadores",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Patrocinadores_PatrocinadorId",
                table: "Equipos",
                column: "PatrocinadorId",
                principalTable: "Patrocinadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Entrenadores_Equipos_EquipoId",
                table: "Entrenadores");

            migrationBuilder.DropForeignKey(
                name: "FK_Equipos_Patrocinadores_PatrocinadorId",
                table: "Equipos");

            migrationBuilder.DropTable(
                name: "Deportistas");

            migrationBuilder.DropTable(
                name: "TorneoEquipos");

            migrationBuilder.DropIndex(
                name: "IX_Equipos_PatrocinadorId",
                table: "Equipos");

            migrationBuilder.DropIndex(
                name: "IX_Entrenadores_EquipoId",
                table: "Entrenadores");

            migrationBuilder.DropColumn(
                name: "EquipoId",
                table: "Entrenadores");

            migrationBuilder.AddColumn<int>(
                name: "TecnicoId",
                table: "Equipos",
                type: "int",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Apellidos",
                table: "Entrenadores",
                type: "nvarchar(15)",
                maxLength: 15,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(20)",
                oldMaxLength: 20);

            migrationBuilder.CreateIndex(
                name: "IX_Equipos_TecnicoId",
                table: "Equipos",
                column: "TecnicoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipos_Entrenadores_TecnicoId",
                table: "Equipos",
                column: "TecnicoId",
                principalTable: "Entrenadores",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
