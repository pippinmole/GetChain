using EthScanNet.Lib;
using Microsoft.Extensions.Configuration;

namespace CryptAPI.Controllers {
    public class RopstenController : GenericChainController {
        public RopstenController(IConfiguration configuration) : base(EScanNetwork.RopstenNet, configuration.GetSection("ApiKeys:RopstenKey").Value) { }
    }
}