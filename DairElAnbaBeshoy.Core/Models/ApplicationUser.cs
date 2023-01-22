

using Microsoft.AspNetCore.Identity;

namespace DairElAnbaBeshoy.Core.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; } = string.Empty;
        public DateTime DateOfBirth { get; set; }
        public string FatherOfConfession { get; set; } = string.Empty;
        public string Governorate { get; set; } = string.Empty;
        public string WorkKnolege { get; set; } = string.Empty;
        public string Diocese { get; set; } = string.Empty;
        public string Church { get; set; } = string.Empty;

        public ICollection<Retreaves> Retreaves { get; set; }


    }
}
