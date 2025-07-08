using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;
using Personal_Finance_Model.MasterModel;

namespace Personal_Finance_Repository.MasterRepo
{
    public class IncomeSourceRepo
    {
        public int SaveOrUpdate(income_sourceModel model)
        {
            int serverResponce = 0;
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                if (model.source_id == 0)
                {
                    income_source bg = new income_source()
                    {
                        source_id = model.source_id,
                        user_id = model.user_id,
                        source_name = model.source_name,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    serverResponce = 1;
                }
                else
                {
                    income_source bg = new income_source()
                    {
                        source_id = model.source_id,
                        user_id = model.user_id,
                        source_name = model.source_name,
                    };
                    db.Entry(bg).State = System.Data.Entity.EntityState.Modified;
                    db.SaveChanges();
                    serverResponce = 2;
                }
            }
            return serverResponce;
        }

        public List<income_source> Report()
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var report = (from x in db.income_source select x).ToList();
                return report;
            }
        }

        public void delete(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.income_source where x.source_id == id select x).FirstOrDefault();
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public income_sourceModel Edit(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.income_source
                            where x.source_id == id
                            select new income_sourceModel
                            {
                                source_id = x.source_id,
                                user_id = x.user_id,
                                source_name = x.source_name,
                            }).FirstOrDefault();
                return data;
            }
        }
    }
}
