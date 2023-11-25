using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class AddAvgTimeMinsToCancer : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgTimeMins",
                table: "Treatments");

            migrationBuilder.AddColumn<int>(
                name: "AvgTimeMins",
                table: "Cancers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AvgTimeMins",
                table: "Cancers");

            migrationBuilder.AddColumn<int>(
                name: "AvgTimeMins",
                table: "Treatments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);
        }
    }
}
