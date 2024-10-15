using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using System.Runtime.CompilerServices;

namespace WebAPI
{
    public static class SwaggerServicesExtensions
    {
        public static IServiceCollection AddSwagerDocumantion(this IServiceCollection services) {
            services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Title = "Title",
                    Version = "V1",
                    Contact = new OpenApiContact
                    {
                        Name = "Mohammed Abdou",
                        Email = "abdoumohammed9921",
                        Url = new Uri("")
                    }
                }
                );
                var secuirtySchema = new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "bearer",
                    Reference = new OpenApiReference
                    {
                        Id = "bearer",
                        Type = ReferenceType.SecurityScheme
                    }

                };
                options.AddSecurityDefinition("bearer", secuirtySchema);
                var securityRequirements = new OpenApiSecurityRequirement
                {
                    {secuirtySchema,new []{"bearer" } }
                };
                options.AddSecurityRequirement(securityRequirements);

            });
          
           
               
            return services;
        }
    }
}
