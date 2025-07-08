using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;
using Personal_Finance_Model.MasterModel;

namespace Personal_Finance_Repository.MasterRepo
{
    public class TargetAmountRepo
    {
        public int SaveOrUpdate(target_amountModel model)
        {
            int serverResponce = 0;
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                if (model.target_id == 0)
                {
                    target_amount bg = new target_amount()
                    {
                        target_id = model.target_id,
                        user_id = model.user_id,
                        amount = model.amount,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    serverResponce = 1;
                }
                else
                {
                    target_amount bg = new target_amount()
                    {
                        target_id = model.target_id,
                        user_id = model.user_id,
                        amount = model.amount,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    serverResponce = 2;
                }
            }
            return serverResponce;
        }

        public List<target_amount> Report()
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var report = (from x in db.target_amount select x).ToList();
                return report;
            }
        }

        public void delete(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.target_amount where x.target_id == id select x).FirstOrDefault();
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public target_amountModel Edit(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.target_amount
                            where x.target_id == id
                            select new target_amountModel
                            {
                                target_id = x.target_id,
                                user_id = x.user_id,
                                amount = x.amount,
                            }).FirstOrDefault();
                return data;
            }
        }
    }
}
