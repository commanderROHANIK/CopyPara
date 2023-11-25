using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class UpdateMachineTypes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "MachineTypeId",
                table: "Treatments",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_MachineTypeId",
                table: "Treatments",
                column: "MachineTypeId");

            migrationBuilder.AddForeignKey(
                name: "FK_Treatments_MachineTypes_MachineTypeId",
                table: "Treatments",
                column: "MachineTypeId",
                principalTable: "MachineTypes",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Treatments_MachineTypes_MachineTypeId",
                table: "Treatments");

            migrationBuilder.DropIndex(
                name: "IX_Treatments_MachineTypeId",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "MachineTypeId",
                table: "Treatments");
        }
    }
}
