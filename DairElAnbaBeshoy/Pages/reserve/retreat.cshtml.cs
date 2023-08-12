using DairElAnbaBeshoy.AppLogic.Manager;
using DairElAnbaBeshoy.AppLogic.Validators;
using DairElAnbaBeshoy.AppLogic.ViewModel;
using DairElAnbaBeshoy.Core.Defaults;
using DairElAnbaBeshoy.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DairElAnbaBeshoy.Pages.reserve
{
    [Authorize( Roles = nameof( Roles.BasicUser ) )]
    public class retreatModel : PageModel
    {
        private readonly RetreaveManager registerRetreaveManager;
        private readonly UserManager<ApplicationUser> userManager;

        [BindProperty]
        public RetreaveVM? Input { get; set; }
        private readonly RetreaveValidator retreaveValidator;
        public retreatModel( RetreaveManager registerRetreaveManager , UserManager<ApplicationUser> userManager )
        {
            this.registerRetreaveManager = registerRetreaveManager;
            this.userManager = userManager;
            this.retreaveValidator = new RetreaveValidator( );
        }
        public void OnGet( )
        {
        }
        public IActionResult OnPost( )
        {
            var result = retreaveValidator.Validate( Input );
            if ( !result.IsValid )
            {
                foreach ( var item in result.Errors )
                {
                    ModelState.AddModelError( $"{nameof( Input )}.{item.PropertyName}" , item.ErrorMessage );
                }
                return Page( );
            }
            Input.LoggedinUserId = userManager.GetUserId( User );
            var registerResult = registerRetreaveManager.RegisterRetreave( Input );
            if ( registerResult == null )
                ModelState.AddModelError( "" , "لا يمكنك حجز الخلوة فى هذا اليوم، برجاء اختيار يوم اخر او محاولة حجز هذا اليوم فى وقت اخر" );
            else
                ViewData[ "RegisterSuccess" ] = "لقد تمكنت من حجز خلوتك، برجاء الانتظار حتى تتم الموافقة عليها";
            return Page( );

        }

    }
}
