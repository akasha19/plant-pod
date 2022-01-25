using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantPodService.Migrations
{
    public partial class add_room_entity_and_seeding_data : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    SensorId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true),
                    Description = table.Column<string>(type: "nvarchar(2048)", maxLength: 2048, nullable: true),
                    Facilities = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ImageSource = table.Column<string>(type: "nvarchar(64)", maxLength: 64, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "Facilities", "ImageSource", "Name", "SensorId" },
                values: new object[] { new Guid("487ac8ee-0d70-4377-b216-0045182b7638"), "presentation room for 100 people", "Airconditioning;heating;smartprojector;smartplants", "assets/img/room_1.jpg", "Presentation room", new Guid("196db225-e5ef-4636-b967-c214a0ddb73f") });

            migrationBuilder.InsertData(
                table: "Rooms",
                columns: new[] { "Id", "Description", "Facilities", "ImageSource", "Name", "SensorId" },
                values: new object[] { new Guid("177bead7-1b35-46c5-83ad-026faefa2ca1"), "meeting room for 8 people", "Airconditioning;heating;smartboard;smartplants", "assets/img/room_2.jpg", "Meeting room", new Guid("3dd86e81-b88c-4b37-b740-a662fa116245") });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Rooms");
        }
    }
}
