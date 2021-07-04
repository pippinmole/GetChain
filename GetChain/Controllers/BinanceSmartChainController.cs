using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using BscScanner;
using BscScanner.Data;
using GetChain.Attributes;
using GetChain.Core.User;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace CryptAPI.Controllers {
    /// <inheritdoc />
    [ApiController]
    [Route("api/v1/bsc")]
    public class BinanceSmartChainController : Controller {
        private readonly ILogger<BinanceSmartChainController> _logger;
        private readonly IBscScanClient _bscProvider;
        private readonly IAppUserManager _userManager;

        /// <inheritdoc />
        public BinanceSmartChainController(ILogger<BinanceSmartChainController> logger, IBscScanClient bscProvider,
            IAppUserManager userManager) {
            _logger = logger;
            _bscProvider = bscProvider;
            _userManager = userManager;
        }

        #region Account

        [JwtAuthorize]
        [HttpGet("bnbbalance/{address}")]
        public async Task<IActionResult> GetBnbBalance(string address) {
            var bnbBalance = await _bscProvider.GetBnbBalanceSingleAsync(address);
            return Json(bnbBalance);
        }
        
        [JwtAuthorize]
        [HttpGet("bnbbalances/{addresses}")]
        public async Task<IActionResult> GetBnbBalances(IEnumerable<string> addresses) {
            var bnbBalance = await _bscProvider.GetBnbBalanceMultipleAsync(addresses);
            return Json(bnbBalance);
        }
        
        [JwtAuthorize]
        [HttpGet("transactionsbyaddress/{address}")]
        public async Task<IActionResult> GetTransactionsFor(string address) {
            var bnbBalance = await _bscProvider.GetTransactionsByAddress(address);
            return Json(bnbBalance);
        }
        
        [JwtAuthorize]
        [HttpGet("transactionsbyhash/{address}")]
        public async Task<IActionResult> GetTransactionsByHash(string hash) {
            var bnbBalance = await _bscProvider.GetTransactionsByHash(hash);
            return Json(bnbBalance);
        }
        
        [JwtAuthorize]
        [HttpGet("transactionsbyblockrange/{start}/{end}")]
        public async Task<IActionResult> GetTransactionsByBlockRange(int start, int end) {
            var bnbBalance = await _bscProvider.GetTransactionsByBlockRange(start, end);
            return Json(bnbBalance);
        }
        
        [JwtAuthorize]
        [HttpGet("bep20transfersbyaddress/{address}")]
        public async Task<IActionResult> GetBep20TransfersByAddress(string address) {
            var bnbBalance = await _bscProvider.GetBep20TokenTransfersByAddress(address);
            return Json(bnbBalance);
        }
        
        [JwtAuthorize]
        [HttpGet("erc721transfersbyaddress/{address}")]
        public async Task<IActionResult> GetErc721TransfersByAddress(string address) {
            var bnbBalance = await _bscProvider.GetErc721TokenTransfersByAddress(address);
            return Json(bnbBalance);
        }
        
        [JwtAuthorize]
        [HttpGet("blocksvalidatedbyaddress/{address}")]
        public async Task<IActionResult> GetBlocksValidatedByAddress(string address) {
            var bnbBalance = await _bscProvider.GetBlocksValidatedByAddress(address);
            return Json(bnbBalance);
        }
        
        #endregion

        #region Contracts

        [JwtAuthorize]
        [HttpGet("abifromaddress/{address}")]
        public async Task<IActionResult> GetAbiFromSourceAddress(string address) {
            var bnbBalance = await _bscProvider.GetAbiFromSourceAddress(address);
            return Json(bnbBalance);
        }
        
        [JwtAuthorize]
        [HttpGet("sourcecodefromaddress/{address}")]
        public async Task<IActionResult> GetSourceCodeFromSourceAddress(string address) {
            var bnbBalance = await _bscProvider.GetSourceCodeFromSourceAddress(address);
            return Json(bnbBalance);
        }

        #endregion

        #region Transaction

        [JwtAuthorize]
        [HttpGet("transactionstatus/{txHash}")]
        public async Task<IActionResult> GetTransactionReceiptStatus(string txHash) {
            var bnbBalance = await _bscProvider.GetTransactionReceiptStatus(txHash);
            return Json(bnbBalance);
        }

        #endregion

        #region Blocks
        
        [JwtAuthorize]
        [HttpGet("blockreward/{block}")]
        public async Task<IActionResult> GetBlockRewardByBlock(int block) {
            var bnbBalance = await _bscProvider.GetBlockRewardByBlock(block);
            return Json(bnbBalance);
        }
        
        [JwtAuthorize]
        [HttpGet("blockcoundown/{block}")]
        public async Task<IActionResult> GetBlockCountdownByBlock(int block) {
            var bnbBalance = await _bscProvider.GetBlockCountdownByBlock(block);
            return Json(bnbBalance);
        }
        
        // [JwtAuthorize]
        // [HttpGet("blocknumberbytimestamp/{time}")]
        // public async Task<IActionResult> GetBlockNumberByTimestamp(DateTime time) {
        //     var bnbBalance = await _bscProvider.GetBlockNumberByTimestamp(time);
        //     return Json(bnbBalance);
        // }
        //
        // [JwtAuthorize]
        // [HttpGet("blockreward/{time}")]
        // public async Task<IActionResult> GetBlockNumberByTimestamp(string block) {
        //     var bnbBalance = await _bscProvider.GetBlockRewardByBlock(block);
        //     return Json(bnbBalance);
        // }
        //
        // [JwtAuthorize]
        // [HttpGet("blockreward/{block}")]
        // public async Task<IActionResult> GetLatestBlock() {
        //     var bnbBalance = await _bscProvider.GetLatestBlock();
        //     return Json(bnbBalance);
        // }
        //
        // Task<int> GetBlockNumberByTimestamp(DateTime time);
        // Task<int> GetBlockNumberByTimestamp(long unixTime);
        //
        // #endregion
        //
        // #region Token
        //
        // Task<double> GetTokenTotalSupply(string address);
        // Task<double> GetTokenCirculatingSupply(string address);
        // Task<double> GetAccountBalanceByContractAddress(string contractAddress, string accountAddress);
        //
        // #endregion
        //
        // #region Stats
        //
        // Task<double> GetBnbTotalSupply();
        // Task<IEnumerable<BscValidator>> GetBscValidators();
        // Task<BscBnbPrice> GetBnbLastPrice();

        #endregion
    }
}