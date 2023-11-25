using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class AddData2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Cancers",
                columns: new[] { "Id", "AvgTimeMins", "CancerType", "Fractions" },
                values: new object[,]
                {
                    { 1ul, 12, 4, "5,10,12" },
                    { 2ul, 12, 1, "5,10,12" },
                    { 3ul, 20, 2, "5,10,12" },
                    { 4ul, 10, 6, "1,5,10,13,25,30" },
                    { 5ul, 30, 0, "13,17,20,30" },
                    { 6ul, 12, 3, "5,10,15,25,30,33,35" },
                    { 7ul, 12, 7, "1,5,10,15,20,25,30,33" },
                    { 8ul, 15, 8, "3,5,8" },
                    { 9ul, 12, 5, "1,3,5,10,15,22,23,25,28,35" },
                    { 10ul, 10, 9, "5,10,12" }
                });

            migrationBuilder.InsertData(
                table: "MachineTypes",
                columns: new[] { "Id", "Features", "Type" },
                values: new object[,]
                {
                    { 1ul, "[]", 2 },
                    { 2ul, "[3,2]", 1 },
                    { 3ul, "[0,1,3,2]", 0 }
                });

            migrationBuilder.InsertData(
                table: "Machines",
                columns: new[] { "Id", "MachineTypeId", "Name", "UtilizationId" },
                values: new object[,]
                {
                    { 1ul, 3ul, "TrueBeam 1", 0ul },
                    { 2ul, 3ul, "TrueBeam 2", 0ul },
                    { 3ul, 2ul, "VitalBeam 1", 0ul },
                    { 4ul, 2ul, "VitalBeam 2", 0ul },
                    { 5ul, 1ul, "Unique - Clinac", 0ul }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 1ul);

            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 2ul);

            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 3ul);

            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 4ul);

            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 5ul);

            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 6ul);

            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 7ul);

            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 8ul);

            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 9ul);

            migrationBuilder.DeleteData(
                table: "Cancers",
                keyColumn: "Id",
                keyValue: 10ul);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 1ul);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 2ul);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 3ul);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 4ul);

            migrationBuilder.DeleteData(
                table: "Machines",
                keyColumn: "Id",
                keyValue: 5ul);

            migrationBuilder.DeleteData(
                table: "MachineTypes",
                keyColumn: "Id",
                keyValue: 1ul);

            migrationBuilder.DeleteData(
                table: "MachineTypes",
                keyColumn: "Id",
                keyValue: 2ul);

            migrationBuilder.DeleteData(
                table: "MachineTypes",
                keyColumn: "Id",
                keyValue: 3ul);
        }
    }
}
