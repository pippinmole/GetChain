using System;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GetChain.Core.User {
    public interface IAppUserManager {
        Task<SafeApplicationUser> GetSafeUserAsync(ClaimsPrincipal principal);
        Task<SafeApplicationUser> GetSafeUserByIdAsync(string id);
        Task<SafeApplicationUser> GetSafeUserByIdAsync(Guid id);

        Task<ApplicationUser> GetUserAsync(ClaimsPrincipal principal);
        Task<ApplicationUser> GetUserByIdAsync(string id);
        Task<ApplicationUser> GetUserByIdAsync(Guid id);
        Task<IdentityResult> UpdateUserAsync(ApplicationUser user);
        Task<ApplicationUser> GetUserByEmailAsync(string email);
        Task<IdentityResult> RemoveUserAsync(ApplicationUser user);
        Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user);
        Task<string> GenerateEmailConfirmTokenAsync(ApplicationUser user);
        Task SignOutAsync();
        Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string password);
        Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role);
        Task<bool> IsUserInRole(ApplicationUser user, string role);
        Task<IdentityResult> CreateAsync(ApplicationUser newAccount, string password);
        Task SignInAsync(ApplicationUser newAccount, bool isPersistent);
        Task<IdentityResult> AddNewApiToken(ApplicationUser user, string name, DateTime expiryDate);
        Task<IdentityResult> ConfirmEmailAsync(ApplicationUser user, string token);
    }
}