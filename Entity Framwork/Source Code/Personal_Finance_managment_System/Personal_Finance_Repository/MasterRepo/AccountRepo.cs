using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;
using Personal_Finance_Model.MasterModel;

namespace Personal_Finance_Repository.MasterRepo
{
    public class AccountRepo
    {
        public int saveOrUpdate(AccountModel model)
        {
            int serverresponce = 0;
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                if (model.account_id == 0)
                {
                    account ac = new account()
                    {
                        user_id = model.user_id,
                        account_type = model.account_type,
                        balance = model.balance,
                        liabilities = model.liabilities,
                    };
                    db.Entry(ac).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    serverresponce = 1;
                }
                else
                {
                    var existing = db.accounts.FirstOrDefault(x => x.account_id == model.account_id);
                    if (existing != null)
                    {
                        existing.user_id = model.user_id;
                        existing.account_type = model.account_type;
                        existing.balance = model.balance;
                        existing.liabilities = model.liabilities;
                        db.SaveChanges();
                        serverresponce = 2;
                    }
                }
            }
            return serverresponce;
        }

        public List<account> Report()
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var report = (from x in db.accounts select x).ToList();
                return report;
            }
        }

        public void delete(int id)
        {
            using(Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.accounts where x.account_id == id select x).FirstOrDefault();
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public AccountModel Edit(int id)
        {
            using(Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.accounts where x.account_id == id
                            select new AccountModel
                            {
                                account_id = x.account_id,
                                user_id = x.user_id,
                                account_type = x.account_type,
                                balance = x.balance,
                                liabilities = x.liabilities,
                            }).FirstOrDefault();
                return data;
            }
        }
    }
}
