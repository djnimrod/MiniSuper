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
    public class NoteExitProductsController : Controller
    {
        private AlmacenContext db = new AlmacenContext();

        // GET: NoteExitProducts
        public ActionResult Index()
        {
            var noteExitProducts = db.NoteExitProducts.Include(n => n.NoteExit).Include(n => n.Product);
            return View(noteExitProducts.ToList());
        }

        // GET: NoteExitProducts/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteExitProduct noteExitProduct = db.NoteExitProducts.Find(id);
            if (noteExitProduct == null)
            {
                return HttpNotFound();
            }
            return View(noteExitProduct);
        }

        // GET: NoteExitProducts/Create
        public ActionResult Create()
        {
            ViewBag.NoteExitID = new SelectList(db.NoteExits, "Id", "Observacion");
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Nombre");
            return View();
        }

        // POST: NoteExitProducts/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,NoteExitID,ProductID,Cantidad")] NoteExitProduct noteExitProduct)
        {
            if (ModelState.IsValid)
            {
                // actualizar aqui
                ActualizarInventario(noteExitProduct.ProductID, noteExitProduct.Cantidad);
                //
                db.NoteExitProducts.Add(noteExitProduct);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.NoteExitID = new SelectList(db.NoteExits, "Id", "Observacion", noteExitProduct.NoteExitID);
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Nombre", noteExitProduct.ProductID);
            return View(noteExitProduct);
        }

        // GET: NoteExitProducts/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteExitProduct noteExitProduct = db.NoteExitProducts.Find(id);
            if (noteExitProduct == null)
            {
                return HttpNotFound();
            }
            ViewBag.NoteExitID = new SelectList(db.NoteExits, "Id", "Observacion", noteExitProduct.NoteExitID);
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Nombre", noteExitProduct.ProductID);
            return View(noteExitProduct);
        }

        // POST: NoteExitProducts/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,NoteExitID,ProductID,Cantidad")] NoteExitProduct noteExitProduct)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noteExitProduct).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.NoteExitID = new SelectList(db.NoteExits, "Id", "Observacion", noteExitProduct.NoteExitID);
            ViewBag.ProductID = new SelectList(db.Products, "Id", "Nombre", noteExitProduct.ProductID);
            return View(noteExitProduct);
        }

        // GET: NoteExitProducts/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteExitProduct noteExitProduct = db.NoteExitProducts.Find(id);
            if (noteExitProduct == null)
            {
                return HttpNotFound();
            }
            return View(noteExitProduct);
        }

        // POST: NoteExitProducts/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NoteExitProduct noteExitProduct = db.NoteExitProducts.Find(id);
            db.NoteExitProducts.Remove(noteExitProduct);
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
        //
        public void ActualizarInventario(int idProduct, int cantidad)
        {

            var inventory = (from a in db.Inventories
                             where a.ProductID == idProduct
                             select a).FirstOrDefault();

            inventory.Cantidad = inventory.Cantidad - cantidad;
            db.Entry(inventory).State = EntityState.Modified;
            db.SaveChanges();


        }
    }
}
