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
    public class ColoresProductosController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: ColoresProductos
        public ActionResult Index()
        {
            var tar_colores_productos = db.tar_colores_productos.Include(t => t.tam_colores).Include(t => t.tam_productos);
            return View(tar_colores_productos.ToList());
        }

        // GET: ColoresProductos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tar_colores_productos tar_colores_productos = db.tar_colores_productos.Find(id);
            if (tar_colores_productos == null)
            {
                return HttpNotFound();
            }
            return View(tar_colores_productos);
        }

        // GET: ColoresProductos/Create
        public ActionResult Create(decimal id_producto)
        {
            ViewBag.id_color = new SelectList(db.tam_colores, "id", "color");
            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", id_producto);
            return View();
        }

        // POST: ColoresProductos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,id_producto,id_color")] tar_colores_productos tar_colores_productos)
        {
            if (ModelState.IsValid)
            {
                db.tar_colores_productos.Add(tar_colores_productos);
                db.SaveChanges();
                return RedirectToAction("Edit", "Productos", new { id = Convert.ToInt64(tar_colores_productos.id_producto) });
            }

            ViewBag.id_color = new SelectList(db.tam_colores, "id", "color", tar_colores_productos.id_color);
            //ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", tar_colores_productos.id_producto);
            return View(tar_colores_productos);
        }

        // GET: ColoresProductos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tar_colores_productos tar_colores_productos = db.tar_colores_productos.Find(id);
            if (tar_colores_productos == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_color = new SelectList(db.tam_colores, "id", "color", tar_colores_productos.id_color);
            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", tar_colores_productos.id_producto);
            return View(tar_colores_productos);
        }

        // POST: ColoresProductos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,id_producto,id_color")] tar_colores_productos tar_colores_productos)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tar_colores_productos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Productos", new { id = tar_colores_productos.id_producto });
            }
            ViewBag.id_color = new SelectList(db.tam_colores, "id", "color", tar_colores_productos.id_color);
            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", tar_colores_productos.id_producto);
            return View(tar_colores_productos);
        }

        // GET: ColoresProductos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tar_colores_productos tar_colores_productos = db.tar_colores_productos.Find(id);
            if (tar_colores_productos == null)
            {
                return HttpNotFound();
            }
            return View(tar_colores_productos);
        }

        // POST: ColoresProductos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tar_colores_productos tar_colores_productos = db.tar_colores_productos.Find(id);
            db.tar_colores_productos.Remove(tar_colores_productos);
            db.SaveChanges();
            return RedirectToAction("Edit", "Productos", new { id = tar_colores_productos.id_producto });
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
