﻿// <auto-generated />
using System;
using Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(BrawlstarsHelperDbContext))]
    [Migration("20250120080348_idekanymore")]
    partial class idekanymore
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "9.0.0")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Common.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountId"));

                    b.Property<int?>("ClubId")
                        .HasColumnType("int");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("AccountId");

                    b.HasIndex("ClubId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Common.Entities.AccountBrawler", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("BrawlerId")
                        .HasColumnType("int");

                    b.HasKey("AccountId", "BrawlerId");

                    b.HasIndex("BrawlerId");

                    b.ToTable("AccountBrawler");
                });

            modelBuilder.Entity("Common.Entities.AccountStats", b =>
                {
                    b.Property<int>("AccountStatsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("AccountStatsId"));

                    b.Property<int>("AccountId")
                        .HasColumnType("int");

                    b.Property<int>("Bling")
                        .HasColumnType("int");

                    b.Property<int>("Coins")
                        .HasColumnType("int");

                    b.Property<int>("Credits")
                        .HasColumnType("int");

                    b.Property<int>("DuoVictorires")
                        .HasColumnType("int");

                    b.Property<int>("Gems")
                        .HasColumnType("int");

                    b.Property<int>("PowerPoints")
                        .HasColumnType("int");

                    b.Property<int>("RankedHighestRank")
                        .HasColumnType("int");

                    b.Property<int>("RankedRank")
                        .HasColumnType("int");

                    b.Property<int>("SoloVictories")
                        .HasColumnType("int");

                    b.Property<int>("TrioVictories")
                        .HasColumnType("int");

                    b.Property<int>("Trophies")
                        .HasColumnType("int");

                    b.Property<int>("TrophiesHighest")
                        .HasColumnType("int");

                    b.HasKey("AccountStatsId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("AccountStats");
                });

            modelBuilder.Entity("Common.Entities.Brawler", b =>
                {
                    b.Property<int>("BrawlerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("BrawlerId"));

                    b.Property<int>("Attack")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<string>("MovementSpeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Range")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ReloadSpeed")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("BrawlerId");

                    b.ToTable("Brawlers");
                });

            modelBuilder.Entity("Common.Entities.BrawlerGears", b =>
                {
                    b.Property<int>("BrawlerId")
                        .HasColumnType("int");

                    b.Property<int>("GearId")
                        .HasColumnType("int");

                    b.Property<bool>("IsUnlocked")
                        .HasColumnType("bit");

                    b.HasKey("BrawlerId", "GearId");

                    b.HasIndex("GearId");

                    b.ToTable("BrawlerGears");
                });

            modelBuilder.Entity("Common.Entities.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ClubId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("MembersCount")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("RequiredTrophies")
                        .HasColumnType("int");

                    b.HasKey("ClubId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Common.Entities.Gadget", b =>
                {
                    b.Property<int>("GadgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GadgetId"));

                    b.Property<int>("BrawlerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsChosen")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("GadgetId");

                    b.HasIndex("BrawlerId");

                    b.ToTable("Gadgets");
                });

            modelBuilder.Entity("Common.Entities.Gear", b =>
                {
                    b.Property<int>("GearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("GearId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("UnlockCost")
                        .HasColumnType("int");

                    b.HasKey("GearId");

                    b.ToTable("Gears");
                });

            modelBuilder.Entity("Common.Entities.HyperCharge", b =>
                {
                    b.Property<int>("HyperChargeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("HyperChargeId"));

                    b.Property<int>("BrawlerId")
                        .HasColumnType("int");

                    b.Property<int>("DamageIncrease")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("ShieldIncrease")
                        .HasColumnType("int");

                    b.Property<int>("SpeedIncrease")
                        .HasColumnType("int");

                    b.HasKey("HyperChargeId");

                    b.HasIndex("BrawlerId")
                        .IsUnique();

                    b.ToTable("HyperCharges");
                });

            modelBuilder.Entity("Common.Entities.Map", b =>
                {
                    b.Property<int>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("MapId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("MapId");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("Common.Entities.Modifier", b =>
                {
                    b.Property<int>("ModifierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("ModifierId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("ModifierId");

                    b.ToTable("Modifiers");
                });

            modelBuilder.Entity("Common.Entities.Seasonal.SeasonalMap", b =>
                {
                    b.Property<int>("SeasonalMapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeasonalMapId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime>("SeasonEndDate")
                        .HasColumnType("datetime2");

                    b.Property<DateTime>("SeasonStartDate")
                        .HasColumnType("datetime2");

                    b.HasKey("SeasonalMapId");

                    b.ToTable("SeasonalMaps");
                });

            modelBuilder.Entity("Common.Entities.Seasonal.SeasonalModifier", b =>
                {
                    b.Property<int>("SeasonalModifierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("SeasonalModifierId"));

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<int>("SeasonalMapId")
                        .HasColumnType("int");

                    b.HasKey("SeasonalModifierId");

                    b.HasIndex("SeasonalMapId");

                    b.ToTable("SeasonalModifiers");
                });

            modelBuilder.Entity("Common.Entities.StarPower", b =>
                {
                    b.Property<int>("StarPowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("StarPowerId"));

                    b.Property<int>("BrawlerId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("IsChosen")
                        .HasColumnType("bit");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("StarPowerId");

                    b.HasIndex("BrawlerId");

                    b.ToTable("StarPowers");
                });

            modelBuilder.Entity("Common.Entities.Account", b =>
                {
                    b.HasOne("Common.Entities.Club", "Club")
                        .WithMany("Members")
                        .HasForeignKey("ClubId")
                        .OnDelete(DeleteBehavior.SetNull);

                    b.Navigation("Club");
                });

            modelBuilder.Entity("Common.Entities.AccountBrawler", b =>
                {
                    b.HasOne("Common.Entities.Account", "Account")
                        .WithMany("UnlockedBrawlers")
                        .HasForeignKey("AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Entities.Brawler", "Brawler")
                        .WithMany("UnlockedByAccounts")
                        .HasForeignKey("BrawlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");

                    b.Navigation("Brawler");
                });

            modelBuilder.Entity("Common.Entities.AccountStats", b =>
                {
                    b.HasOne("Common.Entities.Account", "Account")
                        .WithOne("AccountStats")
                        .HasForeignKey("Common.Entities.AccountStats", "AccountId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Account");
                });

            modelBuilder.Entity("Common.Entities.BrawlerGears", b =>
                {
                    b.HasOne("Common.Entities.Brawler", "Brawler")
                        .WithMany("UnlockedGears")
                        .HasForeignKey("BrawlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Common.Entities.Gear", "Gear")
                        .WithMany("UnlockedByBrawler")
                        .HasForeignKey("GearId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brawler");

                    b.Navigation("Gear");
                });

            modelBuilder.Entity("Common.Entities.Gadget", b =>
                {
                    b.HasOne("Common.Entities.Brawler", "Brawler")
                        .WithMany("Gadgets")
                        .HasForeignKey("BrawlerId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("Brawler");
                });

            modelBuilder.Entity("Common.Entities.HyperCharge", b =>
                {
                    b.HasOne("Common.Entities.Brawler", "Brawler")
                        .WithOne("HyperCharge")
                        .HasForeignKey("Common.Entities.HyperCharge", "BrawlerId")
                        .OnDelete(DeleteBehavior.Restrict);

                    b.Navigation("Brawler");
                });

            modelBuilder.Entity("Common.Entities.Seasonal.SeasonalModifier", b =>
                {
                    b.HasOne("Common.Entities.Seasonal.SeasonalMap", "SeasonalMap")
                        .WithMany("SeasonalModifiers")
                        .HasForeignKey("SeasonalMapId")
                        .OnDelete(DeleteBehavior.Restrict)
                        .IsRequired();

                    b.Navigation("SeasonalMap");
                });

            modelBuilder.Entity("Common.Entities.StarPower", b =>
                {
                    b.HasOne("Common.Entities.Brawler", "Brawler")
                        .WithMany("StarPowers")
                        .HasForeignKey("BrawlerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Brawler");
                });

            modelBuilder.Entity("Common.Entities.Account", b =>
                {
                    b.Navigation("AccountStats")
                        .IsRequired();

                    b.Navigation("UnlockedBrawlers");
                });

            modelBuilder.Entity("Common.Entities.Brawler", b =>
                {
                    b.Navigation("Gadgets");

                    b.Navigation("HyperCharge");

                    b.Navigation("StarPowers");

                    b.Navigation("UnlockedByAccounts");

                    b.Navigation("UnlockedGears");
                });

            modelBuilder.Entity("Common.Entities.Club", b =>
                {
                    b.Navigation("Members");
                });

            modelBuilder.Entity("Common.Entities.Gear", b =>
                {
                    b.Navigation("UnlockedByBrawler");
                });

            modelBuilder.Entity("Common.Entities.Seasonal.SeasonalMap", b =>
                {
                    b.Navigation("SeasonalModifiers");
                });
#pragma warning restore 612, 618
        }
    }
}
