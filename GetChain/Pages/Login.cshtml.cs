using System.Linq;
using System.Threading.Tasks;
using GetChain.Core.User;
using GetChain.Forms;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class LoginModel : PageModel {
        private readonly ILogger<LoginModel> _logger;
        private readonly IAppUserManager _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        [BindProperty] public LoginForm LoginForm { get; set; }

        public LoginModel(ILogger<LoginModel> logger, IAppUserManager userManager, SignInManager<ApplicationUser> signInManager) {
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }
        
        public async Task<IActionResult> OnPost() {
            if ( !this.ModelState.IsValid ) {
                foreach ( var error in ViewData.ModelState.Values.SelectMany(modelState => modelState.Errors) ) {
                    _logger.LogWarning(error.ErrorMessage);
                }

                return this.Page();
            }

            this._logger.LogInformation($"Login attempt for {this.LoginForm.Username}");

            var result = await this._signInManager.PasswordSignInAsync(this.LoginForm.Username, this.LoginForm.Password,
                this.LoginForm.RememberMe, false);

            if ( result.Succeeded ) {
                return this.RedirectToPage("/Dashboard");
            } else {
                this._logger.LogWarning("Login attempt failed");
                this.ModelState.AddModelError("", "Login failed. Please check the credentials and try again.");
                
                return this.Page();
            }
        }
    }
}