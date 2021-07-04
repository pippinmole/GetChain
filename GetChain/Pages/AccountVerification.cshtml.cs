using System;
using System.Threading.Tasks;
using GetChain.Core.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class AccountVerificationModel : PageModel {
        private readonly ILogger<AccountVerificationModel> _logger;
        private readonly IAppUserManager _userManager;

        public AccountVerificationModel(ILogger<AccountVerificationModel> logger, IAppUserManager userManager) {
            _logger = logger;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> OnGetAsync() {
            var user = await this._userManager.GetUserByIdAsync(this.User.GetUniqueId());
            if ( user == null ) {
                return this.Redirect("/");
            }

            return this.Page();
        }

        public async Task<JsonResult> OnGetIsEmailVerified() {
            var user = await this._userManager.GetUserByIdAsync(this.User.GetUniqueId());
            if ( user == null ) {
                return new JsonResult("");
            }
            
            return new JsonResult(new {
                isVerified = user.EmailConfirmed
            });
        }
    }
}