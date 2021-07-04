using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using GetChain.Core.User;
using GetChain.Forms;
using GetChain.MailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class SignupModel : PageModel {
        private readonly ILogger<SignupModel> _logger;
        private readonly IAppUserManager _userManager;
        private readonly IMailSender _mailSender;

        [BindProperty] public SignUpForm SignupForm { get; set; }

        public SignupModel(ILogger<SignupModel> logger, IAppUserManager userManager, IMailSender mailSender) {
            _logger = logger;
            _userManager = userManager;
            _mailSender = mailSender;
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

                var verifyToken = HttpUtility.UrlEncode(await this._userManager.GenerateEmailConfirmTokenAsync(user));
                var callback = this.Url.Page("SignupVerification", new {
                    token = verifyToken,
                    email = user.Email
                });
                
                await this._mailSender.SendEmailAsync(
                    new List<string>() {
                        user.Email
                    },
                    "Account verification",
                    $"{this.Request.Scheme}://{this.Request.Host}{this.Request.PathBase}{callback}",
                    null
                );
                
                return this.Redirect("/");
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