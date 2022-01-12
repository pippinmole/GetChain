using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;

namespace GetChain.Core.User.API_Usage {
    public class IApiUsageStore {
        private readonly ILogger<IApiUsageStore> _logger;
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly List<ApiUsage> _buffer = new();

        public IApiUsageStore(ILogger<IApiUsageStore> logger, UserManager<ApplicationUser> userManager) {
            _logger = logger;
            _userManager = userManager;
        }

        public void Add(ApiUsage usage) {
            _buffer.Add(usage);
        }
    }
}