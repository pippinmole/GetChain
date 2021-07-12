using System.Linq;
using System.Threading.Tasks;
using System.Web;
using AspNetCoreHero.ToastNotification.Abstractions;
using GetChain.Core.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class PasswordResetModel : PageModel {
        private readonly ILogger<PasswordResetModel> _logger;
        private readonly IAppUserManager _userManager;
        private readonly INotyfService _notyfService;


        public PasswordResetModel(ILogger<PasswordResetModel> logger, IAppUserManager userManager, INotyfService notyfService) {
            _logger = logger;
            _userManager = userManager;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> OnPostAsync(string email, string token, string password) {
            if ( !this.ModelState.IsValid )
                return this.Page();

            var user = await _userManager.GetUserByEmailAsync(email);
            if ( user == null ) return this.Redirect("/");

            var result = await _userManager.ResetPasswordAsync(user, HttpUtility.UrlDecode(token), password);

            if ( result.Succeeded ) {
                _logger.LogInformation($"{user.UserName} has successfully changed their password");
                
                _notyfService.Success("You have successfully changed your password! You can now log in with your new credentials.");
            } else {
                var errors = "";
                foreach ( var error in result.Errors ) {
                    var flag = $"{error.Code}: {error.Description}";

                    errors += flag;
                    
                    _notyfService.Error(flag);
                }

                _logger.LogWarning($"{user.UserName} has unsuccessfully changed their password. {errors}");
            }

            return this.Redirect("/");
        }
    }
}