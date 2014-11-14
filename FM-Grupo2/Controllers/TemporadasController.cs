using FM_Grupo2.DAL;
using FM_Grupo2.Models;
using FM_Grupo2.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Mvc;

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
            //ViewBag.CampeonatoID = new SelectList(db.Campeonatos, "CampeonatoID", "Nome");
            ViewBag.CampeonatoID = db.Campeonatos.ToList();
            var temporada = new Temporada();
            temporada.Equipas = new List<Equipa>();
            PopulateAssignedEquipaData(temporada);
            return View();
        }

        // POST: Temporadas/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TemporadaID,CampeonatoID,Nome,Ano,Descricao,NJornadas")] Temporada temporada, string[] selectedEquipas)
        {
            if (selectedEquipas != null)
            {
                temporada.Equipas = new List<Equipa>();
                foreach (var course in selectedEquipas)
                {
                    var equipaToAdd = db.Equipas.Find(int.Parse(course));
                    temporada.Equipas.Add(equipaToAdd);
                }
            }
            if (ModelState.IsValid)
            {
                var numeroJornadas = temporada.NJornadas;
                
                db.Temporadas.Add(temporada);
                db.SaveChanges();

                if(numeroJornadas>=1 && numeroJornadas<=100)
                {
                    for (var i = 0; i < numeroJornadas; i++)
                    {

                        Jornada jornada = new Jornada();
                        jornada.TemporadaID = temporada.TemporadaID;
                        jornada.NumJornada = i+1;
                        jornada.DataInicio = DateTime.Now;
                        jornada.DataFim = DateTime.Now;
                        

                        db.Jornadas.Add(jornada);
                        db.SaveChanges();
                    }
                }
                
                return RedirectToAction("Index");
            }

            ViewBag.CampeonatoID = db.Campeonatos.ToList();
            PopulateAssignedEquipaData(temporada);
            //ViewBag.CampeonatoID = new SelectList(db.Campeonatos, "CampeonatoID", "Nome", temporada.CampeonatoID);
            return View(temporada);
        }

        // GET: Temporadas/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            //Temporada temporada = db.Temporadas.Find(id);
            Temporada temporada = db.Temporadas
                .Include(i => i.Campeonato)
                .Include(i => i.Equipas)
                .Where(i => i.TemporadaID == id)
                .Single();
            
            PopulateAssignedEquipaData(temporada);
            
            if (temporada == null)
            {
                return HttpNotFound();
            }

            ViewBag.CampeonatoID = db.Campeonatos.ToList();
            return View(temporada);
        }

        // POST: Temporadas/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int? id, string[] selectedEquipas)
        {
            if(id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Temporada temporadaToUpdate = db.Temporadas
                .Include(i => i.Campeonato)
                .Include(i => i.Equipas)
                .Where(i => i.TemporadaID == id)
                .Single();

            if (TryUpdateModel(temporadaToUpdate, "", new string[] { "TemporadaID","CampeonatoID","Nome","Ano","Descricao","NJornadas" }))
            {
                try
                {
                    if(String.IsNullOrWhiteSpace(temporadaToUpdate.Campeonato.Nome))
                    {
                        temporadaToUpdate.Campeonato = null;
                    }

                    UpdateTemporadaEquipas(selectedEquipas, temporadaToUpdate);

                    db.Entry(temporadaToUpdate).State = EntityState.Modified;
                    db.SaveChanges();

                    return RedirectToAction("Index");
                }
                catch (RetryLimitExceededException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }

            
            //ViewBag.CampeonatoID = new SelectList(db.Campeonatos, "CampeonatoID", "Nome", temporada.CampeonatoID);
            ViewBag.CampeonatoID = db.Campeonatos.ToList();
            PopulateAssignedEquipaData(temporadaToUpdate);
            return View(temporadaToUpdate);
        }

        private void PopulateAssignedEquipaData(Temporada temporada)
        {
            var campeonatoID = temporada.CampeonatoID;
            var allEquipas = db.Equipas;
            var equipasTemporada = new HashSet<int>(temporada.Equipas.Select(c => c.EquipaID));
            var viewModel = new List<AssignedEquipaData>();
            foreach (var equipa in allEquipas)
            {
                viewModel.Add(new AssignedEquipaData
                {
                    EquipaID = equipa.EquipaID,
                    Nome = equipa.NomeEquipa,
                    CountryID = equipa.CountryID,
                    Assigned = equipasTemporada.Contains(equipa.EquipaID)
                });
            }
            ViewBag.Equipas = viewModel;
        }

        private void UpdateTemporadaEquipas(string[] selectedEquipas, Temporada temporadaToUpdate)
        {
            if (selectedEquipas == null)
            {
                temporadaToUpdate.Equipas = new List<Equipa>();
                return;
            }

            var selectedEquipasHS = new HashSet<string>(selectedEquipas);
            var temporadaEquipas = new HashSet<int>
                (temporadaToUpdate.Equipas.Select(c => c.EquipaID));
            foreach (var equipa in db.Equipas)
            {
                if (selectedEquipasHS.Contains(equipa.EquipaID.ToString()))
                {
                    if (!temporadaEquipas.Contains(equipa.EquipaID))
                    {
                        temporadaToUpdate.Equipas.Add(equipa);
                    }
                }
                else
                {
                    if (temporadaEquipas.Contains(equipa.EquipaID))
                    {
                        temporadaToUpdate.Equipas.Remove(equipa);
                    }
                }
            }
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
            Temporada temporada = db.Temporadas
                .Include(i => i.Campeonato)
                .Include(i => i.Equipas)
                .Where(i => i.TemporadaID == id)
                .Single();

            temporada.Campeonato = null;
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
