using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantPodService.Migrations
{
    public partial class Initial_Create : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Plants",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    LongName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    ShortName = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Care = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    MinTemperature = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    MaxTemperature = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Minph = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Maxph = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    MinHumidity = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    MaxHumidity = table.Column<decimal>(type: "decimal(16,2)", nullable: false),
                    Moisture = table.Column<int>(type: "int", nullable: false),
                    Image = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Plants", x => x.Id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Plants");
        }
    }
}
