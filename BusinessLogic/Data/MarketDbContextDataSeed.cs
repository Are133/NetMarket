using Core.Entities;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;

namespace BusinessLogic.Data
{
    public class MarketDbContextDataSeed
    {
        public static async Task LoadDataSeedAsync(MarketDbContext marketDbContext, ILoggerFactory loggerFactory)
        {
            try
            {
                if (!marketDbContext.TraderMarks.Any())
                {
                    var marksData = File.ReadAllText("../BusinessLogic/SeedData/marca.json");
                    var marksTraders = JsonSerializer.Deserialize<List<TraderMark>>(marksData);

                    foreach (var item in marksTraders)
                    {
                        marketDbContext.TraderMarks.Add(item);
                    }

                    await marketDbContext.SaveChangesAsync();
                }

                if (!marketDbContext.Categories.Any())
                {
                    var categoryData = File.ReadAllText("../BusinessLogic/SeedData/categoria.json");
                    var catetegories = JsonSerializer.Deserialize<List<Category>>(categoryData);

                    foreach (var item in catetegories)
                    {
                        marketDbContext.Categories.Add(item);
                    }

                    await marketDbContext.SaveChangesAsync();
                }

                if (!marketDbContext.Products.Any())
                {
                    var productData = File.ReadAllText("../BusinessLogic/SeedData/producto.json");
                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    foreach (var item in products)
                    {
                        marketDbContext.Products.Add(item);
                    }

                    await marketDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                var logger = loggerFactory.CreateLogger<MarketDbContextDataSeed>();
                logger.LogError(ex.Message);
            }
        }
    }
}
