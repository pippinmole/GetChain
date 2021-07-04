using System.Threading.Tasks;
using System.Web;
using GetChain.Core.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class SignupVerification : PageModel {
        private readonly ILogger<SignupVerification> _logger;
        private readonly IAppUserManager _userManager;

        public SignupVerification(ILogger<SignupVerification> logger, IAppUserManager userManager) {
            _logger = logger;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> OnGetAsync(string token, string email) {

            if ( !this.ModelState.IsValid ) {
                this._logger.LogWarning("Model state is not valid");
                return this.Page();
            }

            var user = await this._userManager.GetUserByEmailAsync(email);
            if ( user == null ) return this.Redirect("/");

            var result = await this._userManager.ConfirmEmailAsync(user, HttpUtility.UrlDecode(token));

            if ( !result.Succeeded ) {
                foreach ( var error in result.Errors ) {
                    this._logger.LogWarning(error.Code + " : " + error.Description);
                    this.ModelState.AddModelError(error.Code, error.Description);
                }

                return this.Page();
            }

            await this._userManager.SignInAsync(user, true);

            return this.Page();
        }
    }
}