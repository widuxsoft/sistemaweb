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
    public class ClientesController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Clientes
        public ActionResult Index()
        {
            var tam_clientes = db.tam_clientes.Include(t => t.tap_tablas).Include(t => t.tam_empresas).Include(t => t.tam_localidades);
            return View(tam_clientes.ToList());
        }

        // GET: Clientes/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_clientes tam_clientes = db.tam_clientes.Find(id);
            if (tam_clientes == null)
            {
                return HttpNotFound();
            }
            return View(tam_clientes);
        }

        // GET: Clientes/Create
        public ActionResult Create()
        {
            ViewBag.cod_tipo_doc = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(3)), "id", "valor");
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre");
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion");
            return View();
        }

        // POST: Clientes/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_empresa,id_cliente,cod_tipo_doc,apellido,telefono,caracteristica,email,estado,fecha_creacion,calle,numero,depto,piso,manzana,lote,cod_localidad,NOMBRE,nro_documento")] tam_clientes tam_clientes)
        {
            if (ModelState.IsValid)
            {
                db.tam_clientes.Add(tam_clientes);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_tipo_doc = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(3)), "id", "valor");
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre", tam_clientes.cod_empresa);
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion", tam_clientes.cod_localidad);
            return View(tam_clientes);
        }

        // GET: Clientes/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_clientes tam_clientes = db.tam_clientes.Find(id);
            if (tam_clientes == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_tipo_doc = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(3)), "id", "valor",tam_clientes.cod_tipo_doc);
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre", tam_clientes.cod_empresa);
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion", tam_clientes.cod_localidad);
            return View(tam_clientes);
        }

        // POST: Clientes/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_empresa,id_cliente,cod_tipo_doc,apellido,telefono,caracteristica,email,estado,fecha_creacion,calle,numero,depto,piso,manzana,lote,cod_localidad,NOMBRE,nro_documento")] tam_clientes tam_clientes)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tam_clientes).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_tipo_doc = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(3)), "id", "valor");
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre", tam_clientes.cod_empresa);
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion", tam_clientes.cod_localidad);
            return View(tam_clientes);
        }

        // GET: Clientes/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_clientes tam_clientes = db.tam_clientes.Find(id);
            if (tam_clientes == null)
            {
                return HttpNotFound();
            }
            return View(tam_clientes);
        }

        // POST: Clientes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tam_clientes tam_clientes = db.tam_clientes.Find(id);
            db.tam_clientes.Remove(tam_clientes);
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
