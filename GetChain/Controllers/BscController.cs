using System.Net.Http;
using System.Numerics;
using EthScanNet.Lib;
using EthScanNet.Lib.Models.ApiResponses.Accounts;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CryptAPI.Controllers {
    public class BscController : GenericChainController {

        public BscController(IConfiguration configuration) 
            : base(EScanNetwork.BscMainNet, configuration.GetSection("ApiKeys:BscScanKey").Value) {
        }
        
    }
}