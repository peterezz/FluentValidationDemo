using DairElAnbaBeshoy.Core.Models;
using DairElAnbaBeshoy.Core.Seed;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace DairElAnbaBeshoy.Core.Services
{
    public static class RegisterAdminUser
    {
        public static async Task<IServiceCollection> AddAdminUserAsync( this IServiceCollection service )
        {
            #region Build service provider
            var _serviceProvider = service.BuildServiceProvider( );
            var scope = _serviceProvider.CreateScope( );
            var services = scope.ServiceProvider;
            // created logger service
            var loggerFactory = services.GetRequiredService<ILoggerFactory>( );
            var _logger = loggerFactory.CreateLogger( "app" );
            #endregion

            var _userManager = services.GetRequiredService<UserManager<ApplicationUser>>( );
            _ = await _userManager.SeedAdminUserAsync( );
            return service;
        }
    }
}
