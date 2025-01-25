using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace API.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Brawlers",
                columns: table => new
                {
                    BrawlerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Type = table.Column<string>(type: "TEXT", nullable: false),
                    Rarity = table.Column<string>(type: "TEXT", nullable: false),
                    Health = table.Column<int>(type: "INTEGER", nullable: false),
                    Attack = table.Column<int>(type: "INTEGER", nullable: false),
                    MovementSpeed = table.Column<string>(type: "TEXT", nullable: false),
                    ReloadSpeed = table.Column<string>(type: "TEXT", nullable: false),
                    Range = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Brawlers", x => x.BrawlerId);
                });

            migrationBuilder.CreateTable(
                name: "Clubs",
                columns: table => new
                {
                    ClubId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    MembersCount = table.Column<int>(type: "INTEGER", nullable: false),
                    RequiredTrophies = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clubs", x => x.ClubId);
                });

            migrationBuilder.CreateTable(
                name: "Gears",
                columns: table => new
                {
                    GearId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    UnlockCost = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gears", x => x.GearId);
                });

            migrationBuilder.CreateTable(
                name: "Maps",
                columns: table => new
                {
                    MapId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Mode = table.Column<string>(type: "TEXT", nullable: false),
                    Stats = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Maps", x => x.MapId);
                });

            migrationBuilder.CreateTable(
                name: "Modifiers",
                columns: table => new
                {
                    ModifierId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Modifiers", x => x.ModifierId);
                });

            migrationBuilder.CreateTable(
                name: "SeasonalMaps",
                columns: table => new
                {
                    SeasonalMapId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    Mode = table.Column<string>(type: "TEXT", nullable: false),
                    SeasonStartDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    SeasonEndDate = table.Column<DateTime>(type: "TEXT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonalMaps", x => x.SeasonalMapId);
                });

            migrationBuilder.CreateTable(
                name: "Gadgets",
                columns: table => new
                {
                    GadgetId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    BrawlerId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsChosen = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Gadgets", x => x.GadgetId);
                    table.ForeignKey(
                        name: "FK_Gadgets_Brawlers_BrawlerId",
                        column: x => x.BrawlerId,
                        principalTable: "Brawlers",
                        principalColumn: "BrawlerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "HyperCharges",
                columns: table => new
                {
                    HyperChargeId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    BrawlerId = table.Column<int>(type: "INTEGER", nullable: false),
                    SpeedIncrease = table.Column<int>(type: "INTEGER", nullable: false),
                    DamageIncrease = table.Column<int>(type: "INTEGER", nullable: false),
                    ShieldIncrease = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HyperCharges", x => x.HyperChargeId);
                    table.ForeignKey(
                        name: "FK_HyperCharges_Brawlers_BrawlerId",
                        column: x => x.BrawlerId,
                        principalTable: "Brawlers",
                        principalColumn: "BrawlerId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "StarPowers",
                columns: table => new
                {
                    StarPowerId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    BrawlerId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsChosen = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_StarPowers", x => x.StarPowerId);
                    table.ForeignKey(
                        name: "FK_StarPowers_Brawlers_BrawlerId",
                        column: x => x.BrawlerId,
                        principalTable: "Brawlers",
                        principalColumn: "BrawlerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Accounts",
                columns: table => new
                {
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Username = table.Column<string>(type: "TEXT", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: false),
                    Email = table.Column<string>(type: "TEXT", nullable: false),
                    ClubId = table.Column<int>(type: "INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Accounts", x => x.AccountId);
                    table.ForeignKey(
                        name: "FK_Accounts_Clubs_ClubId",
                        column: x => x.ClubId,
                        principalTable: "Clubs",
                        principalColumn: "ClubId",
                        onDelete: ReferentialAction.SetNull);
                });

            migrationBuilder.CreateTable(
                name: "BrawlerGears",
                columns: table => new
                {
                    BrawlerId = table.Column<int>(type: "INTEGER", nullable: false),
                    GearId = table.Column<int>(type: "INTEGER", nullable: false),
                    IsUnlocked = table.Column<bool>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BrawlerGears", x => new { x.BrawlerId, x.GearId });
                    table.ForeignKey(
                        name: "FK_BrawlerGears_Brawlers_BrawlerId",
                        column: x => x.BrawlerId,
                        principalTable: "Brawlers",
                        principalColumn: "BrawlerId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_BrawlerGears_Gears_GearId",
                        column: x => x.GearId,
                        principalTable: "Gears",
                        principalColumn: "GearId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "SeasonalModifiers",
                columns: table => new
                {
                    SeasonalModifierId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>(type: "TEXT", nullable: false),
                    Description = table.Column<string>(type: "TEXT", nullable: false),
                    SeasonalMapId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_SeasonalModifiers", x => x.SeasonalModifierId);
                    table.ForeignKey(
                        name: "FK_SeasonalModifiers_SeasonalMaps_SeasonalMapId",
                        column: x => x.SeasonalMapId,
                        principalTable: "SeasonalMaps",
                        principalColumn: "SeasonalMapId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AccountBrawler",
                columns: table => new
                {
                    BrawlerId = table.Column<int>(type: "INTEGER", nullable: false),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountBrawler", x => new { x.AccountId, x.BrawlerId });
                    table.ForeignKey(
                        name: "FK_AccountBrawler_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AccountBrawler_Brawlers_BrawlerId",
                        column: x => x.BrawlerId,
                        principalTable: "Brawlers",
                        principalColumn: "BrawlerId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AccountStats",
                columns: table => new
                {
                    AccountStatsId = table.Column<int>(type: "INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    AccountId = table.Column<int>(type: "INTEGER", nullable: false),
                    Gems = table.Column<int>(type: "INTEGER", nullable: false),
                    PowerPoints = table.Column<int>(type: "INTEGER", nullable: false),
                    Coins = table.Column<int>(type: "INTEGER", nullable: false),
                    Credits = table.Column<int>(type: "INTEGER", nullable: false),
                    Bling = table.Column<int>(type: "INTEGER", nullable: false),
                    Trophies = table.Column<int>(type: "INTEGER", nullable: false),
                    TrophiesHighest = table.Column<int>(type: "INTEGER", nullable: false),
                    RankedRank = table.Column<int>(type: "INTEGER", nullable: false),
                    RankedHighestRank = table.Column<int>(type: "INTEGER", nullable: false),
                    SoloVictories = table.Column<int>(type: "INTEGER", nullable: false),
                    DuoVictorires = table.Column<int>(type: "INTEGER", nullable: false),
                    TrioVictories = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AccountStats", x => x.AccountStatsId);
                    table.ForeignKey(
                        name: "FK_AccountStats_Accounts_AccountId",
                        column: x => x.AccountId,
                        principalTable: "Accounts",
                        principalColumn: "AccountId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AccountBrawler_BrawlerId",
                table: "AccountBrawler",
                column: "BrawlerId");

            migrationBuilder.CreateIndex(
                name: "IX_Accounts_ClubId",
                table: "Accounts",
                column: "ClubId");

            migrationBuilder.CreateIndex(
                name: "IX_AccountStats_AccountId",
                table: "AccountStats",
                column: "AccountId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_BrawlerGears_GearId",
                table: "BrawlerGears",
                column: "GearId");

            migrationBuilder.CreateIndex(
                name: "IX_Gadgets_BrawlerId",
                table: "Gadgets",
                column: "BrawlerId");

            migrationBuilder.CreateIndex(
                name: "IX_HyperCharges_BrawlerId",
                table: "HyperCharges",
                column: "BrawlerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_SeasonalModifiers_SeasonalMapId",
                table: "SeasonalModifiers",
                column: "SeasonalMapId");

            migrationBuilder.CreateIndex(
                name: "IX_StarPowers_BrawlerId",
                table: "StarPowers",
                column: "BrawlerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AccountBrawler");

            migrationBuilder.DropTable(
                name: "AccountStats");

            migrationBuilder.DropTable(
                name: "BrawlerGears");

            migrationBuilder.DropTable(
                name: "Gadgets");

            migrationBuilder.DropTable(
                name: "HyperCharges");

            migrationBuilder.DropTable(
                name: "Maps");

            migrationBuilder.DropTable(
                name: "Modifiers");

            migrationBuilder.DropTable(
                name: "SeasonalModifiers");

            migrationBuilder.DropTable(
                name: "StarPowers");

            migrationBuilder.DropTable(
                name: "Accounts");

            migrationBuilder.DropTable(
                name: "Gears");

            migrationBuilder.DropTable(
                name: "SeasonalMaps");

            migrationBuilder.DropTable(
                name: "Brawlers");

            migrationBuilder.DropTable(
                name: "Clubs");
        }
    }
}
