using Common.Entities;
using Common.Entities.Seasonal;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Repositories
{
    public class BrawlstarsHelperDbContext : DbContext
    {
        public DbSet<Account> Accounts { get; set; }
        public DbSet<Brawler> Brawlers { get; set; }
        public DbSet<StarPower> StarPowers { get; set; }
        public DbSet<Gadget> Gadgets { get; set; }
        public DbSet<Gear> Gears { get; set; }
        public DbSet<HyperCharge> HyperCharges { get; set; }
        public DbSet<Club> Clubs { get; set; }
        public DbSet<Map> Maps { get; set; }
        public DbSet<Modifier> Modifiers { get; set; }
        public DbSet<SeasonalMap> SeasonalMaps { get; set; }
        public DbSet<SeasonalModifier> SeasonalModifiers { get; set; }

        public BrawlstarsHelperDbContext(DbContextOptions<BrawlstarsHelperDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            #region Account Config
            modelBuilder.Entity<Account>()
                .HasKey(a => a.AccountId);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.AccountStats)
                .WithOne(s => s.Account)
                .HasForeignKey<AccountStats>(s => s.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Account>()
                .HasOne(a => a.Club)
                .WithMany(c => c.Members)
                .HasForeignKey(a => a.ClubId)
                .OnDelete(DeleteBehavior.SetNull);

            #endregion

            #region Brawler Config
            modelBuilder.Entity<Brawler>()
                .HasKey(b => b.BrawlerId);

            modelBuilder.Entity<Brawler>()
                .HasMany(b => b.StarPowers)
                .WithOne(s => s.Brawler)
                .HasForeignKey(s => s.BrawlerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Brawler>()
                .HasMany(b => b.Gadgets)
                .WithOne(g => g.Brawler)
                .HasForeignKey(g => g.BrawlerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Brawler>()
                .HasOne(b => b.HyperCharge)
                .WithOne(h => h.Brawler)
                .HasForeignKey<HyperCharge>(h => h.BrawlerId)
                .IsRequired(false)
                .OnDelete(DeleteBehavior.Cascade);


            #endregion

            #region AccountBrawler Config
            modelBuilder.Entity<AccountBrawler>()
                .HasKey(ab => new { ab.AccountId, ab.BrawlerId });

            modelBuilder.Entity<AccountBrawler>()
                .HasOne(ab => ab.Account)
                .WithMany(a => a.UnlockedBrawlers)
                .HasForeignKey(ab => ab.AccountId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<AccountBrawler>()
                .HasOne(ab => ab.Brawler)
                .WithMany(b => b.UnlockedByAccounts)
                .HasForeignKey(ab => ab.BrawlerId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region BrawlerGears Config
            modelBuilder.Entity<BrawlerGears>()
                .HasKey(bg => new { bg.BrawlerId, bg.GearId });

            modelBuilder.Entity<BrawlerGears>()
                .HasOne(bg => bg.Brawler)
                .WithMany(b => b.UnlockedGears)
                .HasForeignKey(bg => bg.BrawlerId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<BrawlerGears>()
                .HasOne(bg => bg.Gear)
                .WithMany(g => g.UnlockedByBrawler)
                .HasForeignKey(bg => bg.GearId)
                .OnDelete(DeleteBehavior.Cascade);
            #endregion

            #region StarPower Config
            modelBuilder.Entity<StarPower>()
                .HasKey(s => s.StarPowerId);

            modelBuilder.Entity<StarPower>()
                .HasOne(s => s.Brawler)
                .WithMany(b => b.StarPowers)
                .HasForeignKey(s => s.BrawlerId);
            #endregion

            #region Gadget Config
            modelBuilder.Entity<Gadget>()
                .HasKey(g => g.GadgetId);

            modelBuilder.Entity<Gadget>()
                .HasOne(g => g.Brawler)
                .WithMany(b => b.Gadgets)
                .HasForeignKey(g => g.BrawlerId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Gear Config
            modelBuilder.Entity<Gear>()
                .HasKey(g => g.GearId);
            #endregion

            #region HyperCharge Config
            modelBuilder.Entity<HyperCharge>()
                .HasKey(h => h.HyperChargeId);

            modelBuilder.Entity<HyperCharge>()
                .HasOne(h => h.Brawler)
                .WithOne(b => b.HyperCharge)
                .HasForeignKey<HyperCharge>(h => h.BrawlerId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region Club Config
            modelBuilder.Entity<Club>()
                .HasKey(c => c.ClubId);

            modelBuilder.Entity<Club>()
                .HasMany(c => c.Members)
                .WithOne(m => m.Club)
                .HasForeignKey(c => c.ClubId)
                .OnDelete(DeleteBehavior.SetNull);

            #endregion

            #region Map Config
            modelBuilder.Entity<Map>()
                .HasKey(m => m.MapId);

            modelBuilder.Entity<Map>()
                .Property(m => m.Stats)
                .HasColumnType("TEXT");

            #endregion

            #region Modifier Config
            modelBuilder.Entity<Modifier>()
                .HasKey(m => m.ModifierId);
            #endregion

            #region SeasonalMap Config
            modelBuilder.Entity<SeasonalMap>()
                .HasKey(smap => smap.SeasonalMapId);

            modelBuilder.Entity<SeasonalMap>()
                .HasMany(smap => smap.SeasonalModifiers)
                .WithOne(smod => smod.SeasonalMap)
                .HasForeignKey(smod => smod.SeasonalMapId)
                .OnDelete(DeleteBehavior.Restrict);
            #endregion

            #region SeasonalModifier Config
            modelBuilder.Entity<SeasonalModifier>()
                .HasKey(smod => smod.SeasonalModifierId);
            #endregion
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlite("Data Source=.\\brawlstars-helper-db\\brawlstarshelperdb.db");
            }
        }
    }
}
