using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Finance_Model.MasterModel;
using Personal_Finance_Repository.MasterRepo;

namespace Personal_Finance__Mangmentr_MVC.Controllers
{
    public class ExpenseCategoryController : Controller
    {
        ExpenseCategoryRepo repo = new ExpenseCategoryRepo();
        // GET: ExpenseCategory
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExpenseCategoryView()
        {
            return View();
        }
        public ActionResult saveOrUpdate(expense_categoryModel model)
        {
            repo.saveOrUpdate(model);
            return RedirectToAction("ExpenseCategoryView");
        }
        public ActionResult Report()
        {
            return View(repo.Report());
        }

        public ActionResult Edit(int id)
        {
            return View("ExpenseCategoryView", repo.Edit(id));
        }

        public ActionResult Delete(int id)
        {
            repo.delete(id);
            return RedirectToAction("Report");
        }
    }
}