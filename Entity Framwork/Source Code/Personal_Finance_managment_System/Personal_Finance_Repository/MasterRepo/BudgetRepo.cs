using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;
using Personal_Finance_Model.MasterModel;

namespace Personal_Finance_Repository.MasterRepo
{
    public class BudgetRepo
    {
        public int SaveOrUpdate(budgetModel model)
        {
            int serverResponce = 0;
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                if (model.budget_id == 0)
                {
                    budget bg = new budget()
                    {
                        budget_id = model.budget_id,
                        user_id = model.user_id,
                        expense_category = model.expense_category,
                        amount = model.amount,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    serverResponce = 1;
                }
                else
                {
                    budget bg = new budget()
                    {
                        budget_id = model.budget_id,
                        user_id = model.user_id,
                        expense_category = model.expense_category,
                        amount = model.amount,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    serverResponce = 2;
                }
            }
            return serverResponce;
        }

        public List<budget> Report()
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var report = (from x in db.budgets select x).ToList();
                return report;
            }
        }

        public void delete(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.budgets where x.budget_id == id select x).FirstOrDefault();
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public budgetModel Edit(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.budgets where x.budget_id == id select new budgetModel
                {
                    budget_id = x.budget_id,
                    user_id = x.user_id,
                    expense_category = x.expense_category,
                    amount = x.amount,
                }).FirstOrDefault();
                return data;
            }
        }
    }
}
