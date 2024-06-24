using Microsoft.Extensions.DependencyInjection;
using CarWorkshop.Storage.Repository;
using CarWorkshop.Storage;
using CarWorkshop.Service.Query.Client;
using CarWorkshop.Service.Query.Dtos;
using CarWorkshop.Service.Query;

namespace CarWorkshop.Extensions
{
    public static class CarWorkshopExtension
    {
        public static IServiceCollection AddCarWorkshopServices(this IServiceCollection serviceCollection)
        {
            serviceCollection.AddScoped<ICarWorkshopRepository, CarWorkshopRepository>();
            serviceCollection.AddDbContext<CarWorkshopDbContext>();
            return serviceCollection;
        }
    }
}
