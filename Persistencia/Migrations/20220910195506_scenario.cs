using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class scenario : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PatrocinadorId",
                table: "Torneos",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Escenarios_UnidadDeportivaId",
                table: "Escenarios",
                column: "UnidadDeportivaId");

            migrationBuilder.CreateIndex(
                name: "IX_Deportistas_EquipoId",
                table: "Deportistas",
                column: "EquipoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Deportistas_Equipos_EquipoId",
                table: "Deportistas",
                column: "EquipoId",
                principalTable: "Equipos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Escenarios_UnidadDeportivas_UnidadDeportivaId",
                table: "Escenarios",
                column: "UnidadDeportivaId",
                principalTable: "UnidadDeportivas",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Deportistas_Equipos_EquipoId",
                table: "Deportistas");

            migrationBuilder.DropForeignKey(
                name: "FK_Escenarios_UnidadDeportivas_UnidadDeportivaId",
                table: "Escenarios");

            migrationBuilder.DropIndex(
                name: "IX_Escenarios_UnidadDeportivaId",
                table: "Escenarios");

            migrationBuilder.DropIndex(
                name: "IX_Deportistas_EquipoId",
                table: "Deportistas");

            migrationBuilder.DropColumn(
                name: "PatrocinadorId",
                table: "Torneos");
        }
    }
}
