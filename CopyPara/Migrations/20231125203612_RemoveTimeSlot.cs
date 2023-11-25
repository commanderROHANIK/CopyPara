using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class RemoveTimeSlot : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.DropForeignKey(
            //     name: "FK_Occasions_TimeSlot_TimeSlotId",
            //     table: "Occasions");

            // migrationBuilder.DropTable(
            //     name: "TimeSlot");

            // migrationBuilder.DropTable(
            //     name: "Slot");

            // migrationBuilder.DropIndex(
            //     name: "IX_Occasions_TimeSlotId",
            //     table: "Occasions");

            // migrationBuilder.DropColumn(
            //     name: "TimeSlotId",
            //     table: "Occasions");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // migrationBuilder.AddColumn<ulong>(
            //     name: "TimeSlotId",
            //     table: "Occasions",
            //     type: "INTEGER",
            //     nullable: false,
            //     defaultValue: 0ul);

            // migrationBuilder.CreateTable(
            //     name: "Slot",
            //     columns: table => new
            //     {
            //         Id = table.Column<ulong>(type: "INTEGER", nullable: false)
            //             .Annotation("Sqlite:Autoincrement", true),
            //         End = table.Column<int>(type: "INTEGER", nullable: false),
            //         Start = table.Column<int>(type: "INTEGER", nullable: false),
            //         Type = table.Column<int>(type: "INTEGER", nullable: false),
            //         UtilizationId = table.Column<ulong>(type: "INTEGER", nullable: true)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_Slot", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_Slot_Utilization_UtilizationId",
            //             column: x => x.UtilizationId,
            //             principalTable: "Utilization",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.CreateTable(
            //     name: "TimeSlot",
            //     columns: table => new
            //     {
            //         Id = table.Column<ulong>(type: "INTEGER", nullable: false)
            //             .Annotation("Sqlite:Autoincrement", true),
            //         EndTime = table.Column<int>(type: "INTEGER", nullable: false),
            //         Length = table.Column<int>(type: "INTEGER", nullable: false),
            //         SlotId = table.Column<ulong>(type: "INTEGER", nullable: true),
            //         StartTime = table.Column<int>(type: "INTEGER", nullable: false),
            //         ToDelete = table.Column<bool>(type: "INTEGER", nullable: false)
            //     },
            //     constraints: table =>
            //     {
            //         table.PrimaryKey("PK_TimeSlot", x => x.Id);
            //         table.ForeignKey(
            //             name: "FK_TimeSlot_Slot_SlotId",
            //             column: x => x.SlotId,
            //             principalTable: "Slot",
            //             principalColumn: "Id");
            //     });

            // migrationBuilder.CreateIndex(
            //     name: "IX_Occasions_TimeSlotId",
            //     table: "Occasions",
            //     column: "TimeSlotId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_Slot_UtilizationId",
            //     table: "Slot",
            //     column: "UtilizationId");

            // migrationBuilder.CreateIndex(
            //     name: "IX_TimeSlot_SlotId",
            //     table: "TimeSlot",
            //     column: "SlotId");

            // migrationBuilder.AddForeignKey(
            //     name: "FK_Occasions_TimeSlot_TimeSlotId",
            //     table: "Occasions",
            //     column: "TimeSlotId",
            //     principalTable: "TimeSlot",
            //     principalColumn: "Id",
            //     onDelete: ReferentialAction.Cascade);
        }
    }
}
