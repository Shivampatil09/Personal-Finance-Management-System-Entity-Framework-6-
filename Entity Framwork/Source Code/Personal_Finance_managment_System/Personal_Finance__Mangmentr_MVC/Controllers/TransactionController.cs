using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Finance_Model.MasterModel;
using Personal_Finance_Repository.MasterRepo;

namespace Personal_Finance__Mangmentr_MVC.Controllers
{
    public class TransactionController : Controller
    {
        TransactionRepo repo = new TransactionRepo();
        // GET: TransactionRepo
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult TransactionView()
        {
            return View();
        }
        public ActionResult SaveOrUpdate(transactionModel model)
        {
            repo.SaveOrUpdate(model);
            return RedirectToAction("TransactionView");
        }
        public ActionResult Report()
        {
            return View(repo.Report());
        }

        public ActionResult Edit(int id)
        {
            return View("TransactionView", repo.Edit(id));
        }

        public ActionResult Delete(int id)
        {
            repo.delete(id);
            return RedirectToAction("Report");
        }
    }
}