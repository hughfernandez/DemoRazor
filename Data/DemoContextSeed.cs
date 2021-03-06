using DemoRazor.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoRazor.Data
{
    public class DemoContextSeed
    {
        public static async Task SeedAsync(DemoContext demoContext, ILoggerFactory loggerFactory, int? retry = 0)
        {
            int retryForAvailability = retry.Value;

            try
            {

                if (!demoContext.Categories.Any())
                {
                    demoContext.Categories.AddRange(GetPreconfiguredCategories());
                    await demoContext.SaveChangesAsync();
                }

                if (!demoContext.Products.Any())
                {
                    demoContext.Products.AddRange(GetPreconfiguredProducts());
                    await demoContext.SaveChangesAsync();
                }
            }
            catch (Exception exception)
            {
                if (retryForAvailability < 10)
                {
                    retryForAvailability++;
                    var log = loggerFactory.CreateLogger<DemoContextSeed>();
                    log.LogError(exception.Message);
                    await SeedAsync(demoContext, loggerFactory, retryForAvailability);
                }
                throw;
            }
        }

        private static IEnumerable<Category> GetPreconfiguredCategories()
        {
            return new List<Category>()
            {
                new Category() { Name = "Telefonos", Description = "Smart Phones" },
                new Category() { Name = "TV", Description = "Television" }
            };
        }

        private static IEnumerable<Product> GetPreconfiguredProducts()
        {
            return new List<Product>()
            {
                new Product() { Name = "IPhone X", Description = "IPhone X", CategoryId = 1 },
                new Product() { Name = "Samsung 10", Description = "Samsung X", CategoryId = 1 },
                new Product() { Name = "LG 5", Description = "LG 5", CategoryId = 1 },
                new Product() { Name = "Huawei Plus", Description = "Huawei X", CategoryId = 2 }
            };
        }
    }
}
