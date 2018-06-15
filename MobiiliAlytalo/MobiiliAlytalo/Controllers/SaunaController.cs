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
    public class SaunaController : Controller
    {
        private AlytaloEntities db = new AlytaloEntities();

        // GET: Sauna
        public ActionResult Index()
        {
            List<SaunaViewModel> model = new List<SaunaViewModel>();
            AlytaloEntities entities = new AlytaloEntities();
            try
            {
                List<Sauna> sauna = entities.Sauna.OrderByDescending(Sauna => Sauna.SaunaID).ToList();
                foreach (Sauna sau in sauna)
                {
                    SaunaViewModel sa = new SaunaViewModel();
                    sa.SaunaID = sau.SaunaID;
                    sa.SaunaNimi = sau.SaunaNimi;
                    sa.SaunaNykyLampotila = sau.SaunaNykyLampotila;
                    sa.SaunaOFF = sau.SaunaOFF;
                    sa.SaunaON = sau.SaunaON;
                    model.Add(sa);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        // GET: Sauna/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Sauna/Create
        public ActionResult Create()
        {
            AlytaloEntities db = new AlytaloEntities();
            SaunaViewModel model = new SaunaViewModel();

            return View(model);
        }

        // POST: Sauna/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SaunaViewModel model)
        {
            Sauna sa = new Sauna();
            sa.SaunaID = model.SaunaID;
            sa.SaunaNimi = model.SaunaNimi;
            db.Sauna.Add(sa);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {
                
            }
            return RedirectToAction("Index");
        }

        // GET: Sauna/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sau = db.Sauna.Find(id);
            if (sau == null)
            {
                return HttpNotFound();
            }
            SaunaViewModel sa = new SaunaViewModel();
            sa.SaunaID = sau.SaunaID;
            sa.SaunaNimi = sau.SaunaNimi;
            sa.SaunaNykyLampotila = sau.SaunaNykyLampotila;
            sa.SaunaOFF = sau.SaunaOFF;
            sa.SaunaON = sau.SaunaON;

            return View(sa);
        }

        // POST: Sauna/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Edit(SaunaViewModel model )
        {
            Sauna sa = db.Sauna.Find(model.SaunaID);
            sa.SaunaNimi = model.SaunaNimi;
            sa.SaunaNykyLampotila = model.SaunaNykyLampotila;
            sa.SaunaOFF = model.SaunaOFF;
            sa.SaunaON = model.SaunaON;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: Sauna/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Sauna sauna = db.Sauna.Find(id);
            if (sauna == null)
            {
                return HttpNotFound();
            }
            return View(sauna);
            
        }

        // POST: Sauna/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Sauna sauna = db.Sauna.Find(id);
            db.Sauna.Remove(sauna);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
