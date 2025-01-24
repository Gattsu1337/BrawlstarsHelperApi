using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class HyperchargeModelChanges : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "HyperChargeRate",
                table: "Brawlers");

            migrationBuilder.DropColumn(
                name: "SuperChargeRate",
                table: "Brawlers");

            migrationBuilder.AddColumn<int>(
                name: "DamageIncrease",
                table: "HyperCharges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "ShieldIncrease",
                table: "HyperCharges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "SpeedIncrease",
                table: "HyperCharges",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<string>(
                name: "ReloadSpeed",
                table: "Brawlers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");

            migrationBuilder.AlterColumn<string>(
                name: "Range",
                table: "Brawlers",
                type: "nvarchar(max)",
                nullable: false,
                oldClrType: typeof(double),
                oldType: "float");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DamageIncrease",
                table: "HyperCharges");

            migrationBuilder.DropColumn(
                name: "ShieldIncrease",
                table: "HyperCharges");

            migrationBuilder.DropColumn(
                name: "SpeedIncrease",
                table: "HyperCharges");

            migrationBuilder.AlterColumn<double>(
                name: "ReloadSpeed",
                table: "Brawlers",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AlterColumn<double>(
                name: "Range",
                table: "Brawlers",
                type: "float",
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)");

            migrationBuilder.AddColumn<double>(
                name: "HyperChargeRate",
                table: "Brawlers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AddColumn<double>(
                name: "SuperChargeRate",
                table: "Brawlers",
                type: "float",
                nullable: false,
                defaultValue: 0.0);
        }
    }
}
