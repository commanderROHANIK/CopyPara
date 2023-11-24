using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CopyPara.Migrations
{
    /// <inheritdoc />
    public partial class AddEntities : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<ulong>(
                name: "DoctorId",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.AddColumn<ulong>(
                name: "DoctorId1",
                table: "AspNetUsers",
                type: "INTEGER",
                nullable: false,
                defaultValue: 0ul);

            migrationBuilder.CreateTable(
                name: "Cancers",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    CancerType = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cancers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Doctors",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    ApplicationUserId = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Doctors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MachineTypes",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Type = table.Column<int>(type: "INTEGER", nullable: false),
                    Features = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MachineTypes", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Treatments",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AvgTimeMins = table.Column<int>(type: "INTEGER", nullable: false),
                    PatientId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    DoctorId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    CancerId = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Treatments", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Treatments_Cancers_CancerId",
                        column: x => x.CancerId,
                        principalTable: "Cancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_Doctors_DoctorId",
                        column: x => x.DoctorId,
                        principalTable: "Doctors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Treatments_Patients_PatientId",
                        column: x => x.PatientId,
                        principalTable: "Patients",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "CancerMachineType",
                columns: table => new
                {
                    CancersId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    MachineTypesId = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CancerMachineType", x => new { x.CancersId, x.MachineTypesId });
                    table.ForeignKey(
                        name: "FK_CancerMachineType_Cancers_CancersId",
                        column: x => x.CancersId,
                        principalTable: "Cancers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CancerMachineType_MachineTypes_MachineTypesId",
                        column: x => x.MachineTypesId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Machines",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    MachineTypeId = table.Column<ulong>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Machines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Machines_MachineTypes_MachineTypeId",
                        column: x => x.MachineTypeId,
                        principalTable: "MachineTypes",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Occasions",
                columns: table => new
                {
                    Id = table.Column<ulong>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Date = table.Column<DateTime>(type: "TEXT", nullable: false),
                    TreatmentId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    MachineId = table.Column<ulong>(type: "INTEGER", nullable: false),
                    Machine = table.Column<ushort>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Occasions", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Occasions_Machines_MachineId",
                        column: x => x.MachineId,
                        principalTable: "Machines",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Occasions_Treatments_TreatmentId",
                        column: x => x.TreatmentId,
                        principalTable: "Treatments",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUsers_DoctorId1",
                table: "AspNetUsers",
                column: "DoctorId1");

            migrationBuilder.CreateIndex(
                name: "IX_CancerMachineType_MachineTypesId",
                table: "CancerMachineType",
                column: "MachineTypesId");

            migrationBuilder.CreateIndex(
                name: "IX_Machines_MachineTypeId",
                table: "Machines",
                column: "MachineTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Occasions_MachineId",
                table: "Occasions",
                column: "MachineId");

            migrationBuilder.CreateIndex(
                name: "IX_Occasions_TreatmentId",
                table: "Occasions",
                column: "TreatmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_CancerId",
                table: "Treatments",
                column: "CancerId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_DoctorId",
                table: "Treatments",
                column: "DoctorId");

            migrationBuilder.CreateIndex(
                name: "IX_Treatments_PatientId",
                table: "Treatments",
                column: "PatientId");

            migrationBuilder.AddForeignKey(
                name: "FK_AspNetUsers_Doctors_DoctorId1",
                table: "AspNetUsers",
                column: "DoctorId1",
                principalTable: "Doctors",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_AspNetUsers_Doctors_DoctorId1",
                table: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "CancerMachineType");

            migrationBuilder.DropTable(
                name: "Occasions");

            migrationBuilder.DropTable(
                name: "Machines");

            migrationBuilder.DropTable(
                name: "Treatments");

            migrationBuilder.DropTable(
                name: "MachineTypes");

            migrationBuilder.DropTable(
                name: "Cancers");

            migrationBuilder.DropTable(
                name: "Doctors");

            migrationBuilder.DropIndex(
                name: "IX_AspNetUsers_DoctorId1",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId",
                table: "AspNetUsers");

            migrationBuilder.DropColumn(
                name: "DoctorId1",
                table: "AspNetUsers");
        }
    }
}
