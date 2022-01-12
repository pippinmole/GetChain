using System;

namespace GetChain.Core.User {
    public class ApiUsage {
        
        public DateTime Time { get; }

        public ApiUsage(DateTime time) {
            Time = time;
        }
        
    }
}