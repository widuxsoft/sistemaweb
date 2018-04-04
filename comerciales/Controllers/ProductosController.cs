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
    public class ProductosController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Productos
        public ActionResult Index(string BuscarCodigo, String BuscarNombre, string BuscarRubro, string BuscarMarca, string BuscarProveedor,string BuscarEstado)
        {
            var productos = from pr in db.tam_productos select pr;
            var listaRubro = from ru in db.tamp_rubros select ru.descripcion ;
            var listaMarca = from ma in db.tam_marcas select ma.descripcion;
            var listaProveedor = from ma in db.tam_proveedores select ma.nombre;
            ViewBag.BuscarRubro = new SelectList(listaRubro);
            ViewBag.BuscarMarca = new SelectList(listaMarca);
            ViewBag.BuscarProveedor = new SelectList(listaProveedor);
            if (!String.IsNullOrEmpty(BuscarCodigo))
            {
                decimal codigo;
                codigo = Convert.ToDecimal(BuscarCodigo);
                productos = productos.Where(c => c.id.Equals(codigo));
            }
            else
            {
                if (!String.IsNullOrEmpty(BuscarRubro))
                {
                    tamp_rubros rubro = db.tamp_rubros.Where(c => c.descripcion.Equals(BuscarRubro) ).SingleOrDefault();
                    //tam_clientes tam_clientes = db.tam_clientes.Where(c => c.cod_tipo_doc == aTipoDoc && c.nro_documento == aNroDoc).SingleOrDefault();
                    decimal ldCodRubro = rubro.cod_rubro;
                    productos = productos.Where(c => c.cod_rubro == ldCodRubro );
                }
                if (!String.IsNullOrEmpty(BuscarMarca))
                {
                    tam_marcas marca = db.tam_marcas .Where(c => c.descripcion.Equals(BuscarMarca)).SingleOrDefault();
                    //tam_clientes tam_clientes = db.tam_clientes.Where(c => c.cod_tipo_doc == aTipoDoc && c.nro_documento == aNroDoc).SingleOrDefault();
                    decimal ldCodMarca = marca.cod_marca ;
                    productos = productos.Where(c => c.cod_marca == ldCodMarca);
                }

                if (!String.IsNullOrEmpty(BuscarNombre))
                {
                    productos = productos.Where(c => c.nombre.Contains(BuscarNombre));
                }

                if (!String.IsNullOrEmpty(BuscarProveedor))
                {
                    tam_proveedores proveedor = db.tam_proveedores.Where(c => c.nombre.Equals(BuscarProveedor)).SingleOrDefault();
                    //tam_clientes tam_clientes = db.tam_clientes.Where(c => c.cod_tipo_doc == aTipoDoc && c.nro_documento == aNroDoc).SingleOrDefault();
                    decimal ldCodProveedor = proveedor.id;
                    productos = productos.Where(c => c.id_proveedor == ldCodProveedor);
                }
                //var tam_productos = db.tam_productos.Include(t => t.tam_subrubros).Include(t => t.tamp_rubros);
                if (!String.IsNullOrEmpty(BuscarEstado) && BuscarEstado!="-1")
                {
                    productos = productos.Where(c => c.estado == BuscarEstado);
                }
            }
            //return View(tam_productos.ToList());
            return View(productos);
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
            ViewBag.id_proveedor = new SelectList(db.tam_proveedores, "id", "nombre");
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion");
            ViewBag.cod_marca = new SelectList(db.tam_marcas , "cod_marca", "descripcion");            
            ViewBag.cod_color = new SelectList(db.tam_colores , "cod_color", "descripcion");
            return View();
        }

        // POST: Productos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "nombre,descripcion,precio_costo,precio_venta,margen,estado,cod_marca,cod_rubro,cod_subrubro,cod_color,fecha_creacion,id,id_proveedor")] tam_productos tam_productos)
        {
            if (ModelState.IsValid)
            {
                            
                tam_productos.estado = "0";
                tam_productos.fecha_creacion = DateTime.Now;
                db.tam_productos.Add(tam_productos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            //  db.tap_tablas1.Where(j => j.cod_tabla.Equals(1));            
            ViewBag.id_proveedor = new SelectList(db.tam_proveedores, "id", "nombre", tam_productos.id_proveedor);
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion", tam_productos.cod_rubro);
            ViewBag.cod_marca = new SelectList(db.tam_marcas, "cod_marca", "descripcion");            
            ViewBag.cod_color = new SelectList(db.tam_colores, "cod_color", "descripcion");


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
            ViewBag.cod_marca = new SelectList(db.tam_marcas, "cod_marca", "descripcion", tam_productos.cod_marca);
            ViewBag.cod_subrubro = new SelectList(db.tam_subrubros, "cod_subrubro", "descripcion", tam_productos.cod_subrubro);
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion", tam_productos.cod_rubro);
            ViewBag.id_proveedor = new SelectList(db.tam_proveedores, "id", "nombre", tam_productos.id_proveedor);
            return View(tam_productos);
        }

        // POST: Productos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "nombre,descripcion,precio_costo,precio_venta,margen,estado,cod_marca,cod_rubro,cod_subrubro,cod_color,fecha_creacion,id,id_proveedor")] tam_productos tam_productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tam_productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_proveedor = new SelectList(db.tam_proveedores , "id", "nombre", tam_productos.id_proveedor);
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion", tam_productos.cod_rubro);
            ViewBag.cod_marca = new SelectList(db.tam_marcas, "cod_marca", "descripcion");
            ViewBag.cod_color = new SelectList(db.tam_colores, "cod_color", "descripcion");

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
