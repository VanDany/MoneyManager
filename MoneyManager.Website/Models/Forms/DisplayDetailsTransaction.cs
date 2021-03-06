using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Models.Forms
{
    public class DisplayDetailsTransaction
    {
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        [DisplayName("Description : ")]
        public string Description { get; set; }
        [DisplayName("Dépense ? ")]
        public bool ExpenseOrIncome { get; set; }
        [DisplayName("Montant : ")]
        public double Amount { get; set; }
        public int CategoryId { get; set; }
    }
}
