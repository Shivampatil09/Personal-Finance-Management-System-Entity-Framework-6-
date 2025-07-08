using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Finance_Model.MasterModel;
using Personal_Finance_Repository.MasterRepo;

namespace Personal_Finance__Mangmentr_MVC.Controllers
{
    public class IncomeSourceController : Controller
    {
        IncomeSourceRepo repo = new IncomeSourceRepo();
        // GET: IncomeSource
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IncomeSourceView()
        {
            return View();
        }
        public ActionResult SaveOrUpdate(income_sourceModel model)
        {
            repo.SaveOrUpdate(model);
            return RedirectToAction("IncomeSourceView");
        }
        public ActionResult Report()
        {
            return View(repo.Report());
        }

        public ActionResult Edit(int id)
        {
            return View("IncomeSourceView", repo.Edit(id));
        }

        public ActionResult Delete(int id)
        {
            repo.delete(id);
            return RedirectToAction("Report");
        }
    }
}