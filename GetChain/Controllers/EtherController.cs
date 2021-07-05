using EthScanNet.Lib;
using Microsoft.Extensions.Configuration;

namespace CryptAPI.Controllers {
    public class EtherController : GenericChainController {
        
        public EtherController(IConfiguration configuration) : base(EScanNetwork.MainNet, configuration.GetSection("ApiKeys:EtherScanKey").Value) { }
        
    }
}