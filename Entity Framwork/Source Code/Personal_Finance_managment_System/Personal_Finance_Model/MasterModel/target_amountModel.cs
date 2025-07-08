using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;

namespace Personal_Finance_Model.MasterModel
{
    public class target_amountModel
    {
        public int target_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public Nullable<decimal> amount { get; set; }
    }
}
