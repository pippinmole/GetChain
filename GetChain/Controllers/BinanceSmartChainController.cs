using System;
using System.Threading.Tasks;
using BscScanner;
using GetChain.Core.User;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptAPI.Controllers {
    [ApiController]
    [Route("api/v1/bsc")]
    public class BinanceSmartChainController : Controller {
        private readonly ILogger<BinanceSmartChainController> _logger;
        private readonly IBscScanClient _bscProvider;
        private readonly IAppUserManager _userManager;

        public BinanceSmartChainController(ILogger<BinanceSmartChainController> logger, IBscScanClient bscProvider,
            IAppUserManager userManager) {
            _logger = logger;
            _bscProvider = bscProvider;
            _userManager = userManager;
        }

        [Authorize]
        [ValidateAntiForgeryToken]
        [HttpGet("account/transactions/{address}")]
        public async Task<IActionResult> GetAccount(string address) {
            var user = await this._userManager.GetUserByIdAsync(this.User.GetUniqueId());
            if ( user == null )
                return this.BadRequest("Bad Token");
            
            var txnHistory = await _bscProvider.GetTransactionsByAddress(address);
            return Json(txnHistory);
        }

        [Authorize]
        [HttpGet("account/bnb/{address}")]
        public async Task<IActionResult> GetAccountBnbTotal(string address) {
            var bnbWorth = await _bscProvider.GetBnbBalanceSingleAsync(address);
            
            //*0.000000000000000001
            
            return Json(bnbWorth);
        }
    }
}