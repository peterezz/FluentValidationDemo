using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.Core.Models
{
    public class Retreaves
    {
        public int Id { get; set; }
        public string LoggedinUserId { get; set; } = string.Empty;
        public string ReserverFullName { get; set; } = string.Empty;
        public int ResrversNumber { get; set; }
        public DateTime ResrveDate { get; set; }
        public string IdCardPhoto { get; set; } = string.Empty;
        public string Governorate { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public bool? IsApproved { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
    }
}