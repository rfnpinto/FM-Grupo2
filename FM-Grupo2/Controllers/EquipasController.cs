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
    public class EquipasController : Controller
    {
        private FMContext db = new FMContext();

        // GET: Equipas
        public ActionResult Index()
        {
            return View(db.Equipas.ToList());
        }

        // GET: Equipas/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipa equipa = db.Equipas.Find(id);
            if (equipa == null)
            {
                return HttpNotFound();
            }
            return View(equipa);
        }

        // GET: Equipas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Equipas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NomeEquipa,Logotipo,Clube,Localizacao")] Equipa equipa)
        {
            if (ModelState.IsValid)
            {
                db.Equipas.Add(equipa);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(equipa);
        }

        // GET: Equipas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipa equipa = db.Equipas.Find(id);
            if (equipa == null)
            {
                return HttpNotFound();
            }
            return View(equipa);
        }

        // POST: Equipas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NomeEquipa,Logotipo,Clube,Localizacao")] Equipa equipa)
        {
            if (ModelState.IsValid)
            {
                db.Entry(equipa).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(equipa);
        }

        // GET: Equipas/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Equipa equipa = db.Equipas.Find(id);
            if (equipa == null)
            {
                return HttpNotFound();
            }
            return View(equipa);
        }

        // POST: Equipas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Equipa equipa = db.Equipas.Find(id);
            db.Equipas.Remove(equipa);
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
