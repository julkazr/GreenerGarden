using GreenerGarden.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace GreenerGarden.MVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Season> Seasons { get; set; }
        public DbSet<Culture> Cultures { get; set; }
        public DbSet<Yield> Yields { get; set; }
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
        }
    }
}
