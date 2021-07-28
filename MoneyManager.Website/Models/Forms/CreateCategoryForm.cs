using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Models.Forms
{
    public class CreateCategoryForm
    {
        [Required]
        [StringLength(50)]
        [DisplayName("Nom : ")]
        public string Name { get; set; }
        
        [DisplayName("Budget limite (optionnel) : ")]
        public double? BudgetLimit { get; set; }
    }
}
