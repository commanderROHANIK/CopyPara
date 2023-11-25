using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class TimeSlotsOnSlots : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "SlotId",
                table: "TimeSlots",
                type: "INTEGER",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TimeSlots_SlotId",
                table: "TimeSlots",
                column: "SlotId");

            migrationBuilder.AddForeignKey(
                name: "FK_TimeSlots_Slots_SlotId",
                table: "TimeSlots",
                column: "SlotId",
                principalTable: "Slots",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TimeSlots_Slots_SlotId",
                table: "TimeSlots");

            migrationBuilder.DropIndex(
                name: "IX_TimeSlots_SlotId",
                table: "TimeSlots");

            migrationBuilder.DropColumn(
                name: "SlotId",
                table: "TimeSlots");
        }
    }
}
