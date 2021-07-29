using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Client.Data
{
    public class Category
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public double? BudgetLimit { get; set; }
        public int UserId { get; set; }
        public Category(string name, int userId)
        {
            Name = name;
            UserId = userId;
        }
        public Category(string name, double? budgetLimit, int userId)
        {
            Name = name;
            BudgetLimit = budgetLimit;
            UserId = userId;
        }

        internal Category(int id, string name, double? budgetLimit, int userId)
            : this(name, budgetLimit, userId)
        {
            Id = id;
        }
    }
}
