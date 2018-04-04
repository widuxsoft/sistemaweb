using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using comerciales.Contexto;

namespace comerciales.Controllers
{
    [Authorize]
    public class RubrosController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Rubros
        public ActionResult Index()
        {
            return View(db.tamp_rubros.ToList());
        }

        // GET: Rubros/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tamp_rubros tamp_rubros = db.tamp_rubros.Find(id);
            if (tamp_rubros == null)
            {
                return HttpNotFound();
            }
            return View(tamp_rubros);
        }

        // GET: Rubros/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Rubros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_rubro,descripcion")] tamp_rubros tamp_rubros)
        {
            if (ModelState.IsValid)
            {
                db.tamp_rubros.Add(tamp_rubros);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tamp_rubros);
        }

        // GET: Rubros/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tamp_rubros tamp_rubros = db.tamp_rubros.Find(id);
            if (tamp_rubros == null)
            {
                return HttpNotFound();
            }
            return View(tamp_rubros);
        }

        // POST: Rubros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_rubro,descripcion")] tamp_rubros tamp_rubros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tamp_rubros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tamp_rubros);
        }

        // GET: Rubros/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tamp_rubros tamp_rubros = db.tamp_rubros.Find(id);
            if (tamp_rubros == null)
            {
                return HttpNotFound();
            }
            return View(tamp_rubros);
        }

        // POST: Rubros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tamp_rubros tamp_rubros = db.tamp_rubros.Find(id);
            db.tamp_rubros.Remove(tamp_rubros);
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
