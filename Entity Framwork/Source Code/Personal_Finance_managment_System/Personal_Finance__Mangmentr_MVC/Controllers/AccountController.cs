using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Personal_Finance_Model.MasterModel;
using Personal_Finance_Repository.MasterRepo;

namespace Personal_Finance__Mangmentr_MVC.Controllers
{
    public class AccountController : Controller
    {
        AccountRepo repo = new AccountRepo();
        // GET: Account
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult AccountViwe()
        {
            return View();
        }
        public ActionResult saveOrUpdate(AccountModel model)
        {
            repo.saveOrUpdate(model);
            return RedirectToAction("AccountViwe");
        }
        public ActionResult Report()
        {
            return View(repo.Report());
        }

        public ActionResult Edit(int id)
        {
            return View("AccountViwe", repo.Edit(id));
        }

        public ActionResult Delete(int id)
        {
            repo.delete(id);
            return RedirectToAction("Report");
        }
    }
}