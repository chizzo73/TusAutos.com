using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using TusAutos.Models;

namespace TusAutos.Controllers
{
    public class ImagensController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        [HttpPost]
        public ActionResult Upload(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    var fileName = Path.GetFileName(file.FileName);
                    var path = Path.Combine(Server.MapPath("~/Images"), fileName);
                    file.SaveAs(path);
                }
                ViewBag.Message = "Upload successful";
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.Message = "Upload failed";
                return RedirectToAction("Uploads");
            }
        }

        // GET: Imagens
        public ActionResult Index()
        {
            var imagenes = db.Imagenes.Include(i => i.Auto).Include(i => i.Promotor);
            return View(imagenes.ToList());
        }

        // GET: Imagens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Imagenes.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // GET: Imagens/Create
        public ActionResult Create()
        {
            ViewBag.AutoId = new SelectList(db.Autos, "Id", "Nombre");
            ViewBag.PromotorId = new SelectList(db.Promotores, "Id", "Nombre");
            return View();
        }

        // POST: Imagens/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FileName,Size,Path,AutoId,PromotorId")] Imagen imagen)
        {

            if (ModelState.IsValid)
            {
                db.Imagenes.Add(imagen);
                db.SaveChanges();
                return RedirectToAction("Index");
            }


            ViewBag.AutoId = new SelectList(db.Autos, "Id", "Nombre", imagen.AutoId);
            ViewBag.PromotorId = new SelectList(db.Promotores, "Id", "Nombre", imagen.PromotorId);
            return View(imagen);
        }

        // GET: Imagens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Imagenes.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            ViewBag.AutoId = new SelectList(db.Autos, "Id", "Nombre", imagen.AutoId);
            ViewBag.PromotorId = new SelectList(db.Promotores, "Id", "Nombre", imagen.PromotorId);
            return View(imagen);
        }

        // POST: Imagens/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FileName,Size,Path,AutoId,PromotorId")] Imagen imagen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(imagen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.AutoId = new SelectList(db.Autos, "Id", "Nombre", imagen.AutoId);
            ViewBag.PromotorId = new SelectList(db.Promotores, "Id", "Nombre", imagen.PromotorId);
            return View(imagen);
        }

        // GET: Imagens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Imagen imagen = db.Imagenes.Find(id);
            if (imagen == null)
            {
                return HttpNotFound();
            }
            return View(imagen);
        }

        // POST: Imagens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Imagen imagen = db.Imagenes.Find(id);
            db.Imagenes.Remove(imagen);
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
