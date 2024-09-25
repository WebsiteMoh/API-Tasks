using Microsoft.EntityFrameworkCore;
using Product.Data.Context;
using Product.Repository;

namespace WebAPI.Helper
{
    public class ApplySeeding
    {
        public static async Task ApplySeedingAsync(WebApplication app)
        {
            using(var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;
                try
                {
                    var context = services.GetRequiredService<ProductDBcontext>();
                    await context.Database.MigrateAsync();
                    await SaadAsync.SaadAsyncFile(context);
                }
                catch (Exception ex)
                {

                }
        
            }
        }
    }
}
