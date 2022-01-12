using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using GetChain.Attributes;
using GetChain.Core.User;
using GetChain.GetChain.Extensions;
using GetChain.MailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class DashboardModel : PageModel {
        private readonly ILogger<DashboardModel> _logger;
        private readonly IAppUserManager _userManager;
        private readonly IMailSender _mailSender;
        
        public DashboardModel(ILogger<DashboardModel> logger, IAppUserManager userManager, IMailSender mailSender) {
            _logger = logger;
            _userManager = userManager;
            _mailSender = mailSender;
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

        public async Task<IActionResult> OnPostChangeUsername([MaxLength(15), MinLength(10)] string username) {
            if ( !this.ModelState.IsValid )
                return this.Page();
                
            var user = await _userManager.GetUserByIdAsync(this.User.GetUniqueId());
            if ( user == null ) return this.Redirect("/");

            user.UserName = username;
            
            await _userManager.UpdateUserAsync(user);
            
            _logger.LogWarning($"{user.UserName} is changing their username to {username}");

            return this.Page();
        }
        
        public async Task<IActionResult> OnPostChangePassword() {
            if ( !this.ModelState.IsValid )
                return this.Page();
                
            var user = await _userManager.GetUserByIdAsync(this.User.GetUniqueId());
            if ( user == null ) return this.Redirect("/");

            var resetToken = await this._userManager.GeneratePasswordResetTokenAsync(user);
            await _mailSender.SendPasswordReset(user.Email, resetToken, this);
            
            _logger.LogInformation($"{user.UserName} has requested a password change.");
            
            return this.Page();
        }
    }
}