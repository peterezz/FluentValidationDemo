using DairElAnbaBeshoy.AppLogic.Manager;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DairElAnbaBeshoy.Pages.Admin
{
    [ValidateAntiForgeryToken]
    public class UpdateReservationModel : PageModel
    {

        private readonly RegisterRetreaveManager registerRetreaveManager;

        [BindProperty( SupportsGet = true )]
        public int ReservationID { get; set; }
        [BindProperty( SupportsGet = true )]
        public RetreaveVM retreave { get; set; }
        public UpdateReservationModel( RegisterRetreaveManager registerRetreaveManager )
        {

            this.registerRetreaveManager = registerRetreaveManager;
        }
        public IActionResult OnGet( )
        {
            //int totalPalces = 30;
            if ( ReservationID == 0 )
                return BadRequest( );
            retreave = registerRetreaveManager.GetRetreave( ReservationID );
            if ( retreave == null )
                return NotFound( );
            ViewData[ "NumEmptyPlaces" ] = retreave.NumEmptyPlaces;
            if ( retreave.NumEmptyPlaces >= retreave.ResrversNumber )
                ViewData[ "ShowApproveButton" ] = true;
            return Page( );

        }

        public IActionResult OnPost( )
        {
            retreave.IsApproved = true;
            var retrieve = registerRetreaveManager.UpdateRetreave( retreave );
            if ( retrieve == null )
                ViewData[ "ApproveRejected" ] = "لا يمكن الموافقة على هذا الطلب لان عدد الاماكن المتاحة لا تكفى";
            return RedirectToPage( "/admin/viewall" );
        }
    }
}
