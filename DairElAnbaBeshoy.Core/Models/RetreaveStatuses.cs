using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DairElAnbaBeshoy.Core.Models
{
    public class RetreaveStatuses
    {
        public int Id { get; set; }
        public ApplicationUser ApplicationUser { get; set; }
        public string UserId { get; set; } = string.Empty;
        public DateTime ReservationDate { get; set; }
        public bool ReservationStatus { get; set; }
    }
}
