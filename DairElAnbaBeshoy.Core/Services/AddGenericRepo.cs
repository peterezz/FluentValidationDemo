using DairElAnbaBeshoy.Core.Interfaces;
using DairElAnbaBeshoy.Core.Repository;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.Core.Services
{
    public static class AddGenericRepo
    {
        public static IServiceCollection RegisterGenericRepo(this IServiceCollection services)
        {
            //services.AddScoped<IRepository<Func<>>, BaseRepo>();
            return services;
        }
    }
}
