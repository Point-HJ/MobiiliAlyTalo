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
        private AlytaloEntities db = new AlytaloEntities();
        // GET: Valo
        public ActionResult Index()
        {
            List<ValoViewModel> model = new List<ValoViewModel>();
            AlytaloEntities entities = new AlytaloEntities();
            try
            {
                List<Valot> valo = entities.Valot.OrderByDescending(Valo => Valo.ValoID).ToList();
                foreach (Valot val in valo)
                {
                    ValoViewModel va = new ValoViewModel();
                    va.ValoID = val.ValoID;
                    va.ValoONOFF = val.ValoONOFF;
                    va.Valo33 = val.Valo33;
                    va.Valo66 = val.Valo66;
                    va.Valo100 = val.Valo100;
                    va.ValoAikaLeimaONOFF = val.ValoAikaLeimaONOFF;
                    va.ValoAikaLeima33 = val.ValoAikaLeima33;
                    va.ValoAikaLeima66 = val.ValoAikaLeima66;
                    va.ValoAikaLeima100 = val.ValoAikaLeima100;
                    va.ValaisinNimi = val.ValaisinNimi;
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
            AlytaloEntities db = new AlytaloEntities();
            ValoViewModel model = new ValoViewModel();

            return View(model);
        }

        // POST: Valo/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ValoViewModel model)
        {
            Valot va = new Valot();
            va.ValoID = model.ValoID;
            va.ValaisinNimi = model.ValaisinNimi;
            db.Valot.Add(va);
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
            Valot val = db.Valot.Find(id);
            if (val == null)
            {
                return HttpNotFound();
            }
            ValoViewModel va = new ValoViewModel();
            va.ValoID = val.ValoID;
            //va.ValoONOFF = val.ValoONOFF;
            //va.Valo33 = val.Valo33;
            //va.Valo66 = val.Valo66;
            //va.Valo100 = val.Valo100;
            va.ValaisinNimi = val.ValaisinNimi;
            //va.ValoAikaLeima33 = val.ValoAikaLeima33;
            //va.ValoAikaLeima66 = val.ValoAikaLeima66;
            //va.ValoAikaLeima100 = val.ValoAikaLeima100;
            //va.ValoAikaLeimaONOFF = val.ValoAikaLeimaONOFF;

            return View(va);
        }

        // POST: Valo/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ValoViewModel model)
        {
            Valot va = db.Valot.Find(model.ValoID);
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
            Valot valo = db.Valot.Find(id);
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
            Valot valo = db.Valot.Find(id);
            db.Valot.Remove(valo);
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

        public ActionResult ValoONOFF(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot val = db.Valot.Find(id);
            if (val == null)
            {
                return HttpNotFound();
            }
            ValoViewModel va = new ValoViewModel();
            va.ValoID = val.ValoID;
            va.ValoONOFF = true;
            va.Valo33 = false;
            va.Valo66 = false;
            va.Valo100 = false;
            va.ValaisinNimi = val.ValaisinNimi;
            //va.ValoAikaLeima33 = val.ValoAikaLeima33;
            //va.ValoAikaLeima66 = val.ValoAikaLeima66;
            //va.ValoAikaLeima100 = val.ValoAikaLeima100;
            va.ValoAikaLeimaONOFF = val.ValoAikaLeimaONOFF;
            return View(va);
        }
        //POST: Valo/ValoONOFF
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ValoONOFF(ValoViewModel model)
        {
            Valot va = db.Valot.Find(model.ValoID);
            va.ValoONOFF = true;
            va.Valo33 = false;
            va.Valo66 = false;
            va.Valo100 = false;
            va.ValaisinNimi = model.ValaisinNimi;
            //va.ValoAikaLeima33 = DateTime.Now;
            //va.ValoAikaLeima66 = DateTime.Now;
            //va.ValoAikaLeima100 = DateTime.Now;
            va.ValoAikaLeimaONOFF = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //GET: Valo/Valo33
        public ActionResult Valo33(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot val = db.Valot.Find(id);
            if (val == null)
            {
                return HttpNotFound();
            }
            ValoViewModel va = new ValoViewModel();
            va.ValoID = val.ValoID;
            va.ValoONOFF = false;
            va.Valo33 = true;
            va.Valo66 = false;
            va.Valo100 = false;
            va.ValaisinNimi = val.ValaisinNimi;
            va.ValoAikaLeima33 = val.ValoAikaLeima33;
            //va.ValoAikaLeima66 = val.ValoAikaLeima66;
            //va.ValoAikaLeima100 = val.ValoAikaLeima100;
            //va.ValoAikaLeimaONOFF = val.ValoAikaLeimaONOFF;
            return View(va);
        }
        //POST: Valo/Valo33
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Valo33(ValoViewModel model)
        {
            Valot va = db.Valot.Find(model.ValoID);
            va.ValoONOFF = false;
            va.Valo33 = true;
            va.Valo66 = false;
            va.Valo100 = false;
            va.ValaisinNimi = model.ValaisinNimi;
            va.ValoAikaLeima33 = DateTime.Now;
            //va.ValoAikaLeima66 = DateTime.Now;
            //va.ValoAikaLeima100 = DateTime.Now;
            //va.ValoAikaLeimaONOFF = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }
    
    //GET: Valo/Valo66
    
    public ActionResult Valo66(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Valot val = db.Valot.Find(id);
        if (val == null)
        {
            return HttpNotFound();
        }
        ValoViewModel va = new ValoViewModel();
        va.ValoID = val.ValoID;
        va.ValoONOFF = false;
        va.Valo33 = false;
        va.Valo66 = true;
        va.Valo100 = false;
        va.ValaisinNimi = val.ValaisinNimi;
        //va.ValoAikaLeima33 = val.ValoAikaLeima33;
        va.ValoAikaLeima66 = val.ValoAikaLeima66;
        //va.ValoAikaLeima100 = val.ValoAikaLeima100;
        //va.ValoAikaLeimaONOFF = val.ValoAikaLeimaONOFF;
        return View(va);
    }
    //POST: Valo/Valo66
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Valo66(ValoViewModel model)
    {
        Valot va = db.Valot.Find(model.ValoID);
        va.ValoONOFF = false;
        va.Valo33 = false;
        va.Valo66 = true;
        va.Valo100 = false;
        va.ValaisinNimi = model.ValaisinNimi;
        //va.ValoAikaLeima33 = DateTime.Now;
        va.ValoAikaLeima66 = DateTime.Now;
        //va.ValoAikaLeima100 = DateTime.Now;
        //va.ValoAikaLeimaONOFF = DateTime.Now;
        db.SaveChanges();
        return RedirectToAction("Index");
    }
    //GET: Valo/Valo100
   
    public ActionResult Valo100(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Valot val = db.Valot.Find(id);
            if (val == null)
            {
                return HttpNotFound();
            }
            ValoViewModel va = new ValoViewModel();
            va.ValoID = val.ValoID;
            va.ValoONOFF = false;
            va.Valo33 = false;
            va.Valo66 = false;
            va.Valo100 = true;
            va.ValaisinNimi = val.ValaisinNimi;
            //va.ValoAikaLeima33 = val.ValoAikaLeima33;
            //va.ValoAikaLeima66 = val.ValoAikaLeima66;
            va.ValoAikaLeima100 = val.ValoAikaLeima100;
            //va.ValoAikaLeimaONOFF = val.ValoAikaLeimaONOFF;
            return View(va);
        }
        //POST: Valo/Valo100
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Valo100(ValoViewModel model)
        {
            Valot va = db.Valot.Find(model.ValoID);
            va.ValoONOFF = false;
            va.Valo33 = false;
            va.Valo66 = false;
            va.Valo100 = true;
            va.ValaisinNimi = model.ValaisinNimi;
            //va.ValoAikaLeima33 = DateTime.Now;
            //va.ValoAikaLeima66 = DateTime.Now;
            va.ValoAikaLeima100 = DateTime.Now;
            //va.ValoAikaLeimaONOFF = DateTime.Now;
            db.SaveChanges();
            return RedirectToAction("Index");
        }


    }
}
