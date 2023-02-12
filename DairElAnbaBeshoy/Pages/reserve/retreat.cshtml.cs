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
    [Authorize(Roles = nameof(Roles.BasicUser))]
    public class retreatModel : PageModel
    {
        private readonly RegisterRetreaveManager registerRetreaveManager;
        private readonly UserManager<ApplicationUser> userManager;

        [BindProperty]
        public RetreaveVM? Input { get; set; }
        private readonly RetreaveValidator retreaveValidator;
        public retreatModel(RegisterRetreaveManager registerRetreaveManager,UserManager<ApplicationUser>userManager )
        {
            this.registerRetreaveManager = registerRetreaveManager;
            this.userManager = userManager;
            this.retreaveValidator = new RetreaveValidator();   
        }
        public void OnGet()
        {
        }
        public  IActionResult OnPost()
        {
            var result = retreaveValidator.Validate(Input);
            if(!result.IsValid)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError($"{nameof(Input)}.{item.PropertyName}", item.ErrorMessage);
                }
                return Page();
            }
            Input.LoggedinUserId = userManager.GetUserId(User);
            registerRetreaveManager.RegisterRetreave(Input); 
            return Page();   

        }

    }
}
