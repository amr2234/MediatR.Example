using System.Reflection;
using System.Text;
using MediatR.Application.Interfaces;
using MediatR.Domain;
using MediatR.Domain.Interfaces;
using MediatR.Domain.Interfaces.Features;
using MediatR.Domain.Interfaces.Persistence;
using MediatR.Example.ErrorHandler;
using MediatR.Example.Services;
using MediatR.Infrastructure;
using MediatR.Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace MediatR.Example.DependencyInjection
{
    public static class DependencyInjection
    {

        public static IServiceCollection ServicesRegsiter(this IServiceCollection services, IConfiguration config)



        {
          services.AddSwaggerGen(options =>
            {
                options.SwaggerDoc("V1", new OpenApiInfo
                {
                    Version = "V1",
                    Title = "WebAPI",
                    Description = "Product WebAPI"
                });
                options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Name = "Authorization",
                    Description = "Authentication with JWT Token",
                    Type = SecuritySchemeType.Http
                });
                options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
            });

            services.AddDbContext<DBContext_App>(options =>
              options.UseSqlServer(config.GetConnectionString("MainConnectionString")));
            services.AddScoped<IUnitofWORk, UnitOfWork>();
            services.AddScoped<ILogin, Login>();
            services.AddScoped(typeof(IProductAppSerives), typeof(ProductAppServices));
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenaricRepository<>));
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
 {
     options.TokenValidationParameters = new TokenValidationParameters
     {
         ValidateIssuer = true,
         ValidateAudience = true,
         ValidateLifetime = true,
         ValidateIssuerSigningKey = true,
         ValidIssuer = config["JWT:ValidIssuer"],
         ValidAudience = config["JWT:ValidAudience"],
         IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(config["JWT:Secret"]))
     };
 });
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(UnitofWorkbehavior<,>));

            });

            services.Configure<ApiBehaviorOptions>(
            option => option.InvalidModelStateResponseFactory = actioncontext =>
            {
                var error = actioncontext.ModelState.Where(e => e.Value.Errors.Count > 0).SelectMany(x => x.Value.Errors)
                    .Select(x => x.ErrorMessage).ToArray();
                var errorresponse = new ApiValidationErrorHandler
                {
                    Errors = error
                };
                return new BadRequestObjectResult(errorresponse);
            });



            return services;
        }

    }
}
