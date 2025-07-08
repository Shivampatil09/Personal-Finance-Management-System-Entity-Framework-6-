using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;

namespace Personal_Finance_Model.MasterModel
{
    public class expensModel
    {
        public int expense_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> account_id { get; set; }
        public Nullable<System.DateTime> expense_date { get; set; }
        public string expence_category { get; set; }
        public string remark { get; set; }
        public Nullable<decimal> ammount { get; set; }

        public virtual account account { get; set; }
        public virtual user user { get; set; }
    }
}
