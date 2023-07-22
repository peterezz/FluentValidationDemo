using DairElAnbaBeshoy.Core.Defaults;
using DairElAnbaBeshoy.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DairElAnbaBeshoy.Core.Configurations
{
    public class IdentityEntityTypeCofigurations : IEntityTypeConfiguration<ApplicationUser>
    {
        public void Configure( EntityTypeBuilder<ApplicationUser> builder )
        {
            builder.ToTable( "Users" );
            builder.Property( prop => prop.FullName ).HasMaxLength( 100 );
            builder.Property( prop => prop.FullName ).IsRequired( );
            builder.Property( prop => prop.DateOfBirth ).IsRequired( );
            builder.Property( prop => prop.PhoneNumber ).HasMaxLength( 11 );
            builder.Property( prop => prop.PhoneNumber ).IsRequired( );
            builder.Property( prop => prop.FatherOfConfession ).IsRequired( );
            builder.Property( prop => prop.PhoneNumberConfirmed ).HasMaxLength( 11 );
            builder.Property( prop => prop.FatherOfConfession ).HasMaxLength( 50 );

        }
        public class IdentityRoleEntityTypeCnfigurations : IEntityTypeConfiguration<IdentityRole>
        {
            public void Configure( EntityTypeBuilder<IdentityRole> builder )
            {
                builder.ToTable( "Roles" );
                builder.HasData( new IdentityRole( nameof( Roles.Admin ) ) );
                builder.HasData( new IdentityRole( nameof( Roles.BasicUser ) ) );
            }
        }
        public class IdentityUserRolesEntityTypeCnfigurations : IEntityTypeConfiguration<IdentityUserRole<string>>
        {
            public void Configure( EntityTypeBuilder<IdentityUserRole<string>> builder )
            {
                builder.ToTable( "UserRoles" );
            }
        }
        public class RoleClaimEntityTypeCnfigurations : IEntityTypeConfiguration<IdentityRoleClaim<string>>
        {
            public void Configure( EntityTypeBuilder<IdentityRoleClaim<string>> builder )
            {
                builder.ToTable( "RoleClaims" );
            }
        }
        public class UserClaimsEntityTypeCnfigurations : IEntityTypeConfiguration<IdentityUserClaim<string>>
        {
            public void Configure( EntityTypeBuilder<IdentityUserClaim<string>> builder )
            {
                builder.ToTable( "UserClaims" );
            }
        }
        public class IdentityUserTokensEntityTypeCnfigurations : IEntityTypeConfiguration<IdentityUserToken<string>>
        {
            public void Configure( EntityTypeBuilder<IdentityUserToken<string>> builder )
            {
                builder.ToTable( "UserTokens" );
            }
        }
        public class IdentityUserLoginEntityTypeCnfigurations : IEntityTypeConfiguration<IdentityUserLogin<string>>
        {
            public void Configure( EntityTypeBuilder<IdentityUserLogin<string>> builder )
            {
                builder.ToTable( "UserLogins" );
            }
        }
    }

}
