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
    public class NoteEntriesController : Controller
    {
        private AlmacenContext db = new AlmacenContext();

        // GET: NoteEntries
        public ActionResult Index()
        {
            var noteEntries = db.NoteEntries.Include(n => n.User);
            return View(noteEntries.ToList());
        }

        // GET: NoteEntries/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteEntry noteEntry = db.NoteEntries.Find(id);
            if (noteEntry == null)
            {
                return HttpNotFound();
            }
            return View(noteEntry);
        }

        // GET: NoteEntries/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "NameUser");
            return View();
        }

        // POST: NoteEntries/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Observacion,FechaEntrada,Encargado,UserId")] NoteEntry noteEntry)
        {
            if (ModelState.IsValid)
            {
                db.NoteEntries.Add(noteEntry);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "NameUser", noteEntry.UserId);
            return View(noteEntry);
        }

        // GET: NoteEntries/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteEntry noteEntry = db.NoteEntries.Find(id);
            if (noteEntry == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "NameUser", noteEntry.UserId);
            return View(noteEntry);
        }

        // POST: NoteEntries/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Observacion,FechaEntrada,Encargado,UserId")] NoteEntry noteEntry)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noteEntry).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "NameUser", noteEntry.UserId);
            return View(noteEntry);
        }

        // GET: NoteEntries/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteEntry noteEntry = db.NoteEntries.Find(id);
            if (noteEntry == null)
            {
                return HttpNotFound();
            }
            return View(noteEntry);
        }

        // POST: NoteEntries/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NoteEntry noteEntry = db.NoteEntries.Find(id);
            db.NoteEntries.Remove(noteEntry);
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
