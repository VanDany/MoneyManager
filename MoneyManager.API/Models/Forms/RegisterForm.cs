using MoneyManager.API.Infrastructure.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Models.Forms
{
    public class RegisterForm
    {
        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
        [Required]
        [MaxLength(384)]
        [EmailAddress]
        [EmailExists]
        public string EmailAddress { get; set; }
        [Required]
        [MaxLength(20)]
        [RegularExpression(@"^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$ %^&*-=]).{8,20}$")]
        public string Password { get; set; }
    }
}
