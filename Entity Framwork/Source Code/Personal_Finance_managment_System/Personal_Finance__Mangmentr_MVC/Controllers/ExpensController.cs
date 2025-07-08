using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Finance_Model.MasterModel;
using Personal_Finance_Repository.MasterRepo;

namespace Personal_Finance__Mangmentr_MVC.Controllers
{
    public class ExpensController : Controller
    {
        ExpensRepo repo = new ExpensRepo();
        // GET: Expens
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ExpensView()
        {
            return View();
        }
        public ActionResult saveOrUpdate(expensModel model)
        {
            repo.saveOrUpdate(model);
            return RedirectToAction("ExpensView");
        }
        public ActionResult Report()
        {
            return View(repo.Report());
        }

        public ActionResult Edit(int id)
        {
            return View("ExpensView", repo.Edit(id));
        }

        public ActionResult Delete(int id)
        {
            repo.delete(id);
            return RedirectToAction("Report");
        }
    }
}