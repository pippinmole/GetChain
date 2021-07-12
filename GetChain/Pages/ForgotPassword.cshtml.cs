using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;
using System.Web;
using AspNetCoreHero.ToastNotification.Abstractions;
using GetChain.Attributes;
using GetChain.Core.User;
using GetChain.GetChain.Extensions;
using GetChain.MailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class ForgotPasswordModel : PageModel {
        private readonly ILogger<ForgotPasswordModel> _logger;
        private readonly IAppUserManager _userManager;
        private readonly IMailSender _mailSender;
        private readonly INotyfService _notyfService;

        public ForgotPasswordModel(ILogger<ForgotPasswordModel> logger, IAppUserManager userManager,
            IMailSender mailSender, INotyfService notyfService) {
            _logger = logger;
            _userManager = userManager;
            _mailSender = mailSender;
            _notyfService = notyfService;
        }

        public async Task<IActionResult> OnPost(
            [Required, DataType(DataType.EmailAddress), UnicodeOnly]
            string email) {
            if ( !this.ModelState.IsValid ) return this.Page();

            _logger.LogInformation($"User with email {email} is attempting a password reset.");

            var user = await _userManager.GetUserByEmailAsync(email);
            if ( user != null ) {
                var token = await _userManager.GeneratePasswordResetTokenAsync(user);

                await _mailSender.SendPasswordReset(email, token, this);
            }

            _notyfService.Success("Successfully sent reset password. Check your inbox.");

            return this.Redirect("login");
        }
    }
}