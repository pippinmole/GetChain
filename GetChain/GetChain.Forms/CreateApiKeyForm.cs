using System.ComponentModel.DataAnnotations;
using GetChain.Attributes;

namespace GetChain.Forms {
    public class CreateApiKeyForm {
        
        [Required, MaxLength(15), UnicodeOnly]
        public string ApiKeyName { get; set; }
        
    }
}