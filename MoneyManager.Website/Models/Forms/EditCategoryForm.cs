using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Models.Forms
{
    public class EditCategoryForm
    {
        [HiddenInput]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        [DisplayName("Nom : ")]
        public string Name { get; set; }
        [Range(1, 10000, ErrorMessage = "Le budget limite doit être un nombre entre 1 et 10000")]
        [DisplayName("Budget limite (optionnel) : ")]
        public double? BudgetLimit { get; set; }
    }
}
