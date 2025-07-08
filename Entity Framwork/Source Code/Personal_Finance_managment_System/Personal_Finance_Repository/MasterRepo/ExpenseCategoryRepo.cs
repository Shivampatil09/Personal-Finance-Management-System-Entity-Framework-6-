using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Personal_Finanace_Context;
using Personal_Finance_Model.MasterModel;

namespace Personal_Finance_Repository.MasterRepo
{
    public class ExpenseCategoryRepo
    {
        public int saveOrUpdate(expense_categoryModel model)
        {
            int serverresponce = 0;
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                if (model.category_id == 0)
                {
                    expense_category ec = new expense_category()
                    {
                        user_id = model.user_id,
                        category_name = model.category_name,
                    };
                    db.Entry(ec).State = System.Data.Entity.EntityState.Added;
                    db.SaveChanges();
                    serverresponce = 1;
                }
                else
                {
                    var existing = db.expense_category.FirstOrDefault(x => x.category_id == model.category_id);
                    if (existing != null)
                    {
                        existing.user_id = model.user_id;
                        existing.category_name = model.category_name;

                        db.SaveChanges();
                        serverresponce = 2;
                    }
                }
            }
            return serverresponce;
        }

        public List<expense_category> Report()
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var report = (from x in db.expense_category select x).ToList();
                return report;
            }
        }

        public void delete(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.expense_category where x.category_id == id select x).FirstOrDefault();
                db.Entry(data).State = System.Data.Entity.EntityState.Deleted;
                db.SaveChanges();
            }
        }

        public expense_categoryModel Edit(int id)
        {
            using (Personal_Finance_Management_SystemEntities db = new Personal_Finance_Management_SystemEntities())
            {
                var data = (from x in db.expense_category
                            where x.category_id == id
                            select new expense_categoryModel
                            {
                                category_id = x.category_id,
                                user_id = x.user_id,
                                category_name = x.category_name,
                            }).FirstOrDefault();
                return data;
            }
        }
    }
}
