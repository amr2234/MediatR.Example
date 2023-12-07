using System.Reflection;
using MediatR.Domain;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace MediatR.Example.DependencyInjection
{
    public static class DependencyInjection
    {
        public static  IServiceCollection AddApplication(this IServiceCollection services)

        {
            services.AddMediatR(cfg =>
            {
                cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly());
                cfg.AddOpenBehavior(typeof(UnitofWorkbehavior<,>));

            });
            return services;
        }
        
    }
}
