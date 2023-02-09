using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.OpenApi.Models;
using OnlineAccountingServer.WebApi.Middleware;

namespace OnlineAccountingServer.WebApi.Configurations
{
    public class PresentationServiceInstaller : IServiceInstaller
    {
        public void Install(IServiceCollection services, IConfiguration configuration)
        {
            services.AddControllers().AddApplicationPart(typeof(OnlineAccountingServer.Presentation.AssemblyReference).Assembly); // artık controller'ı presentation'da kullananbilirim

            services.AddScoped<ExceptionMiddleware>();

            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen(setup =>
             {
                 var jwtSecuritySheme = new OpenApiSecurityScheme
                 {
                     BearerFormat = "JWT",
                     Name = "JWT AUTHENTICATION",
                     In = ParameterLocation.Header,
                     Type = SecuritySchemeType.Http,
                     Scheme = JwtBearerDefaults.AuthenticationScheme,
                     Description = "JWT BEARER TOKEN",


                     Reference = new OpenApiReference
                     {
                         Id = JwtBearerDefaults.AuthenticationScheme,
                         Type = ReferenceType.SecurityScheme
                     }
                 };

                 setup.AddSecurityDefinition(jwtSecuritySheme.Reference.Id, jwtSecuritySheme);

                 setup.AddSecurityRequirement(new OpenApiSecurityRequirement
     {
        {jwtSecuritySheme,Array.Empty<string>() }
     });
             });
        }
    }
}
