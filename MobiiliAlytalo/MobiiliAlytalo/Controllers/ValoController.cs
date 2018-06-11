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
        private AlytaloEntities2 db = new AlytaloEntities2();
        // GET: Valo
        public ActionResult Index()
        {
            List<ValoViewModel> model = new List<ValoViewModel>();
            AlytaloEntities2 entities = new AlytaloEntities2();
            try
            {
                List<Valo> valo = entities.Valo.OrderByDescending(Valo => Valo.ValoID).ToList();
                foreach (Valo val in valo)
                {
                    ValoViewModel va = new ValoViewModel();
                    va.ValoID = va.ValoID;
                    va.ValoONOFF = va.ValoONOFF;
                    va.Valo33 = va.Valo33;
                    va.Valo66 = va.Valo66;
                    va.Valo100 = va.Valo100;
                    va.ValoAikaLeimaONOFF = va.ValoAikaLeimaONOFF;
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
            AlytaloEntities2 db = new AlytaloEntities2();
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
            Valo val = db.Valo.Find(id);
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
            Valo va = db.Valo.Find(model.ValoID);
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
            Valo val = db.Valo.Find(id);
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
            Valo va = db.Valo.Find(model.ValoID);
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
    //näkymän luonti: template:edit ja model class: Valot(Alytalo...)
    public ActionResult Valo66(int? id)
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
        Valo va = db.Valo.Find(model.ValoID);
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
    //näkymän luonti: template:edit ja model class: Valot(Alytalo...)
    public ActionResult Valo100(int? id)
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
            Valo va = db.Valo.Find(model.ValoID);
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
