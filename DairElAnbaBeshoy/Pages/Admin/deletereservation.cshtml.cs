using DairElAnbaBeshoy.AppLogic.Manager;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DairElAnbaBeshoy.Pages.Admin
{
    public class deletereservationModel : PageModel
    {
        private readonly RetreaveManager registerRetreaveManager;

        [BindProperty(SupportsGet =true)]
        public int ReservationID { get; set; }
        public deletereservationModel(RetreaveManager registerRetreaveManager)
        {
            this.registerRetreaveManager = registerRetreaveManager;
        }
        public IActionResult OnGet()
        {
            if(ReservationID == 0 )
                return BadRequest();
            RetreaveVM retreave = registerRetreaveManager.GetRetreave(ReservationID);
            if(retreave == null)
                return NotFound();
             registerRetreaveManager.DeleteRetreave(retreave);
            return RedirectToPage("/admin/viewall");
        }
    }
}
