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
    public class PedidosDetalleController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: PedidosDetalle
        public ActionResult Index()
        {
            var tar_pedidos_detall = db.tar_pedidos_detall.Include(t => t.tam_pedidos).Include(t => t.tam_productos);
            return View(tar_pedidos_detall.ToList());
        }

        // GET: PedidosDetalle/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tar_pedidos_detall tar_pedidos_detall = db.tar_pedidos_detall.Find(id);
            if (tar_pedidos_detall == null)
            {
                return HttpNotFound();
            }
            return View(tar_pedidos_detall);
        }

        // GET: PedidosDetalle/Create
        public ActionResult Create(decimal id_pedido)
        {
            //ViewBag.id_pedido = new SelectList(db.tam_pedidos, "id", "estado");
            ViewBag.id_pedido = id_pedido;
            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre");
            return View();
        }

        // POST: PedidosDetalle/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_pedido,tipo,cantidad,precio,total,estado,fecha_creacion,fecha_estado,id,id_producto")] tar_pedidos_detall tar_pedidos_detall)
        {
            if (ModelState.IsValid)
            {
                tam_productos producto = db.tam_productos.Find(tar_pedidos_detall.id_producto);
                if (tar_pedidos_detall.tipo == "C")
                {
                    tar_pedidos_detall.precio = producto.precio_venta;
                }
                else
                {
                    tar_pedidos_detall.precio = producto.precio_recarga;
                }

                if (producto.precio_recarga == null)
                {
                    tar_pedidos_detall.precio = producto.precio_venta;
                    tar_pedidos_detall.tipo = "C";
                }
                tar_pedidos_detall.fecha_creacion = DateTime.Today;
                tar_pedidos_detall.estado = "0";
                tar_pedidos_detall.total = tar_pedidos_detall.precio * tar_pedidos_detall.cantidad;
                db.tar_pedidos_detall.Add(tar_pedidos_detall);
                db.SaveChanges();
                return RedirectToAction("Edit", "Pedidos", new { id = Convert.ToInt64(tar_pedidos_detall.id_pedido) });
            }

            ViewBag.id_pedido = new SelectList(db.tam_pedidos, "id", "estado", tar_pedidos_detall.id_pedido);
            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", tar_pedidos_detall.id_producto);
            return View(tar_pedidos_detall);
        }

        // GET: PedidosDetalle/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tar_pedidos_detall tar_pedidos_detall = db.tar_pedidos_detall.Find(id);
            if (tar_pedidos_detall == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_pedido = new SelectList(db.tam_pedidos, "id", "estado", tar_pedidos_detall.id_pedido);
            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", tar_pedidos_detall.id_producto);
            return View(tar_pedidos_detall);
        }

        // POST: PedidosDetalle/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_pedido,tipo,cantidad,precio,total,estado,fecha_creacion,fecha_estado,id,id_producto")] tar_pedidos_detall tar_pedidos_detall)
        {
            if (ModelState.IsValid)
            {
                tam_productos producto = db.tam_productos.Find(tar_pedidos_detall.id_producto);                  
                if (tar_pedidos_detall.tipo == "C")
                {
                    tar_pedidos_detall.precio= producto.precio_venta;
                }
                else
                {
                    tar_pedidos_detall.precio = producto.precio_recarga;
                }

                if (producto.precio_recarga==null)
                {
                    tar_pedidos_detall.precio = producto.precio_venta;
                    tar_pedidos_detall.tipo = "C";
                }
                tar_pedidos_detall.fecha_estado = DateTime.Today;
                tar_pedidos_detall.total = tar_pedidos_detall.precio * tar_pedidos_detall.cantidad;
                db.Entry(tar_pedidos_detall).State = EntityState.Modified;
                db.SaveChanges();
                
                return RedirectToAction("Edit", "Pedidos", new { id = Convert.ToInt64 (tar_pedidos_detall.id_pedido) });
            }
            ViewBag.id_pedido = new SelectList(db.tam_pedidos, "id", "estado", tar_pedidos_detall.id_pedido);
            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", tar_pedidos_detall.id_producto);
            return View(tar_pedidos_detall);
        }

        // GET: PedidosDetalle/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tar_pedidos_detall tar_pedidos_detall = db.tar_pedidos_detall.Find(id);
            if (tar_pedidos_detall == null)
            {
                return HttpNotFound();
            }
            return View(tar_pedidos_detall);
        }

        // POST: PedidosDetalle/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tar_pedidos_detall tar_pedidos_detall = db.tar_pedidos_detall.Find(id);
            db.tar_pedidos_detall.Remove(tar_pedidos_detall);
            db.SaveChanges();
            return RedirectToAction("Edit", "Pedidos", new { id = Convert.ToInt64(tar_pedidos_detall.id_pedido) });
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
