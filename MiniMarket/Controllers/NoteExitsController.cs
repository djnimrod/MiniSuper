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
    public class NoteExitsController : Controller
    {
        private AlmacenContext db = new AlmacenContext();

        // GET: NoteExits
        public ActionResult Index()
        {
            var noteExits = db.NoteExits.Include(n => n.User);
            return View(noteExits.ToList());
        }

        // GET: NoteExits/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteExit noteExit = db.NoteExits.Find(id);
            if (noteExit == null)
            {
                return HttpNotFound();
            }
            return View(noteExit);
        }

        // GET: NoteExits/Create
        public ActionResult Create()
        {
            ViewBag.UserId = new SelectList(db.Users, "Id", "NameUser");
            return View();
        }

        // POST: NoteExits/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Observacion,FechaSalida,Encargado,UserId")] NoteExit noteExit)
        {
            if (ModelState.IsValid)
            {
                db.NoteExits.Add(noteExit);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.UserId = new SelectList(db.Users, "Id", "NameUser", noteExit.UserId);
            return View(noteExit);
        }

        // GET: NoteExits/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteExit noteExit = db.NoteExits.Find(id);
            if (noteExit == null)
            {
                return HttpNotFound();
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "NameUser", noteExit.UserId);
            return View(noteExit);
        }

        // POST: NoteExits/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Observacion,FechaSalida,Encargado,UserId")] NoteExit noteExit)
        {
            if (ModelState.IsValid)
            {
                db.Entry(noteExit).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.UserId = new SelectList(db.Users, "Id", "NameUser", noteExit.UserId);
            return View(noteExit);
        }

        // GET: NoteExits/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            NoteExit noteExit = db.NoteExits.Find(id);
            if (noteExit == null)
            {
                return HttpNotFound();
            }
            return View(noteExit);
        }

        // POST: NoteExits/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            NoteExit noteExit = db.NoteExits.Find(id);
            db.NoteExits.Remove(noteExit);
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
