using Microsoft.AspNetCore.Identity;
using Product.Data.Data.Identity;
using System.Runtime.CompilerServices;

namespace WebAPI
{
    public static class IdentityExtension
    {
        public static IServiceCollection AddIdentityServices(this IServiceCollection services, ConfigurationManager configuration)
        {
            var builder=services.AddIdentityCore<AppUser>();
            builder = new IdentityBuilder(builder.UserType, builder.Services);
          
            builder.AddSignInManager<SignInManager<AppUser>>();
            services.AddAuthentication();
            return services;

        }
    }
}
