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
    public class ColoresController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Colores
        public ActionResult Index()
        {
            return View(db.tam_colores.ToList());
        }

        // GET: Colores/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_colores tam_colores = db.tam_colores.Find(id);
            if (tam_colores == null)
            {
                return HttpNotFound();
            }
            return View(tam_colores);
        }

        // GET: Colores/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Colores/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,color")] tam_colores tam_colores)
        {
            if (ModelState.IsValid)
            {
                db.tam_colores.Add(tam_colores);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tam_colores);
        }

        // GET: Colores/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_colores tam_colores = db.tam_colores.Find(id);
            if (tam_colores == null)
            {
                return HttpNotFound();
            }
            return View(tam_colores);
        }

        // POST: Colores/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,color")] tam_colores tam_colores)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tam_colores).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tam_colores);
        }

        // GET: Colores/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_colores tam_colores = db.tam_colores.Find(id);
            if (tam_colores == null)
            {
                return HttpNotFound();
            }
            return View(tam_colores);
        }

        // POST: Colores/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tam_colores tam_colores = db.tam_colores.Find(id);
            db.tam_colores.Remove(tam_colores);
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
