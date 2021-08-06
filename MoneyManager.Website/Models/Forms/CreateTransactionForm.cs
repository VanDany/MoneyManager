using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Models.Forms
{
    public class CreateTransactionForm
    {
        public int UserAccountId { get; set; }
        [DisplayName("Description : ")]
        [StringLength(50)]
        public string Description { get; set; }
        [DisplayName("Expense ? ")]
        public bool ExpenseOrIncome { get; set; }
        [DisplayName("Amount: ")]
        [Range(1, 100000, ErrorMessage = "Le montant de la transaction doit être un nombre entre 1 et 100000")]
        public double Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
