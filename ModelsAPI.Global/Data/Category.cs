using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelsAPI.Global.Data
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double? BudgetLimit { get; set; }
        public int UserId { get; set; }
    }
}
