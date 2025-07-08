using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Personal_Finance_Model.MasterModel
{
    public class AccountModel
    {
        public int account_id { get; set; }

        [Required(ErrorMessage = "User ID is required")]
        public Nullable<int> user_id { get; set; }

        [Required(ErrorMessage = "Account Type is required")]
        public string account_type { get; set; }

        [Required(ErrorMessage = "Balance is required")]
        public Nullable<decimal> balance { get; set; }

        [Required(ErrorMessage = "Liabilities is required")]
        public Nullable<decimal> liabilities { get; set; }
    }
}
