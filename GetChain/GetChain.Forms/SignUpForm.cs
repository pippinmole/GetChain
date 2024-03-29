﻿using System.ComponentModel.DataAnnotations;
using GetChain.Attributes;

namespace GetChain.Forms {
    public class SignUpForm {
        [Required, MaxLength(15), UnicodeOnly]
        public string Username { get; set; }
            
        [Required, DataType(DataType.EmailAddress), UnicodeOnly]
        public string Email { get; set; }
            
        [Required, StringLength(32), DataType(DataType.Password), UnicodeOnly]
        public string Password { get; set; }
    }
}