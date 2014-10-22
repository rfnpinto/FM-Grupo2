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
    public class CampeonatoesController : Controller
    {
        private FMContext db = new FMContext();

        // GET: Campeonatoes
        public ActionResult Index()
        {
            return View(db.Campeonatos.ToList());
        }

        // GET: Campeonatoes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campeonato campeonato = db.Campeonatos.Find(id);
            if (campeonato == null)
            {
                return HttpNotFound();
            }
            return View(campeonato);
        }

        // GET: Campeonatoes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Campeonatoes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CampeonatoID,Nome,LogotipoPath,Nacionalidade,EntidadeOrganizadora,Descricao,DataFundacao")] Campeonato campeonato)
        {
            if (ModelState.IsValid)
            {
                db.Campeonatos.Add(campeonato);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(campeonato);
        }

        // GET: Campeonatoes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campeonato campeonato = db.Campeonatos.Find(id);
            if (campeonato == null)
            {
                return HttpNotFound();
            }
            return View(campeonato);
        }

        // POST: Campeonatoes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "CampeonatoID,Nome,LogotipoPath,Nacionalidade,EntidadeOrganizadora,Descricao,DataFundacao")] Campeonato campeonato)
        {
            if (ModelState.IsValid)
            {
                db.Entry(campeonato).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(campeonato);
        }

        // GET: Campeonatoes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Campeonato campeonato = db.Campeonatos.Find(id);
            if (campeonato == null)
            {
                return HttpNotFound();
            }
            return View(campeonato);
        }

        // POST: Campeonatoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Campeonato campeonato = db.Campeonatos.Find(id);
            db.Campeonatos.Remove(campeonato);
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
