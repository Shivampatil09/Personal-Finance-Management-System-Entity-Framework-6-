using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Finance_Model.MasterModel;
using Personal_Finance_Repository.MasterRepo;

namespace Personal_Finance__Mangmentr_MVC.Controllers
{
    public class BudgetController : Controller
    {
        BudgetRepo repo = new BudgetRepo();
        // GET: Budget
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult BudgetView()
        {
            return View();
        }

        public ActionResult saveOrUpdate(budgetModel model)
        {
            repo.SaveOrUpdate(model);
            return RedirectToAction("BudgetView");
        }
        public ActionResult Report()
        {
            return View(repo.Report());
        }
        public ActionResult Edit(int id)
        {
            return View("BudgetView", repo.Edit(id));
        }
        public ActionResult Delete(int id)
        {
            repo.delete(id);
            return RedirectToAction("Report");
        }
    }
}