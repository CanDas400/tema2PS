using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MvcTemaPs.Models;

namespace MvcTemaPs.Controllers
{
     [Authorize(Roles="Admin")]
    public class AdminController : Controller
    {
        private TeatruDBContext db = new TeatruDBContext();

        // GET: /Admin/
        public ActionResult Index()
        {
            return View(db.Spectacols.ToList());
        }

        // GET: /Admin/Details/5
        public ActionResult Details(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spectacol spectacol = db.Spectacols.Find(id);
            if (spectacol == null)
            {
                return HttpNotFound();
            }
            return View(spectacol);
        }

        // GET: /Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: /Admin/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="SpectacolId,distributia,regia,datapremierei,numarBilete")] Spectacol spectacol)
        {
            if (ModelState.IsValid)
            {
                db.Spectacols.Add(spectacol);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(spectacol);
        }

        // GET: /Admin/Edit/5
        public ActionResult Edit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spectacol spectacol = db.Spectacols.Find(id);
            if (spectacol == null)
            {
                return HttpNotFound();
            }
            return View(spectacol);
        }

        // POST: /Admin/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="SpectacolId,distributia,regia,datapremierei,numarBilete")] Spectacol spectacol)
        {
            if (ModelState.IsValid)
            {
                db.Entry(spectacol).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(spectacol);
        }

        // GET: /Admin/Delete/5
        public ActionResult Delete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Spectacol spectacol = db.Spectacols.Find(id);
            if (spectacol == null)
            {
                return HttpNotFound();
            }
            return View(spectacol);
        }

        // POST: /Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            Spectacol spectacol = db.Spectacols.Find(id);
            db.Spectacols.Remove(spectacol);
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
