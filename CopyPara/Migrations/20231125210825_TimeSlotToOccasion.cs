using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class TimeSlotToOccasion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "TimeSlotId",
                table: "Occasions",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.CreateIndex(
                name: "IX_Occasions_TimeSlotId",
                table: "Occasions",
                column: "TimeSlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_Occasions_TimeSlots_TimeSlotId",
                table: "Occasions",
                column: "TimeSlotId",
                principalTable: "TimeSlots",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Occasions_TimeSlots_TimeSlotId",
                table: "Occasions");

            migrationBuilder.DropIndex(
                name: "IX_Occasions_TimeSlotId",
                table: "Occasions");

            migrationBuilder.DropColumn(
                name: "TimeSlotId",
                table: "Occasions");
        }
    }
}
