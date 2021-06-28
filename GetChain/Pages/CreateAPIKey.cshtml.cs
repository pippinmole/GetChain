using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Threading.Tasks;
using Csg.ApiKeyGenerator;
using GetChain.Core.User;
using GetChain.Forms;
using GetChain.GetChain.Core;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class CreateApiKeyModel : PageModel {
        private readonly ILogger<CreateApiKeyModel> _logger;
        private readonly IAppUserManager _userManager;

        [BindProperty] public CreateApiKeyForm CreateKeyForm { get; set; }

        public CreateApiKeyModel(ILogger<CreateApiKeyModel> logger, IAppUserManager userManager) {
            _logger = logger;
            _userManager = userManager;
        }
        
        public async Task<IActionResult> OnPost() {
            if ( !this.ModelState.IsValid )
                return this.Page();
            
            var user = await _userManager.GetUserByIdAsync(this.User.GetUniqueId());
            
            this._logger.LogInformation($"Creating API key for project: {this.CreateKeyForm.ApiKeyName}");

            await _userManager.AddNewApiToken(user, this.CreateKeyForm.ApiKeyName);

            return this.RedirectToPage("/Dashboard");
        }
        
    }
}