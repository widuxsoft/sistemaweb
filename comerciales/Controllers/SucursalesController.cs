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
    public class SucursalesController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Sucursales
        public ActionResult Index()
        {
            var tam_sucursales = db.tam_sucursales.Include(t => t.tam_empresas).Include(t => t.tam_localidades);
            return View(tam_sucursales.ToList());
        }

        // GET: Sucursales/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_sucursales tam_sucursales = db.tam_sucursales.Find(id);
            if (tam_sucursales == null)
            {
                return HttpNotFound();
            }
            return View(tam_sucursales);
        }

        // GET: Sucursales/Create
        public ActionResult Create()
        {
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre");
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion");
            return View();
        }

        // POST: Sucursales/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_empresa,cod_sucursal,nombre,calle,numero,depto,piso,cod_localidad,telefono,caracteristicca,mail,fecha_creacion,estado,id,caracteristica")] tam_sucursales tam_sucursales)
        {
            if (ModelState.IsValid)
            {
                db.tam_sucursales.Add(tam_sucursales);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre", tam_sucursales.cod_empresa);
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion", tam_sucursales.cod_localidad);
            return View(tam_sucursales);
        }

        // GET: Sucursales/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_sucursales tam_sucursales = db.tam_sucursales.Find(id);
            if (tam_sucursales == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre", tam_sucursales.cod_empresa);
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion", tam_sucursales.cod_localidad);
            return View(tam_sucursales);
        }

        // POST: Sucursales/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_empresa,cod_sucursal,nombre,calle,numero,depto,piso,cod_localidad,telefono,caracteristicca,mail,fecha_creacion,estado,id,caracteristica")] tam_sucursales tam_sucursales)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tam_sucursales).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre", tam_sucursales.cod_empresa);
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion", tam_sucursales.cod_localidad);
            return View(tam_sucursales);
        }

        // GET: Sucursales/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_sucursales tam_sucursales = db.tam_sucursales.Find(id);
            if (tam_sucursales == null)
            {
                return HttpNotFound();
            }
            return View(tam_sucursales);
        }

        // POST: Sucursales/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tam_sucursales tam_sucursales = db.tam_sucursales.Find(id);
            db.tam_sucursales.Remove(tam_sucursales);
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
