using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class ExtendedTreatment : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "BreatHolding",
                table: "Treatments",
                type: "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                name: "Fraction",
                table: "Treatments",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<float>(
                name: "Weight",
                table: "Treatments",
                type: "REAL",
                nullable: false,
                defaultValue: 0f);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreatHolding",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "Fraction",
                table: "Treatments");

            migrationBuilder.DropColumn(
                name: "Weight",
                table: "Treatments");
        }
    }
}
