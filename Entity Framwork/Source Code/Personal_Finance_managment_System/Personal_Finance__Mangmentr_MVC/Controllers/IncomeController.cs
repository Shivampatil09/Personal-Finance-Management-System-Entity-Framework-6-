using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Finance_Model.MasterModel;
using Personal_Finance_Repository.MasterRepo;

namespace Personal_Finance__Mangmentr_MVC.Controllers
{
    public class IncomeController : Controller
    {
        IncomeRepo repo = new IncomeRepo();
        // GET: Income
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult IncomeView()
        {
            return View();
        }
        public ActionResult SaveOrUpdate(incomeModel model)
        {
            repo.SaveOrUpdate(model);
            return RedirectToAction("IncomeView");
        }
        public ActionResult Report()
        {
            return View(repo.Report());
        }

        public ActionResult Edit(int id)
        {
            return View("IncomeView", repo.Edit(id));
        }

        public ActionResult Delete(int id)
        {
            repo.delete(id);
            return RedirectToAction("Report");
        }
    }
}