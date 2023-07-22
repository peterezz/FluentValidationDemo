using DairElAnbaBeshoy.Core.Defaults;
using DairElAnbaBeshoy.Core.Models;
using Microsoft.AspNetCore.Identity;

namespace DairElAnbaBeshoy.Core.Seed
{
    public static class AdminUserSeed
    {
        public static async Task<UserManager<ApplicationUser>> SeedAdminUserAsync( this UserManager<ApplicationUser> manager )
        {
            ApplicationUser adminUser = new( )
            {
                UserName = AdminUser.Username ,
                Email = AdminUser.EmailAddress ,
                EmailConfirmed = AdminUser.EmailConfirmed ,
                PhoneNumber = AdminUser.PhoneNumber ,
                FullName = AdminUser.FullName ,
                FatherOfConfession = "N/A"
            };
            if ( await manager.FindByEmailAsync( adminUser.Email ) == null )
            {
                var adminAccount = await manager.CreateAsync( adminUser , AdminUser.Password );
                if ( adminAccount.Succeeded )
                {
                    await manager.AddToRoleAsync( adminUser , nameof( Roles.Admin ) );
                }
            }
            return manager;
        }
    }
}
