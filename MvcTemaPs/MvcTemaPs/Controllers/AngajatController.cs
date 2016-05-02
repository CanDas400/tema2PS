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
    [Authorize(Roles="Angajat")]
    public class AngajatController : Controller
    {
        private TeatruDBContext db = new TeatruDBContext();

        // GET: /Angajat/
        public ActionResult Index()
        {

            return View(db.Bilets.ToList());
        }

       

        // GET: /Angajat/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilets.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // GET: /Angajat/Create
        public ActionResult Create()
        {

            //Get the value from database and then set it to ViewBag to pass it View
            IEnumerable<SelectListItem> items = db.Spectacols.Select(c => new SelectListItem
            {
                Value = c.SpectacolId,
                Text = c.SpectacolId

            });

            ViewData["Spectacole"] = items;
           
            return View();
        }

        // POST: /Angajat/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include="BiletId,titlul,rand,numar")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
           
                
                var movies = from m in db.Bilets
                             select m;
                  movies = movies.Where(s => s.numar == bilet.numar && s.rand == bilet.rand ); 
                        
                if (movies.ToList().Count == 0)
                {
                    db.Bilets.Add(bilet);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                else
                {
                    return RedirectToAction("Index");
                }
            }

            return View(bilet);
        }

        // GET: /Angajat/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilets.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // POST: /Angajat/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include="BiletId,titlul,rand,numar")] Bilet bilet)
        {
            if (ModelState.IsValid)
            {
                db.Entry(bilet).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(bilet);
        }

        // GET: /Angajat/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Bilet bilet = db.Bilets.Find(id);
            if (bilet == null)
            {
                return HttpNotFound();
            }
            return View(bilet);
        }

        // POST: /Angajat/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Bilet bilet = db.Bilets.Find(id);
            db.Bilets.Remove(bilet);
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
