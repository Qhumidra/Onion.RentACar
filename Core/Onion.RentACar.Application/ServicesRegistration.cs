using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Onion.RentACar.Application.Helpers.JWT;
using Onion.RentACar.Application.Utilities.Caching;
using Onion.RentACar.Application.Utilities.Mappings;
using System.Reflection;

namespace Onion.RentACar.Application
{
    public static class ServicesRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>()
                {
                    new CarProfile(),
                    new RentListProfile(),
                    new CategoryProfile(),
                    new AppUserProfile(),
                    new StatusProfile()
                });
            });

            services.AddMemoryCache();
            services.AddSingleton<ICacheManager, MicrosoftMemoryCacheManager>();

            services.AddSingleton<ITokenHelper, JwtHelper>();
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        }
    }
}
