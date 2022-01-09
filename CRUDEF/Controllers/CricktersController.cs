using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CRUDEF;

namespace CRUDEF.Controllers
{
    public class CricktersController : Controller
    {
        private CrudEFEntities db = new CrudEFEntities();

        // GET: Crickters
        public ActionResult Index()
        {
            return View(db.Crickters.ToList());
        }

        // GET: Crickters/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crickter crickter = db.Crickters.Find(id);
            if (crickter == null)
            {
                return HttpNotFound();
            }
            return View(crickter);
        }

        // GET: Crickters/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Crickters/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Cid,Cname,Caddress,Cgender")] Crickter crickter)
        {
            if (ModelState.IsValid)
            {
                db.Crickters.Add(crickter);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(crickter);
        }

        // GET: Crickters/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crickter crickter = db.Crickters.Find(id);
            if (crickter == null)
            {
                return HttpNotFound();
            }
            return View(crickter);
        }

        // POST: Crickters/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Cid,Cname,Caddress,Cgender")] Crickter crickter)
        {
            if (ModelState.IsValid)
            {
                db.Entry(crickter).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(crickter);
        }

        // GET: Crickters/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Crickter crickter = db.Crickters.Find(id);
            if (crickter == null)
            {
                return HttpNotFound();
            }
            return View(crickter);
        }

        // POST: Crickters/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Crickter crickter = db.Crickters.Find(id);
            db.Crickters.Remove(crickter);
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
