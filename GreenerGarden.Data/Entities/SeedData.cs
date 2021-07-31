using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GreenerGarden.Data.Entities
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new ApplicationDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<ApplicationDbContext>>()))
            {
                if (context.Seasons.Any())
                {
                    return  ;
                }

                context.Seasons.AddRange(
                    new Season
                    {
                        Id = 1,
                        SeasonStart = DateTime.Parse("01-11-2020"),
                        SeasonEnd = DateTime.Parse("31-10-2021")
                    }
                    );
                context.SaveChanges();

                if (context.Cultures.Any())
                {
                    return;
                }

                context.Cultures.AddRange(
                    new Culture
                    {
                        CultureId = 1,
                        SeasonId = 1,
                        Name = "Letuce", 
                        Price = 20.00f
                    },
                    new Culture
                    {
                        CultureId = 2,
                        SeasonId = 1,
                        Name = "Onion",
                        Price = 60.00f
                    }
                    );
                context.SaveChanges();

                if (context.Expences.Any())
                {
                    return;
                }

                context.Expences.AddRange(
                    new Expence
                    {
                        ExpenceId = 1,
                        SeasonId = 1,
                        CultureId = 1,
                        ExpenceCategory = "Seed",
                        ExpenceDate = DateTime.Parse("15-11-2020"),
                        ExpenceAmount = 30.00f
                    },
                    new Expence
                    {
                        ExpenceId = 2,
                        SeasonId = 1,
                        CultureId = 2,
                        ExpenceCategory = "Seed",
                        ExpenceDate = DateTime.Parse("15-11-2020"),
                        ExpenceAmount = 236.00f
                    }
                );
            }
        }
    }
}
