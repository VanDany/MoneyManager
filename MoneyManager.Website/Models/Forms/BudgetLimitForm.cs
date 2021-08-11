using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace MoneyManager.Website.Models.Forms
{
    public class BudgetLimitForm
    {
        public int CategoryId { get; set; }
        [DisplayName("Nom de la catégorie")]
        public string CategoryName { get; set; }
        [DisplayName("Dépenses actuelles")]
        public double? Sum { get; set; }
        [DisplayName("Limite autorisée")]
        public double? Max { get; set; }
        [DisplayName("Dépenses actuelles")]
        public double? Diff { get { return Sum*-1; } }
        [DisplayName("Reste")]
        public double? Reste { get { return Math.Round((double)(Max - Diff), 2); } }
        [DisplayName("Pourcentage")]
        public double? Pourcentage { get { return Math.Round((double)(Diff/Max) * 100,0); } }
    }
}
