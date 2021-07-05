using EthScanNet.Lib;
using Microsoft.Extensions.Configuration;

namespace CryptAPI.Controllers {
    public class KovanController : GenericChainController {
        public KovanController(IConfiguration configuration) : base(EScanNetwork.KovanNet, configuration.GetSection("ApiKeys:KovanKey").Value) { }
    }
}