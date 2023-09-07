using SEDC.BurgerApp.BLL.Services.Implementation;
using SEDC.BurgerApp.BLL.Services;
using SEDC.BurgerApp.DAL.Repositories;
using SEDC.BurgerApp.DAL.Models;

namespace SEDC.BurgerApp.Web
{
    public static class Dependencies
    {
        public static IServiceCollection AddDependencies(this IServiceCollection services)
        {
            services.AddScoped<IRepository<Order>, OrderRepository>();
            services.AddScoped<IRepository<Burger>, BurgerRepository>();
            services.AddScoped<IRepository<Location>, LocationRepository>();
            services.AddScoped<IBurgerService, BurgerService>();
            services.AddScoped<ILocationService, LocationService>();
            services.AddScoped<IOrderService, OrderService>();
            return services;
        }
    }
}
