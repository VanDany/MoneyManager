using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Models.Forms
{
    public class DisplayTransaction
    {
        public int Id { get; set; }
        public int UserAccountId { get; set; }
        [DisplayName("Compte")]
        public string AccountName { get; set; }
        [DisplayName("Date")]
        public DateTime DateTransact { get; set; }
        public string Description { get; set; }
        public bool ExpenseOrIncome { get; set; }
        [DisplayName("Montant")]
        public double Amount { get; set; }
        public int CategoryId { get; set; }
        [DisplayName("Catégorie")]
        public string Name { get; set; }
    }
}
