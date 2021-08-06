using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Models.Forms
{
    public class EditAccountForm
    {
        [HiddenInput]
        public int Id { get; set; } 

        [StringLength(50)]
        [DisplayName("Nom du compte ")]
        public string Description { get; set; }
    }
}
