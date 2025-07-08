using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;
using Personal_Finance_Model.MasterModel;

namespace Personal_Finance_Repository.MasterRepo
{
    public class IncomeRepo
    {
        public int SaveOrUpdate(incomeModel model)
        {
            int serverResponce = 0;
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                if (model.income_id == 0)
                {
                    income bg = new income()
                    {
                        income_id = model.income_id,
                        user_id = model.user_id,
                        account_id = model.account_id,
                        income_date = model.income_date,
                        income_source = model.income_source,
                        amount = model.amount,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    serverResponce = 1;
                }
                else
                {
                    income bg = new income()
                    {
                        income_id = model.income_id,
                        user_id = model.user_id,
                        account_id = model.account_id,
                        income_date = model.income_date,
                        income_source = model.income_source,
                        amount = model.amount,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    serverResponce = 2;
                }
            }
            return serverResponce;
        }

        public List<income> Report()
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var report = (from x in db.incomes select x).ToList();
                return report;
            }
        }

        public void delete(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.incomes where x.income_id == id select x).FirstOrDefault();
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public incomeModel Edit(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.incomes
                            where x.income_id == id
                            select new incomeModel
                            {
                                income_id = x.income_id,
                                user_id = x.user_id,
                                account_id = x.account_id,
                                income_date = x.income_date,
                                income_source = x.income_source,
                                amount = x.amount,
                            }).FirstOrDefault();
                return data;
            }
        }
    }
}
