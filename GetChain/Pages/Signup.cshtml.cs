using System.Threading.Tasks;
using GetChain.Core.User;
using GetChain.Forms;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class SignupModel : PageModel {
        private readonly ILogger<SignupModel> _logger;
        private readonly IAppUserManager _userManager;

        [BindProperty] public SignUpForm SignupForm { get; set; }

        public SignupModel(ILogger<SignupModel> logger, IAppUserManager userManager) {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnPost() {
            if ( !this.ModelState.IsValid )
                return this.Page();

            this._logger.LogInformation($"Signing up user {SignupForm.Username}");

            var user = new ApplicationUser(SignupForm.Username, SignupForm.Email);
            var result = await _userManager.CreateAsync(user, SignupForm.Password);

            this._logger.LogInformation($"Created user {SignupForm.Username}");
            
            if ( result.Succeeded ) {
                await this._userManager.SignInAsync(user, true);
                
                return this.RedirectToPage("/Dashboard");
            } else {
                foreach ( var error in result.Errors ) {
                    this.ModelState.AddModelError(error.Code, error.Description);
                    this._logger.LogWarning($"Error creating user account: {error.Description}");
                }

                return this.Page();
            }
        }
    }
}