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
    public class ClientsController : Controller
    {
        // GET: Clients
        private readonly Mapper mapper = AutomapperConfig.GetMapper();

        public ActionResult Index()
        {
            List<ClientsListViewModel> Clients = new List<ClientsListViewModel>();
            using(MyDbContext db = new MyDbContext())
            {
               Clients =  mapper.Map<List<ClientsListViewModel>>(db.Cliens.ToList());
            }
            return View(Clients);
        }
        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", client);
            }

            using(MyDbContext db = new MyDbContext())
            {
                db.Cliens.Add(client);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}