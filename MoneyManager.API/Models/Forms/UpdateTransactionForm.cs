using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.API.Models.Forms
{
    public class UpdateTransactionForm
    {
        [Required]
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        public string Description { get; set; }
        public bool ExpenseOrIncome { get; set; }
        [Required]
        [Range(1, 10000, ErrorMessage = "Value must be between 1 to 10000")]
        public double Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
