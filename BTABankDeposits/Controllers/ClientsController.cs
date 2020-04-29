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
        private MyDbContext db;
        public ClientsController()
        {
            db = new MyDbContext();
        }
        ~ClientsController()
        {
            db = null;
        }
        public ActionResult Index()
        {
            return View(mapper.Map<List<ClientsListViewModel>>(db.Clients.ToList()));
        }
        [HttpGet]
        public ActionResult Create()
        {
            ViewBag.Cities = db.Cities.ToList();
            return View();
        }
        [HttpPost]
        public ActionResult Create(Client client)
        {
            if (!ModelState.IsValid)
            {
                return View("Create", client);
            }

            if (db.Cities.FirstOrDefault(c => c.Name.Equals(client.LivingCity)) == null)
            {
                db.Cities.Add(new City() { Name = client.LivingCity });
                db.SaveChanges();
            }
            if (db.Cities.FirstOrDefault(c => c.Name.Equals(client.RegistrationCity)) == null)
            {
                db.Cities.Add(new City() { Name = client.RegistrationCity });
                db.SaveChanges();
            }
            while (true)
            {
                var clientId = new Random().Next(111111, 999999);

                if (db.Clients.FirstOrDefault(x => x.ClientId == clientId.ToString()) == null)
                {
                    client.ClientId = clientId.ToString();
                    break;
                }
            }
            db.Clients.Add(client);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            Client client = null;
            if ((client = db.Clients.FirstOrDefault(x => x.Id == id)) != null)
            {
                db.Clients.Remove(client);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        public ActionResult Details(int id)
        {
            return View(mapper.Map<ClientDetailsViewModel>(db.Clients.FirstOrDefault(x => x.Id == id)));
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            return View(db.Clients.FirstOrDefault(x=>x.Id==id));
        }
        [HttpPost]
        public ActionResult Edit(Client client)
        {
            db.Entry(client).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}