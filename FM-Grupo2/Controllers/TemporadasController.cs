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
    public class TemporadasController : Controller
    {
        private FMContext db = new FMContext();

        // GET: Temporadas
        public ActionResult Index()
        {
            var temporadas = db.Temporadas.Include(t => t.Campeonato);
            return View(temporadas.ToList());
        }

        // GET: Temporadas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = db.Temporadas.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // GET: Temporadas/Create
        public ActionResult Create()
        {
            ViewBag.CampeonatoID = new SelectList(db.Campeonatos, "CampeonatoID", "Nome");
            return View();
        }

        // POST: Temporadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TemporadaID,CampeonatoID,Nome,Ano,Descricao,NJornadas")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Temporadas.Add(temporada);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CampeonatoID = new SelectList(db.Campeonatos, "CampeonatoID", "Nome", temporada.CampeonatoID);
            return View(temporada);
        }

        // GET: Temporadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = db.Temporadas.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            ViewBag.CampeonatoID = new SelectList(db.Campeonatos, "CampeonatoID", "Nome", temporada.CampeonatoID);
            return View(temporada);
        }

        // POST: Temporadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TemporadaID,CampeonatoID,Nome,Ano,Descricao,NJornadas")] Temporada temporada)
        {
            if (ModelState.IsValid)
            {
                db.Entry(temporada).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CampeonatoID = new SelectList(db.Campeonatos, "CampeonatoID", "Nome", temporada.CampeonatoID);
            return View(temporada);
        }

        // GET: Temporadas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporada = db.Temporadas.Find(id);
            if (temporada == null)
            {
                return HttpNotFound();
            }
            return View(temporada);
        }

        // POST: Temporadas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Temporada temporada = db.Temporadas.Find(id);
            db.Temporadas.Remove(temporada);
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
