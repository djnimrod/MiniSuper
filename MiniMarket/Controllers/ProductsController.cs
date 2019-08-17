using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MiniMarket.DalContext;
using MiniMarket.Models;

namespace MiniMarket.Controllers
{
    public class ProductsController : Controller
    {
        private AlmacenContext db = new AlmacenContext();

        // GET: Products
        public ActionResult Index()
        {
            var products = db.Products.Include(p => p.Category).Include(p => p.Provider).Include(p => p.Unit);
            return View(products.ToList());
        }

        // GET: Products/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: Products/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "TipoCategoria");
            ViewBag.ProviderID = new SelectList(db.Providers, "Id", "Nombre");
            ViewBag.UnitID = new SelectList(db.Units, "Id", "Nombre");
            return View();
        }

        // POST: Products/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Nombre,Precio,FechaVencimiento,Foto,CategoryID,UnitID,ProviderID")] Product product, HttpPostedFileBase imagenProducto)
        {
            if (imagenProducto != null && imagenProducto.ContentLength > 0)
            {
               // byte[] imagenData = new byte[imagenProducto.ContentLength];
                string dir = string.Empty;
                string path = Path.Combine(Server.MapPath("/Images/Photo/"),
                                            Path.GetFileName(imagenProducto.FileName));

                imagenProducto.SaveAs(path);
                dir = "~/Images/Photo/" + imagenProducto.FileName;
                product.Foto = dir;
            }

            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "TipoCategoria", product.CategoryID);
            ViewBag.ProviderID = new SelectList(db.Providers, "Id", "Nombre", product.ProviderID);
            ViewBag.UnitID = new SelectList(db.Units, "Id", "Nombre", product.UnitID);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "TipoCategoria", product.CategoryID);
            ViewBag.ProviderID = new SelectList(db.Providers, "Id", "Nombre", product.ProviderID);
            ViewBag.UnitID = new SelectList(db.Units, "Id", "Nombre", product.UnitID);
            return View(product);
        }

        // POST: Products/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Nombre,Precio,FechaVencimiento,Foto,CategoryID,UnitID,ProviderID")] Product product, HttpPostedFileBase imagenProducto)
        {
            if (imagenProducto != null && imagenProducto.ContentLength > 0)
            {
                byte[] imagenData = new byte[imagenProducto.ContentLength];
                string dir = string.Empty;
                string path = Path.Combine(Server.MapPath("/Images/Photo/"),
                                            Path.GetFileName(imagenProducto.FileName));

                imagenProducto.SaveAs(path);
                dir = "~/Images/Photo/" + imagenProducto.FileName;
                product.Foto = dir;
            }
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryID = new SelectList(db.Categories, "Id", "TipoCategoria", product.CategoryID);
            ViewBag.ProviderID = new SelectList(db.Providers, "Id", "Nombre", product.ProviderID);
            ViewBag.UnitID = new SelectList(db.Units, "Id", "Nombre", product.UnitID);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
