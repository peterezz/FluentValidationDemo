using AutoMapper;
using DairElAnbaBeshoy.AppLogic.AutoMapper;
using DairElAnbaBeshoy.AppLogic.Manager;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.AppLogic.Services
{
    public static class AddAutoMapper 
    {
        public static IServiceCollection RegisterAutoMapper(this IServiceCollection services)
        {
            var config = new MapperConfiguration(Mcf =>
            {
                Mcf.AddProfile(new DomainProfile());
            });
            var Mapper = config.CreateMapper();
            services.AddSingleton(Mapper);

            services.AddScoped<RegisterRetreaveManager>();
            services.AddScoped<RetreaveStatusesManager>();
            return services;
        }
    }
}
