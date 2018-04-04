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
    public class tap_empresasController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: tap_empresas
        public ActionResult Index()
        {
            var tap_empresas = db.tap_empresas;
            return View(tap_empresas.ToList());
        }

        // GET: tap_empresas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tap_empresas tap_empresas = db.tap_empresas.Find(id);
            if (tap_empresas == null)
            {
                return HttpNotFound();
            }
            return View(tap_empresas);
        }

        // GET: tap_empresas/Create
        public ActionResult Create()
        {            
            return View();
        }

        // POST: tap_empresas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_parametro,descripcion,valor,id")] tap_empresas tap_empresas)
        {
            if (ModelState.IsValid)
            {
                db.tap_empresas.Add(tap_empresas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            
            return View(tap_empresas);
        }

        // GET: tap_empresas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tap_empresas tap_empresas = db.tap_empresas.Find(id);
            if (tap_empresas == null)
            {
                return HttpNotFound();
            }
            
            return View(tap_empresas);
        }

        // POST: tap_empresas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_parametro,descripcion,valor,id")] tap_empresas tap_empresas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tap_empresas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit","Empresa");
            }           
            return View(tap_empresas);
        }

        // GET: tap_empresas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tap_empresas tap_empresas = db.tap_empresas.Find(id);
            if (tap_empresas == null)
            {
                return HttpNotFound();
            }
            return View(tap_empresas);
        }

        // POST: tap_empresas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tap_empresas tap_empresas = db.tap_empresas.Find(id);
            db.tap_empresas.Remove(tap_empresas);
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
