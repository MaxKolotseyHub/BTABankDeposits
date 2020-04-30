using BTABankDeposits.Db;
using BTABankDeposits.Filters;
using BTABankDeposits.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTABankDeposits.Controllers
{
    [MyAuthAttribute]
    public class EndOfDayController : Controller
    {
        // GET: EndOfDay
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult End()
        {
            IEndOfBankDay eod;
            using (MyDbContext db = new MyDbContext())
            {
                eod = new BankEOD(db);
                eod.HandleNewDeposits();
                eod.CountDepositPercents();
                db.SaveChanges();
            }
            return RedirectToAction("Index", "Deposits");
        }
    }
}