//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Personal_Finanace_Context
{
    using System;
    using System.Collections.Generic;
    
    public partial class expense_category
    {
        public int category_id { get; set; }
        public Nullable<int> user_id { get; set; }
        public string category_name { get; set; }
    
        public virtual user user { get; set; }
    }
}
