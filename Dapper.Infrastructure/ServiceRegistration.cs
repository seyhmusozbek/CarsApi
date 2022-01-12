using Dapper.Application.Interfaces;
using Dapper.Infrastructure.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace Dapper.Infrastructure
{
    public static class ServiceRegistration
    {
        public static void AddInfrastructure(this IServiceCollection services)
        {
            services.AddTransient<ICarRepository, CarRepository>();
            services.AddTransient<IBasketRepository, BasketRepository>();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
        }
    }
}
