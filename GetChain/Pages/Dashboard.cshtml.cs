using System;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using GetChain.Core.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class DashboardModel : PageModel {
        private readonly ILogger<DashboardModel> _logger;
        private readonly IAppUserManager _userManager;

        public DashboardModel(ILogger<DashboardModel> logger, IAppUserManager userManager) {
            _logger = logger;
            _userManager = userManager;
        }

        public async Task<IActionResult> OnGetAsync() {
            var user = await _userManager.GetUserByIdAsync(this.User.GetUniqueId());
            if ( user == null || !this.User.IsLoggedIn() ) {
                await _userManager.SignOutAsync();
                return this.Redirect("/");
            }

            if ( !user.EmailConfirmed ) return this.Redirect("/verify");

            return this.Page();
        }

        public async Task<IActionResult> OnPostDeleteApiKey(string key) {
            var user = await _userManager.GetUserByIdAsync(this.User.GetUniqueId());

            user.ApiKeys.RemoveAll(x => x.Key == key);

            await _userManager.UpdateUserAsync(user);

            return this.Page();
        }

        public async Task<IActionResult> OnPostChangeUsername(string newName) {
            var user = await _userManager.GetUserByIdAsync(this.User.GetUniqueId());
            if ( user == null ) return this.Redirect("/");

            _logger.LogWarning($"{user.UserName} is changing their username to {newName}");

            return this.Page();
        }

        public async Task<IActionResult> OnPostChangeEmail([EmailAddress] string newEmail) {
            if ( !this.ModelState.IsValid )
                return this.Page();

            var user = await _userManager.GetUserByIdAsync(this.User.GetUniqueId());
            if ( user == null ) return this.Redirect("/");

            _logger.LogWarning($"{user.UserName} is changing their email to {newEmail}");

            return this.Page();
        }
    }
}