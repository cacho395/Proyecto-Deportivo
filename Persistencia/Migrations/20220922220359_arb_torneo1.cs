using Microsoft.EntityFrameworkCore.Migrations;

namespace Persistencia.Migrations
{
    public partial class arb_torneo1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Arbitros_TorneoId",
                table: "Arbitros",
                column: "TorneoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Arbitros_Torneos_TorneoId",
                table: "Arbitros",
                column: "TorneoId",
                principalTable: "Torneos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Arbitros_Torneos_TorneoId",
                table: "Arbitros");

            migrationBuilder.DropIndex(
                name: "IX_Arbitros_TorneoId",
                table: "Arbitros");
        }
    }
}
