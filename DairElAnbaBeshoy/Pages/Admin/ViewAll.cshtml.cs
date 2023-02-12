using DairElAnbaBeshoy.AppLogic.Manager;
using DairElAnbaBeshoy.Core.Defaults;
using DairElAnbaBeshoy.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Linq.Dynamic.Core;
namespace DairElAnbaBeshoy.Pages.Admin
{
    [Authorize(Roles =nameof(Roles.Admin))]
    public class ViewAllModel : PageModel
    {
        public void OnGet()
        {

        }

        //TODO: delete reserve
    }
  
}
