using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Client.Data
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public double? BudgetLimit { get; set; }

        public Category(string name)
        {
            Name = name;
        }
        public Category(string name, double? budgetLimit)
        {
            Name = name;
            BudgetLimit = budgetLimit;
        }

        internal Category(int id, string name, double? budgetLimit)
            : this(name, budgetLimit)
        {
            Id = id;
        }
    }
}
