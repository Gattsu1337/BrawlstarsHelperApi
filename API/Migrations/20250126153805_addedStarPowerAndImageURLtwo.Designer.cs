﻿// <auto-generated />
using System;
using Common.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace API.Migrations
{
    [DbContext(typeof(BrawlstarsHelperDbContext))]
    [Migration("20250126153805_addedStarPowerAndImageURLtwo")]
    partial class addedStarPowerAndImageURLtwo
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.12");

            modelBuilder.Entity("Common.Entities.Account", b =>
                {
                    b.Property<int>("AccountId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int?>("ClubId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Username")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("AccountId");

                    b.HasIndex("ClubId");

                    b.ToTable("Accounts");
                });

            modelBuilder.Entity("Common.Entities.AccountBrawler", b =>
                {
                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrawlerId")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountId", "BrawlerId");

                    b.HasIndex("BrawlerId");

                    b.ToTable("AccountBrawler");
                });

            modelBuilder.Entity("Common.Entities.AccountStats", b =>
                {
                    b.Property<int>("AccountStatsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("AccountId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Bling")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Coins")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Credits")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DuoVictorires")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Gems")
                        .HasColumnType("INTEGER");

                    b.Property<int>("PowerPoints")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RankedHighestRank")
                        .HasColumnType("INTEGER");

                    b.Property<int>("RankedRank")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SoloVictories")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrioVictories")
                        .HasColumnType("INTEGER");

                    b.Property<int>("Trophies")
                        .HasColumnType("INTEGER");

                    b.Property<int>("TrophiesHighest")
                        .HasColumnType("INTEGER");

                    b.HasKey("AccountStatsId");

                    b.HasIndex("AccountId")
                        .IsUnique();

                    b.ToTable("AccountStats");
                });

            modelBuilder.Entity("Common.Entities.Brawler", b =>
                {
                    b.Property<int>("BrawlerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("Attack")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("Health")
                        .HasColumnType("INTEGER");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("MovementSpeed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Range")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Rarity")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ReloadSpeed")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("BrawlerId");

                    b.ToTable("Brawlers");
                });

            modelBuilder.Entity("Common.Entities.BrawlerGears", b =>
                {
                    b.Property<int>("BrawlerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("GearId")
                        .HasColumnType("INTEGER");

                    b.Property<bool>("IsUnlocked")
                        .HasColumnType("INTEGER");

                    b.HasKey("BrawlerId", "GearId");

                    b.HasIndex("GearId");

                    b.ToTable("BrawlerGears");
                });

            modelBuilder.Entity("Common.Entities.Club", b =>
                {
                    b.Property<int>("ClubId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("MembersCount")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("RequiredTrophies")
                        .HasColumnType("INTEGER");

                    b.HasKey("ClubId");

                    b.ToTable("Clubs");
                });

            modelBuilder.Entity("Common.Entities.Gadget", b =>
                {
                    b.Property<int>("GadgetId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrawlerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<bool>("IsChosen")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("GadgetId");

                    b.HasIndex("BrawlerId");

                    b.ToTable("Gadgets");
                });

            modelBuilder.Entity("Common.Entities.Gear", b =>
                {
                    b.Property<int>("GearId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("UnlockCost")
                        .HasColumnType("INTEGER");

                    b.HasKey("GearId");

                    b.ToTable("Gears");
                });

            modelBuilder.Entity("Common.Entities.HyperCharge", b =>
                {
                    b.Property<int>("HyperChargeId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrawlerId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("DamageIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ShieldIncrease")
                        .HasColumnType("INTEGER");

                    b.Property<int>("SpeedIncrease")
                        .HasColumnType("INTEGER");

                    b.HasKey("HyperChargeId");

                    b.HasIndex("BrawlerId")
                        .IsUnique();

                    b.ToTable("HyperCharges");
                });

            modelBuilder.Entity("Common.Entities.Map", b =>
                {
                    b.Property<int>("MapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Stats")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("MapId");

                    b.ToTable("Maps");
                });

            modelBuilder.Entity("Common.Entities.Modifier", b =>
                {
                    b.Property<int>("ModifierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("ModifierId");

                    b.ToTable("Modifiers");
                });

            modelBuilder.Entity("Common.Entities.Seasonal.SeasonalMap", b =>
                {
                    b.Property<int>("SeasonalMapId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Mode")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SeasonEndDate")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("SeasonStartDate")
                        .HasColumnType("TEXT");

                    b.Property<string>("Stats")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("SeasonalMapId");

                    b.ToTable("SeasonalMaps");
                });

            modelBuilder.Entity("Common.Entities.Seasonal.SeasonalModifier", b =>
                {
                    b.Property<int>("SeasonalModifierId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("SeasonalMapId")
                        .HasColumnType("INTEGER");

                    b.HasKey("SeasonalModifierId");

                    b.HasIndex("SeasonalMapId");

                    b.ToTable("SeasonalModifiers");
                });

            modelBuilder.Entity("Common.Entities.StarPower", b =>
                {
                    b.Property<int>("StarPowerId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<int>("BrawlerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("ImageUrl")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

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
