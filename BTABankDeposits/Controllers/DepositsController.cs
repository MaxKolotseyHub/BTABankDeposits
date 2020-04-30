using AutoMapper;
using BTABankDeposits.Db;
using BTABankDeposits.Helpers;
using BTABankDeposits.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BTABankDeposits.Controllers
{
    public class DepositsController : Controller
    {
        private readonly Mapper mapper = AutomapperConfig.GetMapper();
        private MyDbContext db;
        public DepositsController()
        {
            db = new MyDbContext();
        }
        ~DepositsController()
        {
            db = null;
        }
        // GET: Deposits
        public ActionResult Index()
        {
            ViewBag.Deposits = db.Deposits.Where(x=>x.IsHandled).ToList();

            return View(mapper.Map<List<ClientsListViewModel>>(db.Clients.Where(x => x.ClientId != "111111").ToList()));
        }
        [HttpGet]
        public ActionResult CreateDeposit(int id)
        {
            ViewBag.DepositTypes = db.DepositTypes.ToList();
            ViewBag.Currencies = db.Currencies.ToList();
            ViewBag.Client = mapper.Map<ClientDetailsViewModel>(db.Clients.FirstOrDefault(x => x.Id == id));

            return View();
        }
        [HttpGet]
        public ActionResult Deposits(int id)
        {
            var tmp = db.Deposits.Where(x => x.IsHandled & x.ClientId == id).ToList();
            var deposits = mapper.Map<List<DepositListViewModel>>(tmp);
            return View(deposits);
        }
        [HttpGet]
        public ActionResult Interrupt(int id)
        {
            var tmp = db.Deposits.FirstOrDefault(x => x.Id== id);
            tmp.IsInterrupted = true;
            tmp.CurrentState = "В обработке";
            db.Entry(tmp).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Deposits", new { id = id});
        }
        [HttpPost]
        public ActionResult CreateDeposit(Deposit deposit)
        {
            var client = db.Clients.FirstOrDefault(x => x.Id == deposit.ClientId);
            if (client != null)
            {
                deposit.Client = client;
            }

            var depositType = db.DepositTypes.FirstOrDefault(x => x.Id == deposit.DepositTypeId);
            if (depositType != null)
            {
                deposit.DepositType = depositType;
            }

            var currency = db.Currencies.FirstOrDefault(x => x.Id == deposit.CurrencyId);
            if (currency != null)
            {
                deposit.Currency = currency;
            }
            deposit.IsHandled = false;
            db.Deposits.Add(deposit);
            db.SaveChanges();

            return RedirectToAction("Index");
        }

    }
}