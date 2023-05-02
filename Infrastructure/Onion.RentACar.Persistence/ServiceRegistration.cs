using Microsoft.Extensions.DependencyInjection;
using Onion.RentACar.Application.Interfaces;
using Onion.RentACar.Persistence.Repositories;

namespace Onion.RentACar.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection services)
        {

            services.AddScoped<ICarDal, CarDal>();
            services.AddScoped<IUserDal, UserDal>();
        }
    }
}
