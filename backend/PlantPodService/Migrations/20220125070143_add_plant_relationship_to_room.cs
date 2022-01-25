using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantPodService.Migrations
{
    public partial class add_plant_relationship_to_room : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<Guid>(
                name: "PlantId",
                table: "Rooms",
                type: "uniqueidentifier",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("177bead7-1b35-46c5-83ad-026faefa2ca1"),
                column: "PlantId",
                value: new Guid("79924374-44ad-4f9f-938b-6ac89e7ec60c"));

            migrationBuilder.UpdateData(
                table: "Rooms",
                keyColumn: "Id",
                keyValue: new Guid("487ac8ee-0d70-4377-b216-0045182b7638"),
                column: "PlantId",
                value: new Guid("0ef97408-0dac-46cf-aba1-d07235992bdd"));

            migrationBuilder.CreateIndex(
                name: "IX_Rooms_PlantId",
                table: "Rooms",
                column: "PlantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Rooms_Plants_PlantId",
                table: "Rooms",
                column: "PlantId",
                principalTable: "Plants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Rooms_Plants_PlantId",
                table: "Rooms");

            migrationBuilder.DropIndex(
                name: "IX_Rooms_PlantId",
                table: "Rooms");

            migrationBuilder.DropColumn(
                name: "PlantId",
                table: "Rooms");
        }
    }
}
