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
    public class JogosController : Controller
    {
        private FMContext db = new FMContext();

        // GET: Jogos
        public ActionResult Index()
        {
            var jogos = db.Jogos.Include(j => j.Jornada);
            return View(jogos.ToList());
        }

        // GET: Jogos/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // GET: Jogos/Create
        public ActionResult Create()
        {
            ViewBag.TemporadaID = db.Temporadas.ToList();
            ViewBag.JornadaID = db.Jornadas.ToList();
            db.Database.ExecuteSqlCommand("Select TemporadaID, Nome.Equipa,  From Equipa INNER JOIN TemporadaEquipa INNER JOIN Temporada");
            return View();
        }

        // POST: Jogos/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,JornadaID,VisitadaEquipaID,VisitanteEquipaID,Data,Resultado")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Jogos.Add(jogo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TemporadaID = db.Temporadas.ToList();
            ViewBag.JornadaID = db.Jornadas.ToList();
            return View(jogo);
        }

        // GET: Jogos/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            ViewBag.JornadaID = new SelectList(db.Jornadas, "JornadaID", "JornadaID", jogo.JornadaID);
            return View(jogo);
        }

        // POST: Jogos/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,JornadaID,VisitadaEquipaID,VisitanteEquipaID,Data,Resultado")] Jogo jogo)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jogo).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.JornadaID = new SelectList(db.Jornadas, "JornadaID", "JornadaID", jogo.JornadaID);
            return View(jogo);
        }

        // GET: Jogos/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Jogo jogo = db.Jogos.Find(id);
            if (jogo == null)
            {
                return HttpNotFound();
            }
            return View(jogo);
        }

        // POST: Jogos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Jogo jogo = db.Jogos.Find(id);
            db.Jogos.Remove(jogo);
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
