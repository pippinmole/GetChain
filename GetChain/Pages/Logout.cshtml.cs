using System.Threading.Tasks;
using GetChain.Core.User;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class LogoutModel : PageModel {
        private readonly ILogger<LogoutModel> _logger;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public LogoutModel(ILogger<LogoutModel> logger, SignInManager<ApplicationUser> signInManager) {
            _logger = logger;
            _signInManager = signInManager;
        }
        
        public async Task<IActionResult> OnGetAsync() {
            this._logger.LogInformation($"Signout request");
            
            if ( this.User != null ) {
                this._logger.LogInformation($"Signout request from {this.User.GetDisplayName()}");
                await this._signInManager.SignOutAsync();
            }

            return this.RedirectToPage("/Index");
        }
    }
}