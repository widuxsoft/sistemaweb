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
    public class marcasController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: marcas
        public ActionResult Index()
        {
            return View(db.tam_marcas.ToList());
        }

        // GET: marcas/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_marcas tam_marcas = db.tam_marcas.Find(id);
            if (tam_marcas == null)
            {
                return HttpNotFound();
            }
            return View(tam_marcas);
        }

        // GET: marcas/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: marcas/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_marca,descripcion")] tam_marcas tam_marcas)
        {
            if (ModelState.IsValid)
            {
                db.tam_marcas.Add(tam_marcas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tam_marcas);
        }

        // GET: marcas/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_marcas tam_marcas = db.tam_marcas.Find(id);
            if (tam_marcas == null)
            {
                return HttpNotFound();
            }
            return View(tam_marcas);
        }

        // POST: marcas/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_marca,descripcion")] tam_marcas tam_marcas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tam_marcas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tam_marcas);
        }

        // GET: marcas/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_marcas tam_marcas = db.tam_marcas.Find(id);
            if (tam_marcas == null)
            {
                return HttpNotFound();
            }
            return View(tam_marcas);
        }

        // POST: marcas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tam_marcas tam_marcas = db.tam_marcas.Find(id);
            db.tam_marcas.Remove(tam_marcas);
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
