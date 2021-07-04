using System;
using System.ComponentModel.DataAnnotations;
using GetChain.Attributes;

namespace GetChain.Forms {
    public class CreateApiKeyForm {
        
        [Required, MaxLength(15), UnicodeOnly]
        public string ApiKeyName { get; set; }
        
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-ddTHH:mm}", ApplyFormatInEditMode = true), DataType(DataType.Date)]
        public DateTime Expiry { get; set; }
        
    }
}