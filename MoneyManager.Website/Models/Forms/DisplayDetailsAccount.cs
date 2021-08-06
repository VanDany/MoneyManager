﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Models.Forms
{
    public class DisplayDetailsAccount
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        [ScaffoldColumn(false)]
        public int UserId { get; set; }

        [DisplayName("Nom du compte")]
        public string Description { get; set; }

    }
}
