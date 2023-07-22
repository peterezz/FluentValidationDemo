

using Microsoft.AspNetCore.Identity;

namespace DairElAnbaBeshoy.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime? DateOfBirth { get; set; } = DateTime.UtcNow;
        public string? FatherOfConfession { get; set; }
        public string? Governorate { get; set; }
        public string? WorkKnolege { get; set; }
        public string? Diocese { get; set; }
        public string? Church { get; set; }

        public ICollection<Retreaves> Retreaves { get; set; }
        public ICollection<RetreaveStatuses> retreaveStatuses { get; set; }


    }
}
