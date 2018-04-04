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
    [Authorize(Roles = "Admin")]
    public class ProveedoresController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Proveedores
        public ActionResult Index()
        {
            return View(db.tam_proveedores.ToList());
        }

        // GET: Proveedores/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_proveedores tam_proveedores = db.tam_proveedores.Find(id);
            if (tam_proveedores == null)
            {
                return HttpNotFound();
            }
            return View(tam_proveedores);
        }

        // GET: Proveedores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Proveedores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,nombre")] tam_proveedores tam_proveedores)
        {
            if (ModelState.IsValid)
            {
                db.tam_proveedores.Add(tam_proveedores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tam_proveedores);
        }

        // GET: Proveedores/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_proveedores tam_proveedores = db.tam_proveedores.Find(id);
            if (tam_proveedores == null)
            {
                return HttpNotFound();
            }
            return View(tam_proveedores);
        }

        // POST: Proveedores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nombre")] tam_proveedores tam_proveedores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tam_proveedores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tam_proveedores);
        }

        // GET: Proveedores/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_proveedores tam_proveedores = db.tam_proveedores.Find(id);
            if (tam_proveedores == null)
            {
                return HttpNotFound();
            }
            return View(tam_proveedores);
        }

        // POST: Proveedores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tam_proveedores tam_proveedores = db.tam_proveedores.Find(id);
            db.tam_proveedores.Remove(tam_proveedores);
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
