using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class addedStarPowerAndImageURL : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "StarPowers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SeasonalModifiers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "SeasonalMaps",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Modifiers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Maps",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "HyperCharges",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Gears",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Gadgets",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Clubs",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Brawlers",
                type: "TEXT",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "ImageUrl",
                table: "Accounts",
                type: "TEXT",
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "StarPowers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SeasonalModifiers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "SeasonalMaps");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Modifiers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Maps");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "HyperCharges");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Gears");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Gadgets");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Clubs");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Brawlers");

            migrationBuilder.DropColumn(
                name: "ImageUrl",
                table: "Accounts");
        }
    }
}
