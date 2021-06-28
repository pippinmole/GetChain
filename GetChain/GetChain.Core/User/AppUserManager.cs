using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using GetChain.GetChain.Core;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;

namespace GetChain.Core.User {
    public class AppUserManager : IAppUserManager {
        private readonly IConfiguration _configuration;
        private readonly ILogger<AppUserManager> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly IMapper _mapper;

        public AppUserManager(IConfiguration configuration, ILogger<AppUserManager> logger,
            UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,
            IMapper mapper) {
            this._configuration = configuration;
            this._logger = logger;
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._mapper = mapper;
        }

        public async Task<SafeApplicationUser> GetSafeUserAsync(ClaimsPrincipal principal) {
            var user = await this.GetUserAsync(principal);
            return this._mapper.Map<SafeApplicationUser>(user);
        }

        public async Task<SafeApplicationUser> GetSafeUserByIdAsync(string id) {
            var user = await this.GetUserByIdAsync(id);
            return this._mapper.Map<SafeApplicationUser>(user);
        }

        public async Task<SafeApplicationUser> GetSafeUserByIdAsync(Guid id) {
            var user = await this.GetUserByIdAsync(id);
            return this._mapper.Map<SafeApplicationUser>(user);
        }

        public async Task<ApplicationUser> GetUserAsync(ClaimsPrincipal principal) {
            return await this._userManager.GetUserAsync(principal);
        }
        
        public async Task<ApplicationUser> GetUserByIdAsync(string id) {
            if ( Guid.TryParse(id, out var guid) )
                return await this._userManager.FindByIdAsync(guid.ToString());
            else {
                this._logger.LogWarning("User Guid given is not in the correct format!");
                return null;
            }
        }
        
        public async Task<ApplicationUser> GetUserByIdAsync(Guid id) {
            return await this._userManager.FindByIdAsync(id.ToString());
        }

        public async Task<IdentityResult> UpdateUserAsync(ApplicationUser user) {
            return await this._userManager.UpdateAsync(user);
        }

        public async Task<IdentityResult> RemoveUserAsync(ApplicationUser user) {
            return await this._userManager.DeleteAsync(user);
        }

        public async Task<string> GeneratePasswordResetTokenAsync(ApplicationUser user) {
            return await this._userManager.GeneratePasswordResetTokenAsync(user);
        }

        public async Task<ApplicationUser> GetUserByEmailAsync(string email) {
            return await this._userManager.FindByEmailAsync(email);
        }

        public async Task SignOutAsync() {
            await this._signInManager.SignOutAsync();
        }

        public async Task<IdentityResult> ResetPasswordAsync(ApplicationUser user, string token, string password) {
            return await this._userManager.ResetPasswordAsync(user, token, password);
        }

        public async Task<IdentityResult> AddToRoleAsync(ApplicationUser user, string role) {
            return await this._userManager.AddToRoleAsync(user, role);
        }

        public async Task<bool> IsUserInRole(ApplicationUser user, string role) {
            return await this._userManager.IsInRoleAsync(user, role);
        }

        public async Task<IdentityResult> CreateAsync(ApplicationUser newAccount, string password) {
            return await this._userManager.CreateAsync(newAccount, password);
        }

        public async Task<IdentityResult> AddNewApiToken(ApplicationUser user, string name) {
            var securityKey = Encoding.UTF8.GetBytes(_configuration["Jwt:Secret"]);

            var claims = new[] {
                new Claim(ClaimTypes.Name, user.UserName),
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString())
            };
            var credentials =
                new SigningCredentials(new SymmetricSecurityKey(securityKey), SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(_configuration["Jwt:Issuer"],
                _configuration["Jwt:Issuer"],
                claims,
                expires: DateTime.Today,
                signingCredentials: credentials);

            var key = new ApiKey() {
                Name = name,
                Key = new JwtSecurityTokenHandler().WriteToken(token)
            };
            
            user.ApiKeys.Add(key);

            return await this._userManager.UpdateAsync(user);
        }

        public async Task SignInAsync(ApplicationUser newAccount, bool isPersistent) {
            await this._signInManager.SignInAsync(newAccount, isPersistent);
        }
    }
}