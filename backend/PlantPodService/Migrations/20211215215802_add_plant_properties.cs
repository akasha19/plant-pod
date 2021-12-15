using Microsoft.EntityFrameworkCore.Migrations;

namespace PlantPodService.Migrations
{
    public partial class add_plant_properties : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Plants",
                newName: "ShortName");

            migrationBuilder.AddColumn<string>(
                name: "Care",
                table: "Plants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Plants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Image",
                table: "Plants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "LongName",
                table: "Plants",
                type: "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxHumidity",
                table: "Plants",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MaxTemperature",
                table: "Plants",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Maxph",
                table: "Plants",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinHumidity",
                table: "Plants",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "MinTemperature",
                table: "Plants",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Minph",
                table: "Plants",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<decimal>(
                name: "Moisture",
                table: "Plants",
                type: "TEXT",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Care",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Image",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "LongName",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "MaxHumidity",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "MaxTemperature",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Maxph",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "MinHumidity",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "MinTemperature",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Minph",
                table: "Plants");

            migrationBuilder.DropColumn(
                name: "Moisture",
                table: "Plants");

            migrationBuilder.RenameColumn(
                name: "ShortName",
                table: "Plants",
                newName: "Name");
        }
    }
}
