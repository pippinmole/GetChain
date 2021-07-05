using EthScanNet.Lib;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;

namespace CryptAPI.Controllers {
    public class GoerliController : GenericChainController {
        
        public GoerliController(IConfiguration configuration) : base(EScanNetwork.GoerliNet, configuration.GetSection("ApiKeys:GoerliKey").Value) { }
        
    }
}