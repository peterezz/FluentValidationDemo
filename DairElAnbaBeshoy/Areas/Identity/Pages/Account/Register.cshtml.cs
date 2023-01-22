using DairElAnbaBeshoy.Core.Models;
using DairElAnbaBeshoy.Core.Defaults;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.WebUtilities;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Text.Encodings.Web;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace DairElAnbaBeshoy.Areas.Identity.Pages.Account
{
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore,
            SignInManager<ApplicationUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel Input { get; set; }

       public string? ReturnUrl { get; set; }

        public IList<AuthenticationScheme> ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessage = "يجب ادخال الايميل")]
            [EmailAddress(ErrorMessage = "يجب ادخل ايميل صحيح")]
            [Display(Name = "Email")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage ="يجب ادخال كلمة مرور")]
            [StringLength(100, ErrorMessage = "اقصى حد لكلمة السر هو 100 حرف  و اقل حد هو 6 احرف", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(Name = "Password")]
            public string Password { get; set; } = string.Empty;

            [DataType(DataType.Password)]
            [Required(ErrorMessage = "يجب ادخال كلمة مرور تأكيدية   ")]
            [Display(Name = "Confirm password")]
            [Compare("Password", ErrorMessage = "كلمة المرور وكلمة المرور التأكيدية غير متطابقتين.")]
            public string ConfirmPassword { get; set; } = string.Empty;
            [Required(ErrorMessage = "يجب ادخال الاسم الرباعى")]
            [StringLength(100, ErrorMessage = "اقصى حد للاسم الرباعى هو 100 حرف  و اقل حد هو 6 احرف", MinimumLength = 6)]
            public string FullName { get; set; } = string.Empty;

            [RegularExpression("^01[0125][0-9]{8}$", ErrorMessage = "يجب ادخال رقم هاتف صحيح")]
            [Required(ErrorMessage = "يجب ادخال  رقم الهاتف")]
            [StringLength(11, ErrorMessage = "اقصى حد لرقم الهاتف هو 11 رقم", MinimumLength = 11)]
            public string PhoneNumber { get; set; } = string.Empty;
            [Required(ErrorMessage = "يجب ادخال  تاريخ الميلاد")]
            public DateTime BirthDate { get; set; }
            [Required(ErrorMessage = "يجب ادخال  المؤهل")]
            public string WorkKnolege { get; set; } = string.Empty;
            [Required(ErrorMessage = "يجب ادخال  اسم المحافظة")]
            public string Governorate { get; set; } = string.Empty;
            [Required(ErrorMessage = " يجب ادخال اسم الايبارشية التابع لها")]
            public string Diocese { get; set; } = string.Empty;
            [Required(ErrorMessage = "يجب ادخال اسم الكنيسة التابع لها")]
            public string  Church { get; set; } = string.Empty;

            [Required(ErrorMessage = "يجب ادخال  اسم اب الاعتراف")]
            [StringLength(50, ErrorMessage = "اقصى حد لأسم اب الاعتراف  هو 50 حرف و اقل حد هو 6 احرف", MinimumLength = 6)]
            public string FatherOfConfession { get; set; } = string.Empty;
            
            public bool AgreeToAllterms { get; set; }
        }


        public async Task OnGetAsync(string? returnUrl = "")
        {
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl = "")
        {
            returnUrl ??= Url.Content("~/");
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {
                if(!Input.AgreeToAllterms)
                {
                   PageContext.ModelState.AddModelError($"{nameof(Input)}.{nameof(Input.AgreeToAllterms)}", "يجب الموافقة على جميع الشروط");
                    return Page();
                }
                var user = CreateUser();
                user.FatherOfConfession = Input.FatherOfConfession;
                user.PhoneNumber=Input.PhoneNumber;
                user.UserName = Input.Email;
                user.FullName = Input.FullName;
                user.DateOfBirth = Input.BirthDate;
                user.EmailConfirmed = true;
                user.Church = Input.Church;
                user.Diocese=Input.Diocese;
                user.WorkKnolege = Input.WorkKnolege;
                user.Governorate= Input.Governorate;
                await _userStore.SetUserNameAsync(user, Input.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, Input.Email, CancellationToken.None);
                var result = await _userManager.CreateAsync(user, Input.Password);

                if (result.Succeeded)
                {
                    _logger.LogInformation("User created a new account with password.");

                    var userId = await _userManager.GetUserIdAsync(user);
                    user.Id=userId;
                    await _userManager.AddToRoleAsync(user,nameof(Roles.BasicUser));

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = userId, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    //await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                    //    $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }

        private ApplicationUser CreateUser()
        {
            try
            {
                return Activator.CreateInstance<ApplicationUser>();
            }
            catch
            {
                throw new InvalidOperationException($"Can't create an instance of '{nameof(ApplicationUser)}'. " +
                    $"Ensure that '{nameof(ApplicationUser)}' is not an abstract class and has a parameterless constructor, or alternatively " +
                    $"override the register page in /Areas/Identity/Pages/Account/Register.cshtml");
            }
        }

        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}
