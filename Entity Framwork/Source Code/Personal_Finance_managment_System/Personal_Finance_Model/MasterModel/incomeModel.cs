using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;

namespace Personal_Finance_Model.MasterModel
{
    public class incomeModel
    {
        public int income_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<int> account_id { get; set; }
        public Nullable<System.DateTime> income_date { get; set; }
        public string income_source { get; set; }
        public Nullable<decimal> amount { get; set; }
    }
}
