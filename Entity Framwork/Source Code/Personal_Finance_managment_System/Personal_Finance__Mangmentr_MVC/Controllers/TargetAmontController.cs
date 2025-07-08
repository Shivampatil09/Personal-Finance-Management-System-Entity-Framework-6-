using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Finance_Model.MasterModel;
using Personal_Finance_Repository.MasterRepo;

namespace Personal_Finance__Mangmentr_MVC.Controllers
{
    public class TargetAmontController : Controller
    {
        TargetAmountRepo repo = new TargetAmountRepo();
        // GET: TargetAmont
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TargetAmountView()
        {
            return View();
        }
        public ActionResult SaveOrUpdate(target_amountModel model)
        {
            repo.SaveOrUpdate(model);
            return RedirectToAction("TargetAmountView");
        }
        public ActionResult Report()
        {
            return View(repo.Report());
        }

        public ActionResult Edit(int id)
        {
            return View("TargetAmountView", repo.Edit(id));
        }

        public ActionResult Delete(int id)
        {
            repo.delete(id);
            return RedirectToAction("Report");
        }
    }
}