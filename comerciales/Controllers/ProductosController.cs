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
    public class ProductosController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Productos
        public ActionResult Index()
        {
            var tam_productos = db.tam_productos.Include(t => t.tam_empresas).Include(t => t.tam_subrubros).Include(t => t.tamp_rubros).Include(t => t.tap_tablas).Include(t => t.tap_tablas1);
            return View(tam_productos.ToList());
        }

        // GET: Productos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_productos tam_productos = db.tam_productos.Find(id);
            if (tam_productos == null)
            {
                return HttpNotFound();
            }
            return View(tam_productos);
        }

        // GET: Productos/Create
        public ActionResult Create()
        {
            db.tap_tablas.Where(j => j.cod_tabla.Equals(1));
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre");
            ViewBag.cod_subrubro = new SelectList(db.tam_subrubros, "cod_subrubro", "descripcion");
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion");
            ViewBag.id_agente = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(1)), "id", "valor");
            ViewBag.id_tipo_fuego = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(2)), "id", "valor");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_empresa,cod_producto,nombre,descripcion,precio_costo,precio_venta,precio_recarga,margen,estado,cod_marca,cod_rubro,cod_subrubro,cod_color,capacidad_nominal,id_agente,id_tipo_fuego,fecha_creacion,id")] tam_productos tam_productos)
        {
            if (ModelState.IsValid)
            {
                tam_productos.cod_producto = tam_productos.id;
                tam_productos.cod_empresa = 1;
                tam_productos.estado = "0";
                tam_productos.fecha_creacion = DateTime.Now;
                db.tam_productos.Add(tam_productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
          //  db.tap_tablas1.Where(j => j.cod_tabla.Equals(1));
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre", tam_productos.cod_empresa);
            ViewBag.cod_subrubro = new SelectList(db.tam_subrubros, "cod_subrubro", "descripcion", tam_productos.cod_subrubro);
            ViewBag.id_agente = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(1)), "id", "valor", tam_productos.id_agente);
            ViewBag.id_tipo_fuego = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(2)), "id", "valor", tam_productos.id_tipo_fuego);
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion", tam_productos.cod_rubro);

            // ViewBag.id_tipo_fuego = new SelectList(db.tap_tablas1, "id", "codigo", tam_productos.id_tipo_fuego);
            return View(tam_productos);
        }

        // GET: Productos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_productos tam_productos = db.tam_productos.Find(id);
            if (tam_productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre", tam_productos.cod_empresa);
            ViewBag.cod_subrubro = new SelectList(db.tam_subrubros, "cod_subrubro", "descripcion", tam_productos.cod_subrubro);
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion", tam_productos.cod_rubro);
            ViewBag.id_agente = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(1)), "id", "valor",tam_productos.id_agente);
            ViewBag.id_tipo_fuego = new SelectList(db.tap_tablas.Where(j => j.cod_tabla.Equals(2)), "id", "valor",tam_productos.id_tipo_fuego);

            return View(tam_productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_empresa,cod_producto,nombre,descripcion,precio_costo,precio_venta,precio_recarga,margen,estado,cod_marca,cod_rubro,cod_subrubro,cod_color,capacidad_nominal,id_agente,id_tipo_fuego,fecha_creacion,id")] tam_productos tam_productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tam_productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.cod_empresa = new SelectList(db.tam_empresas, "cod_empresa", "nombre", tam_productos.cod_empresa);
            ViewBag.cod_subrubro = new SelectList(db.tam_subrubros, "cod_subrubro", "descripcion", tam_productos.cod_subrubro);
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion", tam_productos.cod_rubro);
            ViewBag.id_agente = new SelectList(db.tap_tablas, "id", "codigo", tam_productos.id_agente);
            ViewBag.id_tipo_fuego = new SelectList(db.tap_tablas, "id", "codigo", tam_productos.id_tipo_fuego);
            return View(tam_productos);
        }

        // GET: Productos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_productos tam_productos = db.tam_productos.Find(id);
            if (tam_productos == null)
            {
                return HttpNotFound();
            }
            return View(tam_productos);
        }

        // POST: Productos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tam_productos tam_productos = db.tam_productos.Find(id);
            db.tam_productos.Remove(tam_productos);
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
