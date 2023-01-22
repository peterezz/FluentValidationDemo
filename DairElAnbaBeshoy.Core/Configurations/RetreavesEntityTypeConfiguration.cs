using DairElAnbaBeshoy.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.Core.Configurations
{
    public class RetreavesEntityTypeConfiguration : IEntityTypeConfiguration<Retreaves>
    {
        public void Configure(EntityTypeBuilder<Retreaves> builder)
        {
            builder.Property(prop => prop.ReserverFullName).HasMaxLength(100);
            builder.Property(prop => prop.LoggedinUserId).HasMaxLength(450);
            builder.Property(prop => prop.IsApproved).HasDefaultValue(false);

            builder.HasOne(Retreave => Retreave.ApplicationUser).WithMany(applicationUser => applicationUser.Retreaves).HasForeignKey(forignKey => forignKey.LoggedinUserId);
        }
    }
}
