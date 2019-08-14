using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniMarket.DalContext;
using MiniMarket.Models;

namespace MiniMarket.Controllers
{
    public class NoteEntryProductsController : Controller
    {
        private AlmacenContext db = new AlmacenContext();

        // GET: NoteEntryProducts
        public ActionResult Index()
        {
            var noteEntryProducts = db.NoteEntryProducts.Include(n => n.NoteEntry).Include(n => n.Product);
            return View(noteEntryProducts.ToList());
        }

        // GET: NoteEntryProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteEntryProduct noteEntryProduct = db.NoteEntryProducts.Find(id);
            if (noteEntryProduct == null)
            {
                return HttpNotFound();
            }
            return View(noteEntryProduct);
        }

        // GET: NoteEntryProducts/Create
        public ActionResult Create()
        {
            ViewBag.NoteEntryID = new SelectList(db.NoteEntries, "Id", "Observacion");
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Nombre");
            return View();
        }

        // POST: NoteEntryProducts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NoteEntryID,ProductID,Cantidad")] NoteEntryProduct noteEntryProduct)
        {
            if (ModelState.IsValid)
            {
                db.NoteEntryProducts.Add(noteEntryProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NoteEntryID = new SelectList(db.NoteEntries, "Id", "Observacion", noteEntryProduct.NoteEntryID);
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Nombre", noteEntryProduct.ProductID);
            return View(noteEntryProduct);
        }

        // GET: NoteEntryProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteEntryProduct noteEntryProduct = db.NoteEntryProducts.Find(id);
            if (noteEntryProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoteEntryID = new SelectList(db.NoteEntries, "Id", "Observacion", noteEntryProduct.NoteEntryID);
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Nombre", noteEntryProduct.ProductID);
            return View(noteEntryProduct);
        }

        // POST: NoteEntryProducts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NoteEntryID,ProductID,Cantidad")] NoteEntryProduct noteEntryProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noteEntryProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NoteEntryID = new SelectList(db.NoteEntries, "Id", "Observacion", noteEntryProduct.NoteEntryID);
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Nombre", noteEntryProduct.ProductID);
            return View(noteEntryProduct);
        }

        // GET: NoteEntryProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteEntryProduct noteEntryProduct = db.NoteEntryProducts.Find(id);
            if (noteEntryProduct == null)
            {
                return HttpNotFound();
            }
            return View(noteEntryProduct);
        }

        // POST: NoteEntryProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NoteEntryProduct noteEntryProduct = db.NoteEntryProducts.Find(id);
            db.NoteEntryProducts.Remove(noteEntryProduct);
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
