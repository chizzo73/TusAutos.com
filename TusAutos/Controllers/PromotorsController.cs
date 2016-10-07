using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TusAutos.Models;

namespace TusAutos.Controllers
{
    public class PromotorsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Promotors
        public ActionResult Index()
        {
            return View(db.Promotores.ToList());
        }

        // GET: Promotors/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotor promotor = db.Promotores.Find(id);
            if (promotor == null)
            {
                return HttpNotFound();
            }
            return View(promotor);
        }

        // GET: Promotors/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Promotors/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Direccion,Telefono,Lat,Lon")] Promotor promotor)
        {
            if (ModelState.IsValid)
            {
                db.Promotores.Add(promotor);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(promotor);
        }

        // GET: Promotors/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotor promotor = db.Promotores.Find(id);
            if (promotor == null)
            {
                return HttpNotFound();
            }
            return View(promotor);
        }

        // POST: Promotors/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Direccion,Telefono,Lat,Lon")] Promotor promotor)
        {
            if (ModelState.IsValid)
            {
                db.Entry(promotor).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(promotor);
        }

        // GET: Promotors/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Promotor promotor = db.Promotores.Find(id);
            if (promotor == null)
            {
                return HttpNotFound();
            }
            return View(promotor);
        }

        // POST: Promotors/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Promotor promotor = db.Promotores.Find(id);
            db.Promotores.Remove(promotor);
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
