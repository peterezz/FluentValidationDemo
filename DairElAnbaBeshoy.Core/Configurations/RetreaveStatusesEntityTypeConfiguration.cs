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
    public class RetreaveStatusesEntityTypeConfiguration : IEntityTypeConfiguration<RetreaveStatuses>
    {
        public void Configure(EntityTypeBuilder<RetreaveStatuses> builder)
        {
            builder.Property(prop => prop.UserId).HasMaxLength(450);
            builder.Property(prop => prop.ReservationStatus).HasDefaultValue(false);
           builder.HasOne(retreavestatus=> retreavestatus.ApplicationUser).WithMany(apppUser=>apppUser.retreaveStatuses).HasForeignKey(retreavestatus=>retreavestatus.UserId);
        }
    }
}
