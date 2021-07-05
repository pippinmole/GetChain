using EthScanNet.Lib;
using Microsoft.Extensions.Configuration;

namespace CryptAPI.Controllers {
    public class RinkebyController : GenericChainController {
        public RinkebyController(IConfiguration configuration) : base(EScanNetwork.RinkebyNet, configuration.GetSection("ApiKeys:RinkebyKey").Value) { }
    }
}