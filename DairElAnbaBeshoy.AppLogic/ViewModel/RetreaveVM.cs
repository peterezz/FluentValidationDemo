using DairElAnbaBeshoy.Core.Models;
using Microsoft.AspNetCore.Http;

namespace DairElAnbaBeshoy.AppLogic.ViewModel
{
    public class RetreaveVM
    {
        public int Id { get; set; }
        public string LoggedinUserId { get; set; } = string.Empty;
        public string ReserverFullName { get; set; } = string.Empty;
        public int ResrversNumber { get; set; }
        public DateTime ReserveDateTime { get; set; }
        public string ReserveDate { get { return ReserveDateTime.ToLongDateString( ); } }
        public string ReserveTime { get { return ReserveDateTime.ToLongTimeString( ); } }
        public string Governorate { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
        public string IsApprovedMassage { get { return IsApproved ? "تم القبول" : " تم الرفض"; } }
        public ApplicationUser? ApplicationUser { get; set; }

        // IdCardPhoto
        public string IdCardPhoto { get; set; } = string.Empty;
        public IFormFile? IdCardPhotoFile { get; set; }
        public string IdCardPhotoPath { get { return "/images/IdCards/" + IdCardPhoto; } }
        public decimal? ThatDayReserves { get; set; }
        public decimal? NumEmptyPlaces { get; set; }
    }
}
