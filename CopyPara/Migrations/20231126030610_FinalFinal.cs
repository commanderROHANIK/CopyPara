using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class FinalFinal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
            name: "IX_Utilization_MachineId",
            table: "Utilization");

            migrationBuilder.CreateIndex(
            name: "IX_Utilization_MachineId",
            table: "Utilization",
            column: "MachineId",
            unique: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
