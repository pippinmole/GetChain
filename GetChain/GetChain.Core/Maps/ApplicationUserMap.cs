using AutoMapper;
using GetChain.Core.User;

namespace GetChain.Core.Maps {
    public class ApplicationUserMap : Profile {
        
        public ApplicationUserMap() {
            this.CreateMap<ApplicationUser, SafeApplicationUser>();
        }
    }
}