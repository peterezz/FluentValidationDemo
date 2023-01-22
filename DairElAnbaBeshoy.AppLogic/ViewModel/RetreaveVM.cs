using DairElAnbaBeshoy.Core.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DairElAnbaBeshoy.AppLogic.ViewModel
{
    public class RetreaveVM
    {
        public int Id { get; set; }
        public string? LoggedinUserId { get; set; } = string.Empty;
        public string? ReserverFullName { get; set; } = string.Empty;
        public int? ResrversNumber { get; set; }
        public DateTime? ResrveDate { get; set; } 
        
        public string? GoverGovernorate { get; set; } = string.Empty;
        public string? Notes { get; set; } = string.Empty;
        public bool IsApproved { get; set; }
        public ApplicationUser? ApplicationUser { get; set; }

        // IdCardPhoto
        public string? IdCardPhoto { get; set; }
        public IFormFile? IdCardPhotoFile { get; set; }
        public string IdCardPhotoPath { get { return "/images/IdCards/" + IdCardPhoto; } }

    }
}
