using System;
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

        public async Task<IActionResult> OnPostDeleteApiKey(string key) {
            var user = await _userManager.GetUserByIdAsync(this.User.GetUniqueId());
            
            user.ApiKeys.RemoveAll(x => x.Key == key);

            await _userManager.UpdateUserAsync(user);

            return this.Page();
        }
    }
}