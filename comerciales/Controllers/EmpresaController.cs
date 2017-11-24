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
    public class EmpresaController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Empresa
        public ActionResult Index()
        {
            return View(db.tam_empresas.ToList());
        }

        // GET: Empresa/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_empresas tam_empresas = db.tam_empresas.Find(id);
            if (tam_empresas == null)
            {
                return HttpNotFound();
            }
            return View(tam_empresas);
        }

        // GET: Empresa/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Empresa/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_empresa,nombre,razon_social,cuit,estado,fecha_creacion,fecha_baja")] tam_empresas tam_empresas)
        {
            if (ModelState.IsValid)
            {
                db.tam_empresas.Add(tam_empresas);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tam_empresas);
        }

        // GET: Empresa/Edit/5
        public ActionResult Edit(decimal id=1)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_empresas tam_empresas = db.tam_empresas.Find(id);

            if (tam_empresas == null)
            {
                return HttpNotFound();
            }
            return View(tam_empresas);
        }

        // POST: Empresa/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_empresa,nombre,razon_social,cuit,estado,fecha_creacion,fecha_baja")] tam_empresas tam_empresas)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tam_empresas).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tam_empresas);
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_empresas tam_empresas = db.tam_empresas.Find(id);
            if (tam_empresas == null)
            {
                return HttpNotFound();
            }
            return View(tam_empresas);
        }

        // POST: Empresa/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tam_empresas tam_empresas = db.tam_empresas.Find(id);
            db.tam_empresas.Remove(tam_empresas);
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
