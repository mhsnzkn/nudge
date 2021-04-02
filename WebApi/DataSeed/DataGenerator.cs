using DataAccess;
using Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.DataSeed
{
    public class DataGenerator
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new AppDbContext(
                serviceProvider.GetRequiredService<DbContextOptions<AppDbContext>>()))
            {
                // Look for any data
                if (context.Brands.Any())
                {
                    return;   // Data was already seeded
                }

                context.Brands.AddRange(
                    new Brand
                    {
                        Id = 1,
                        Name = "Dell",
                        Price = 349.87M
                    },
                    new Brand
                    {
                        Id = 2,
                        Name = "Toshiba",
                        Price = 345.67M
                    },
                    new Brand
                    {
                        Id = 3,
                        Name = "HP",
                        Price = 456.76M
                    });

                context.Configurations.AddRange(new Configuration
                {
                    Id = 1,
                    Name = "8 GB",
                    Price = 45.67M,
                    Type = Entities.Enum.ConfigurationType.Ram
                }, new Configuration
                {
                    Id = 2,
                    Name = "16 GB",
                    Price = 87.88M,
                    Type = Entities.Enum.ConfigurationType.Ram
                }, new Configuration
                {
                    Id = 3,
                    Name = "HDD 500 GB",
                    Price = 123.34M,
                    Type = Entities.Enum.ConfigurationType.Disk
                }, new Configuration
                {
                    Id = 4,
                    Name = "HDD 1 TB",
                    Price = 200M,
                    Type = Entities.Enum.ConfigurationType.Disk
                }, new Configuration
                {
                    Id = 5,
                    Name = "Red",
                    Price = 50.76M,
                    Type = Entities.Enum.ConfigurationType.Colour
                }, new Configuration
                {
                    Id = 6,
                    Name = "Blue",
                    Price = 34.56M,
                    Type = Entities.Enum.ConfigurationType.Colour
                });

                context.SaveChanges();
            }
        }
    }
}
