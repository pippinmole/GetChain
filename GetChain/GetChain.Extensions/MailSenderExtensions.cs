using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web;
using GetChain.MailService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace GetChain.GetChain.Extensions {
    public static class MailSenderExtensions {

        public static async Task SendPasswordReset(this IMailSender sender, string email, string resetToken,
            PageModel context) {
            var callback = context.Url.Page("passwordreset", new {
                token = HttpUtility.UrlEncode(resetToken),
                email = email
            });

            await sender.SendEmailAsync(
                new List<string>() {
                    email
                },
                "Password reset",
                $"{context.Request.Scheme}://{context.Request.Host}{callback}",
                null
            );
        }
    }
}