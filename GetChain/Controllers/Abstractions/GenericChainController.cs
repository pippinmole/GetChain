using System.Threading.Tasks;
using EthScanNet.Lib;
using EthScanNet.Lib.Models.ApiResponses.Accounts;
using EthScanNet.Lib.Models.ApiResponses.Stats;
using EthScanNet.Lib.Models.ApiResponses.Tokens;
using EthScanNet.Lib.Models.EScan;
using GetChain.Attributes;
using Microsoft.AspNetCore.Mvc;

namespace CryptAPI.Controllers {
    [ApiController]
    [Route("api/v1/[controller]")]
    public abstract class GenericChainController {

        private readonly EScanClient _client;

        protected GenericChainController(EScanNetwork networkType, string apiKey) {
            _client = new EScanClient(networkType, apiKey);
        }

        #region Account
        
        [ApiUsage]
        [JwtAuthorize]
        [HttpGet("account/balance/{address}")]
        public async Task<EScanBalance> GetBalance(string address) {
            return await _client.Accounts.GetBalanceAsync(new EScanAddress(address));
        }

        [JwtAuthorize]
        [HttpGet("account/normaltransactions/{address}/{startBlock?}/{endBlock?}/{page?}/{offset?}")]
        public async Task<EScanTransactions> GetNormalTransactions(string address, ulong? startBlock = null,
            ulong? endBlock = null,
            int? page = null,
            int? offset = null) {
            return await _client.Accounts.GetNormalTransactionsAsync(new EScanAddress(address), startBlock,endBlock,page,offset);
        }
        
        [JwtAuthorize]
        [HttpGet("account/internaltransactions/{address}/{startBlock?}/{endBlock?}/{page?}/{offset?}")]
        public async Task<EScanTransactions> GetInternalTransactions(string address, 
            ulong? startBlock = null,
            ulong? endBlock = null,
            int? page = null,
            int? offset = null) {
            return await _client.Accounts.GetInternalTransactionsAsync(new EScanAddress(address), startBlock, endBlock,
                page, offset);
        }
        
        [JwtAuthorize]
        [HttpGet("account/minedblocks/{address}")]
        public async Task<EScanMinedBlocks> GetMinedBlocks(string address) {
            return await _client.Accounts.GetMinedBlocksAsync(new EScanAddress(address));
        }
        
        [JwtAuthorize]
        [HttpGet("account/gettokentransfers/{address}")]
        public async Task<EScanTokenTransferEvents> GetTokenTransfers(string address) {
            return await _client.Accounts.GetTokenEvents(new EScanAddress(address));
        }
        
        [JwtAuthorize]
        [HttpGet("account/gettokentransfers/{address}/{tokenAddress}")]
        public async Task<EScanTokenTransferEvents> GetTokenTransfers(string address, string tokenAddress) {
            return await _client.Accounts.GetTokenEvents(new EScanAddress(address), new EScanAddress(tokenAddress));
        }
        
        [JwtAuthorize]
        [HttpGet("account/gettokenbalance/{address}/{contractAddress}")]
        public async Task<EScanBalance> GetTokenBalance(string address, string contractAddress) {
            return await _client.Accounts.GetTokenBalanceForAddress(new EScanAddress(address), new EScanAddress(contractAddress));
        }
        
        #endregion

        #region Stats
        
        [JwtAuthorize]
        [HttpGet("stats/totalsupply")]
        public async Task<EScanTotalCoinSupply> GetTotalSupply(string address) {
            return await _client.Stats.GetTotalSupply();
        }
        
        #endregion

        #region 

        [JwtAuthorize]
        [HttpGet("token/getcirculatingsupply/{tokenAddress}")]
        public async Task<EScanTokenSupply> GetCirculatingSupply(string contractAddress) {
            return await _client.Tokens.GetCirculatingSupply(new EScanAddress(contractAddress));
        }
        
        [JwtAuthorize]
        [HttpGet("token/getmaxsupply/{tokenAddress}")]
        public async Task<EScanTokenSupply> GetMaxSupply(string contractAddress) {
            return await _client.Tokens.GetMaxSupply(new EScanAddress(contractAddress));
        }

        #endregion
    }
}