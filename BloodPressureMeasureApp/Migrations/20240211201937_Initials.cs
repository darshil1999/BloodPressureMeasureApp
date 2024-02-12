using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace BloodPressureMeasureApp.Migrations
{
    /// <inheritdoc />
    public partial class Initials : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BloodPressures",
                columns: table => new
                {
                    BloodPressureId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Systolic = table.Column<int>(type: "int", nullable: false),
                    Diastolic = table.Column<int>(type: "int", nullable: false),
                    MeasurementDate = table.Column<DateTime>(type: "date", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BloodPressures", x => x.BloodPressureId);
                });

            migrationBuilder.InsertData(
                table: "BloodPressures",
                columns: new[] { "BloodPressureId", "Diastolic", "MeasurementDate", "Systolic" },
                values: new object[,]
                {
                    { 1, 121, new DateTime(2008, 7, 2, 0, 0, 0, 0, DateTimeKind.Unspecified), 181 },
                    { 2, 91, new DateTime(2005, 5, 29, 0, 0, 0, 0, DateTimeKind.Unspecified), 142 },
                    { 3, 85, new DateTime(2002, 11, 24, 0, 0, 0, 0, DateTimeKind.Unspecified), 131 },
                    { 4, 79, new DateTime(1998, 5, 8, 0, 0, 0, 0, DateTimeKind.Unspecified), 122 },
                    { 5, 78, new DateTime(1996, 2, 9, 0, 0, 0, 0, DateTimeKind.Unspecified), 118 },
                    { 6, 100, new DateTime(1999, 11, 30, 0, 0, 0, 0, DateTimeKind.Unspecified), 160 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BloodPressures");
        }
    }
}
