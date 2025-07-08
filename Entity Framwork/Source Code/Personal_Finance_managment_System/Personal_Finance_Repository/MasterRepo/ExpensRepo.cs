using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;
using Personal_Finance_Model.MasterModel;

namespace Personal_Finance_Repository.MasterRepo
{
    public class ExpensRepo
    {
        public int saveOrUpdate(expensModel model)
        {
            int surverresponce = 0;
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                if (model.expense_id == 0)
                {
                    expens ex = new expens()
                    {
                        user_id = model.user_id,
                        account_id = model.account_id,
                        expense_date = model.expense_date,
                        expence_category = model.expence_category,
                        remark = model.remark,
                        ammount = model.ammount,
                    };
                    db.Entry(ex).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    surverresponce = 1;
                }
                else
                {
                    var existing = db.expenses.FirstOrDefault(x => x.expense_id == model.expense_id);
                    if (existing != null)
                    {
                        existing.user_id = model.user_id;
                        existing.account_id = model.account_id;
                        existing.expense_date = model.expense_date;
                        existing.expence_category = model.expence_category;
                        existing.remark = model.remark;
                        existing.ammount = model.ammount;

                        db.SaveChanges();
                        surverresponce = 2;
                    }
                }
            }
            return surverresponce;
        }

        public List<expens> Report()
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var report = (from x in db.expenses select x).ToList();
                return report;
            }
        }

        public void delete(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.expenses where x.expense_id == id select x).FirstOrDefault();
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public expensModel Edit(int id)
        {
            using(Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.expenses where x.expense_id == id
                            select new expensModel
                            {
                                expense_id = x.expense_id,
                                user_id = x.user_id,
                                account_id = x.account_id,
                                expense_date = x.expense_date,
                                expence_category = x.expence_category,
                                remark = x.remark,
                                ammount = x.ammount,
                            }).FirstOrDefault();
                return data;
            }
        }
    }
}
