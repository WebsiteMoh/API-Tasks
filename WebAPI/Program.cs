using Microsoft.EntityFrameworkCore;
using Product.Data.Context;
using Product.Repository.BasketRep;
using Product.Repository.Interfaces;
using Product.Services;
using Product.Services.Basket;
using Product.Services.CacheService;
using Product.Services.DTO;
using Product.Services.OrderServices;
using StackExchange.Redis;
using WebAPI.Helper;
using WebAPI.Middleware;

namespace WebAPI
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            builder.Services.AddDbContext<ProductDBcontext>(
               option => option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"))
               );
            builder.Services.AddScoped<IProduct, ProductRep>();
            builder.Services.AddScoped<IproductServices, ProductServices>();
            builder.Services.AddScoped<IOrderService, Order>();
            builder.Services.AddScoped<IbasketRep, basketRep>();
            builder.Services.AddScoped<IBasketService, BasketService>();
            builder.Services.AddScoped<ICacheService, CacheService>();

            builder.Services.AddIdentityServices(builder.Configuration);

            builder.Services.AddAutoMapper(typeof(ProductProfile).Assembly);
            builder.Services.AddSingleton<IConnectionMultiplexer>(config =>
            {
                var conf = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"));
                return ConnectionMultiplexer.Connect(conf);
            });
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwagerDocumantion();



            var app = builder.Build();
            await ApplySeeding.ApplySeedingAsync(app);

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }
           // app.UseMiddleware<ExceptionMiddleware>();
            app.UseStaticFiles();

            app.UseHttpsRedirection();

            app.UseAuthorization();
            app.MapControllers();

            app.Run();
        }
    }
}