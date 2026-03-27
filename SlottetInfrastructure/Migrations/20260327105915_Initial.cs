using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Slottet.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ResidentSchemas",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TrafficLight = table.Column<int>(type: "int", nullable: false),
                    Employee = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResidentSchemas", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "MedicineStatuses",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Time = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Administered = table.Column<bool>(type: "bit", nullable: false),
                    ResidentSchemaId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MedicineStatuses", x => x.Id);
                    table.ForeignKey(
                        name: "FK_MedicineStatuses_ResidentSchemas_ResidentSchemaId",
                        column: x => x.ResidentSchemaId,
                        principalTable: "ResidentSchemas",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ResidentSchemas",
                columns: new[] { "Id", "Employee", "Name", "Note", "TrafficLight" },
                values: new object[] { 1, "Susanne", "Janne", "...", 1 });

            migrationBuilder.InsertData(
                table: "MedicineStatuses",
                columns: new[] { "Id", "Administered", "ResidentSchemaId", "Time" },
                values: new object[] { 1, true, 1, new DateTime(2026, 3, 27, 11, 0, 0, 0, DateTimeKind.Unspecified) });

            migrationBuilder.CreateIndex(
                name: "IX_MedicineStatuses_ResidentSchemaId",
                table: "MedicineStatuses",
                column: "ResidentSchemaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MedicineStatuses");

            migrationBuilder.DropTable(
                name: "ResidentSchemas");
        }
    }
}
