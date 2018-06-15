using MobiiliAlytalo.Models;
using MobiiliAlytalo.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace MobiiliAlytalo.Controllers
{
    public class LämpotilaController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();
        // GET: Lämpotila
        public ActionResult Index()
        {
            List<LampotilaViewModel> model = new List<LampotilaViewModel>();
            AlytaloEntities entities = new AlytaloEntities();
            try
            {
                List<TaloLampotila> lampo = entities.TaloLampotila.OrderByDescending(Lampo => Lampo.LampotilaID).ToList();
                foreach (TaloLampotila lam in lampo)
                {
                    LampotilaViewModel la = new LampotilaViewModel();
                    la.LampotilaID = lam.LampotilaID;
                    la.Nykylampotila = lam.Nykylampotila;
                    la.TavoiteLampotila = lam.TavoiteLampotila;
                    model.Add(la);
                }
            }
            finally
            {
                entities.Dispose();
            }

            return View(model);
        }

        // GET: Lämpotila/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Lämpotila/Create
        public ActionResult Create()
        {
            AlytaloEntities db = new AlytaloEntities();
            LampotilaViewModel model = new LampotilaViewModel();

            return View(model);
        }

        // POST: Lämpotila/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(LampotilaViewModel model)
        {
            TaloLampotila lam = new TaloLampotila();
            lam.LampotilaID = model.LampotilaID;
            lam.Nykylampotila = model.Nykylampotila;
            lam.TavoiteLampotila = model.TavoiteLampotila;
            db.TaloLampotila.Add(lam);
            try
            {
                db.SaveChanges();
            }
            catch 
            {
               
            }
            return RedirectToAction("Index");
        }

        // GET: Lämpotila/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TaloLampotila lam = db.TaloLampotila.Find(id);
            if (lam == null)
            {
                return HttpNotFound();
            }
            LampotilaViewModel la = new LampotilaViewModel();
            la.LampotilaID = lam.LampotilaID;
            la.Nykylampotila = lam.Nykylampotila;
            la.TavoiteLampotila = lam.TavoiteLampotila;

            return View(la);
        }

        // POST: Lämpotila/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(LampotilaViewModel model)
        {
            TaloLampotila la = db.TaloLampotila.Find(model.LampotilaID);
            la.Nykylampotila = model.Nykylampotila;
            la.TavoiteLampotila = model.TavoiteLampotila;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Lämpotila/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Lämpotila/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
