using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Models.Forms
{
    public class DisplayDetailsCategory
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        
        [DisplayName("Nom")]
        public string Name { get; set; }
        
        [DisplayName("Limite budget")]
        public double? BudgetLimit { get; set; }
    }
}
