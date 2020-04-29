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
            return View(mapper.Map<List<ClientsListViewModel>>(db.Clients.ToList()));
        }
        public ActionResult CreateDeposit(int id)
        {
            ViewBag.DepositTypes = db.DepositTypes.ToList();
            ViewBag.Currencies = db.Currencies.ToList();
            ViewBag.Client = mapper.Map<ClientDetailsViewModel>( db.Clients.FirstOrDefault(x=>x.Id==id));
            
            return View();
        }
    }
}