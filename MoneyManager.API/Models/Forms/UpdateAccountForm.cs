using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Models.Forms
{
    public class UpdateAccountForm
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        [Required]
        public string Description { get; set; }
    }
}
