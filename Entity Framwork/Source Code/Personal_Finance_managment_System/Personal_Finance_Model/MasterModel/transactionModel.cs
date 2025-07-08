using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;

namespace Personal_Finance_Model.MasterModel
{
    public class transactionModel
    {
        public int transaction_id { get; set; }
        public Nullable<int> account_id { get; set; }
        public string type { get; set; }
        public Nullable<decimal> amount { get; set; }
        public string statement { get; set; }
        public Nullable<System.DateTime> time { get; set; }
    }
}
