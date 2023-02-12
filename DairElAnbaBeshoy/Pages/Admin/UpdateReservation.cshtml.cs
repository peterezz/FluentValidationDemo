using DairElAnbaBeshoy.AppLogic.Manager;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DairElAnbaBeshoy.Pages.Admin
{
    [ValidateAntiForgeryToken]
    public class UpdateReservationModel : PageModel
    {

        private readonly RegisterRetreaveManager registerRetreaveManager;

        [BindProperty(SupportsGet =true)]
        public int ReservationID { get; set; }
        [BindProperty(SupportsGet = true)]
        public RetreaveVM retreave { get; set; }
        public UpdateReservationModel(RegisterRetreaveManager registerRetreaveManager)
        {

            this.registerRetreaveManager = registerRetreaveManager;
        }
        public IActionResult OnGet()
        {
            if (ReservationID == 0)
                return BadRequest();
            retreave = registerRetreaveManager.GetRetreave(ReservationID);
            if (retreave == null)
               return NotFound();
            return Page();

        }

        public IActionResult OnPost()
        {
 
            registerRetreaveManager.UpdateRetreave(retreave);
            return RedirectToPage("/admin/viewall");
        }
    }
}
