using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;
using Personal_Finance_Model.MasterModel;

namespace Personal_Finance_Repository.MasterRepo
{
    public class TransactionRepo
    {
        public int SaveOrUpdate(transactionModel model)
        {
            int serverResponce = 0;
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                if (model.transaction_id == 0)
                {
                    transaction bg = new transaction()
                    {
                        transaction_id = model.transaction_id,
                        account_id = model.account_id,
                        type = model.type,
                        amount = model.amount,
                        statement = model.statement,
                        time = model.time,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    serverResponce = 1;
                }
                else
                {
                    transaction bg = new transaction()
                    {
                        transaction_id = model.transaction_id,
                        account_id = model.account_id,
                        type = model.type,
                        amount = model.amount,
                        statement = model.statement,
                        time = model.time,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    serverResponce = 2;
                }
            }
            return serverResponce;
        }

        public List<transaction> Report()
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var report = (from x in db.transactions select x).ToList();
                return report;
            }
        }

        public void delete(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.transactions where x.transaction_id == id select x).FirstOrDefault();
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public transactionModel Edit(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.transactions
                            where x.transaction_id == id
                            select new transactionModel
                            {
                                transaction_id = x.transaction_id,
                                account_id = x.account_id,
                                type = x.type,
                                amount = x.amount,
                                statement = x.statement,
                                time = x.time,
                            }).FirstOrDefault();
                return data;
            }
        }
    }
}
