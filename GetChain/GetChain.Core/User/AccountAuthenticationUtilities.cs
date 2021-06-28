using System;
using System.Linq;
using System.Security.Claims;

namespace GetChain.Core.User {
    public static class AccountAuthenticationUtilities {

        public static Guid GetUniqueId(this ClaimsPrincipal principal) {
            var name = principal.FindFirst(ClaimTypes.NameIdentifier);
            return name == null ? Guid.Empty : new Guid(name.Value);
        }

        public static string GetDisplayName(this ClaimsPrincipal principal) {
            return principal.FindFirst(ClaimTypes.Name)?.Value;
        }

        public static bool IsAdminAccount(this ClaimsPrincipal principal) {
            var roles = principal.FindAll(ClaimTypes.Role);
            return roles.Any(x => x.Value == "Admin");
        }

        public static bool IsStandardAccount(this ClaimsPrincipal principal) {
            var roles = principal.FindAll(ClaimTypes.Role);
            return roles.Any(x => x.Value == "Standard");
        }

        public static bool IsLoggedIn(this ClaimsPrincipal principal) {
            return principal.Identity.IsAuthenticated;
        }
    }
}