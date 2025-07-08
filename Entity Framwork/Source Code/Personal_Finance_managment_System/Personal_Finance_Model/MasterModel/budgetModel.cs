using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Model.MasterModel
{
    public class budgetModel
    {
        public int budget_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string expense_category { get; set; }
        public Nullable<decimal> amount { get; set; }
    }
}
