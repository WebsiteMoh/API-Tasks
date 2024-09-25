using Product.Data.Context;
using Product.Data.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace Product.Repository
{
    public class SaadAsync {
        public static async Task SaadAsyncFile(ProductDBcontext context)
        {
            try
            {
                if (context.ProductsBrand != null && !context.ProductsBrand.Any())
                {
                    var brandsData = File.ReadAllText("../Product.Repository/Seed/brands.json");
                    var brands = JsonSerializer.Deserialize<List<ProductBrand>>(brandsData);
                    if(brands is not null)
                    {
                        await context.ProductsBrand.AddRangeAsync(brands);
                    }
                }
                 if (context.ProductsType != null && !context.ProductsType.Any())
                {
                    var ProductsTypeData = File.ReadAllText("../Product.Repository/Seed/types.json");
                    var Types = JsonSerializer.Deserialize<List<ProductType>>(ProductsTypeData);
                    if (Types is not null)
                    {
                        await context.ProductsType.AddRangeAsync(Types);
                    }
                }
                 if (context.Products != null && !context.Products.Any())
                {
                    var ProductsData = File.ReadAllText("../Product.Repository/Seed/products.json");
                    var products = JsonSerializer.Deserialize<List<Products>>(ProductsData);
                    if (products is not null)
                    {
                        await context.Products.AddRangeAsync(products);
                    }
                }
                await context.SaveChangesAsync();
            }
            catch { }
        }
    }
    
    
}
