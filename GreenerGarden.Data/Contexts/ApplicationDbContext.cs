using GreenerGarden.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenerGarden.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<CropYield> CropYields { get; set; }
        public DbSet<Note> Notes { get; set; }
        public DbSet<Expence> Expences { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            /// <summary>
            /// Culture -> Season relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Culture>()
                        .HasOne(x => x.Season)
                        .WithMany(x => x.Cultures)
                        .HasForeignKey(x => x.SeasonId);

            /// <summary>
            /// Season -> Culture relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Season>()
                        .HasMany(x => x.Cultures)
                        .WithOne(x => x.Season);

            /// <summary>
            /// Culture -> Yeald relation
            /// </summary>
            /// <returns></returns>
            modelBuilder.Entity<Culture>()
                        .HasMany(x => x.CropYields)
                        .WithOne(x => x.Culture);

            ///<summary>
            ///Yield -> Culture relation
            ///</summary>
            ///<returns></returns>
            modelBuilder.Entity<CropYield>()
                        .HasOne(x => x.Culture)
                        .WithMany(x => x.CropYields)
                        .HasForeignKey(x => x.CultureId);

            ///<summary>
            ///Expence -> Culture relation
            ///</summary>
            ///<returns></returns>
            modelBuilder.Entity<Expence>()
                        .HasOne(x => x.Culture)
                        .WithMany(x => x.Expences)
                        .HasForeignKey(x => x.CultureId)
                        .OnDelete(DeleteBehavior.NoAction);

            ///<summary>
            ///Culture -> Expence relation
            ///</summary>
            ///<returns></returns>
            modelBuilder.Entity<Culture>()
                        .HasMany(x => x.Expences)
                        .WithOne(x => x.Culture);

            ///<summary>
            ///Expence -> ESeason relation
            ///</summary>
            ///<returns></returns>
            modelBuilder.Entity<Expence>()
                        .HasOne(x => x.Season)
                        .WithMany(x => x.Expences)
                        .HasForeignKey(x => x.SeasonId)
                        .OnDelete(DeleteBehavior.NoAction);

            ///<summary>
            ///Season -> Expence relation
            ///</summary>
            ///<returns></returns>
            modelBuilder.Entity<Season>()
                        .HasMany(x => x.Expences)
                        .WithOne(x => x.Season);
        }
    }
}
