using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class SlotsOnUtilization : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "UtilizationId",
                table: "Slots",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Slots_UtilizationId",
                table: "Slots",
                column: "UtilizationId");

            migrationBuilder.AddForeignKey(
                name: "FK_Slots_Utilization_UtilizationId",
                table: "Slots",
                column: "UtilizationId",
                principalTable: "Utilization",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Slots_Utilization_UtilizationId",
                table: "Slots");

            migrationBuilder.DropIndex(
                name: "IX_Slots_UtilizationId",
                table: "Slots");

            migrationBuilder.DropColumn(
                name: "UtilizationId",
                table: "Slots");
        }
    }
}
