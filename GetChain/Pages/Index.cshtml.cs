using GetChain.Core.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace GetChain.Pages {
    public class IndexModel : PageModel {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger) {
            _logger = logger;
        }

        public IActionResult OnGet() {
            if ( this.User.IsLoggedIn() ) {
                return this.RedirectToPage("/Dashboard");
            }

            return this.Page();
        }
    }
}