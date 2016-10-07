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
    public class ConsesionariasController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Consesionarias
        public ActionResult Index()
        {
            return View(db.Consesionarias.ToList());
        }

        // GET: Consesionarias/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consesionaria consesionaria = db.Consesionarias.Find(id);
            if (consesionaria == null)
            {
                return HttpNotFound();
            }
            return View(consesionaria);
        }

        // GET: Consesionarias/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Consesionarias/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Direccion,Lat,Lon,Telefono,Email")] Consesionaria consesionaria)
        {
            if (ModelState.IsValid)
            {
                db.Consesionarias.Add(consesionaria);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(consesionaria);
        }

        // GET: Consesionarias/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consesionaria consesionaria = db.Consesionarias.Find(id);
            if (consesionaria == null)
            {
                return HttpNotFound();
            }
            return View(consesionaria);
        }

        // POST: Consesionarias/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Direccion,Lat,Lon,Telefono,Email")] Consesionaria consesionaria)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consesionaria).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consesionaria);
        }

        // GET: Consesionarias/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consesionaria consesionaria = db.Consesionarias.Find(id);
            if (consesionaria == null)
            {
                return HttpNotFound();
            }
            return View(consesionaria);
        }

        // POST: Consesionarias/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Consesionaria consesionaria = db.Consesionarias.Find(id);
            db.Consesionarias.Remove(consesionaria);
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
