using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FM_Grupo2.DAL;
using FM_Grupo2.Models;

namespace FM_Grupo2.Controllers
{
    public class JornadasController : Controller
    {
        private FMContext db = new FMContext();

        // GET: Jornadas
        public ActionResult Index()
        {
            var jornadas = db.Jornadas.Include(j => j.Temporada);
            return View(jornadas.ToList());
        }

        // GET: Jornadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jornada jornada = db.Jornadas.Find(id);
            if (jornada == null)
            {
                return HttpNotFound();
            }
            return View(jornada);
        }

        // GET: Jornadas/Create
        public ActionResult Create()
        {
            ViewBag.TemporadaID = new SelectList(db.Temporadas, "TemporadaID", "Nome");
            return View();
        }

        // POST: Jornadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JornadaID,TemporadaID,NumJornada,DataInicio,DataFim")] Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                db.Jornadas.Add(jornada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TemporadaID = new SelectList(db.Temporadas, "TemporadaID", "Nome", jornada.TemporadaID);
            return View(jornada);
        }

        // GET: Jornadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jornada jornada = db.Jornadas.Find(id);
            if (jornada == null)
            {
                return HttpNotFound();
            }
            ViewBag.TemporadaID = new SelectList(db.Temporadas, "TemporadaID", "Nome", jornada.TemporadaID);
            return View(jornada);
        }

        // POST: Jornadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JornadaID,TemporadaID,NumJornada,DataInicio,DataFim")] Jornada jornada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jornada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TemporadaID = new SelectList(db.Temporadas, "TemporadaID", "Nome", jornada.TemporadaID);
            return View(jornada);
        }

        // GET: Jornadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jornada jornada = db.Jornadas.Find(id);
            if (jornada == null)
            {
                return HttpNotFound();
            }
            return View(jornada);
        }

        // POST: Jornadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jornada jornada = db.Jornadas.Find(id);
            db.Jornadas.Remove(jornada);
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
