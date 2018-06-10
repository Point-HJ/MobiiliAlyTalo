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
    public class ValoController : Controller
    {
        private AlytaloEntities1 db = new AlytaloEntities1();
        // GET: Valo
        public ActionResult Index()
        {
            List<ValoViewModel> model = new List<ValoViewModel>();
            AlytaloEntities1 entities = new AlytaloEntities1();
            try
            {
                List<Valo> valo = entities.Valo.OrderByDescending(Valo => Valo.ValoID).ToList();
                foreach (Valo val in valo)
                {
                    ValoViewModel va = new ValoViewModel();
                    va.ValoID = va.ValoID;
                    va.ValoOFF = va.ValoOFF;
                    va.Valo33 = va.Valo33;
                    va.Valo66 = va.Valo66;
                    va.Valo100 = va.Valo100;
                    va.ValoAikaLeima33 = va.ValoAikaLeima33;
                    va.ValoAikaLeima66 = va.ValoAikaLeima66;
                    va.ValoAikaLeima100 = va.ValoAikaLeima100;
                    va.ValaisinNimi = va.ValaisinNimi;
                    model.Add(va);
                }
            }
            finally
            {
                entities.Dispose();
            }
            return View(model);
        }

        // GET: Valo/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Valo/Create
        public ActionResult Create()
        {
            AlytaloEntities1 db = new AlytaloEntities1();
            ValoViewModel model = new ValoViewModel();

            return View(model);
        }

        // POST: Valo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ValoViewModel model)
        {
            Valo va = new Valo();
            va.ValoID = model.ValoID;
            va.ValaisinNimi = model.ValaisinNimi;
            db.Valo.Add(va);
            try
            {
                db.SaveChanges();
            }
            catch (Exception ex)
            {

            }

            return RedirectToAction("Index");
        }

        // GET: Valo/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valo val = db.Valo.Find(id);
            if (val == null)
            {
                return HttpNotFound();
            }
            ValoViewModel va = new ValoViewModel();
            va.ValoID = val.ValoID;
            //va.ValoOFF = val.ValoOFF;
            //va.Valot33 = val.Valot33;
            //va.Valot66 = val.Valot66;
            //va.Valot100 = val.Valot100;
            va.ValaisinNimi = val.ValaisinNimi;
            //va.ValoTime33 = val.ValoTime33;
            //va.ValoTime66 = val.ValoTime66;
            //va.ValoTime100 = val.ValoTime100;


            return View(va);
        }

        // POST: Valo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ValoViewModel model)
        {
            Valo va = db.Valo.Find(model.ValoID);
            va.ValaisinNimi = model.ValaisinNimi;
            db.SaveChanges();
            return RedirectToAction("Index");

        }

        // GET: Valo/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valo valo = db.Valo.Find(id);
            if (valo == null)
            {
                return HttpNotFound();
            }
            return View(valo);
        }
        // POST: Valo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Valo valo = db.Valo.Find(id);
            db.Valo.Remove(valo);
            db.SaveChanges();
            return RedirectToAction("Index");
        }



    }
}
