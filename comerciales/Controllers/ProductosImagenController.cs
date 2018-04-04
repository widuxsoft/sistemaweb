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
    public class ProductosImagenController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: ProductosImagen
        public ActionResult Index()
        {
            var tap_productos_imagen = db.tap_productos_imagen.Include(t => t.tam_productos);
            return View(tap_productos_imagen.ToList());
        }

        // GET: ProductosImagen/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tap_productos_imagen tap_productos_imagen = db.tap_productos_imagen.Find(id);
            if (tap_productos_imagen == null)
            {
                return HttpNotFound();
            }
            return View(tap_productos_imagen);
        }

        // GET: ProductosImagen/Create
        public ActionResult Create(int id_Producto)
        {
            ViewBag.id_producto = id_Producto;
            return View();
        }

        // POST: ProductosImagen/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(tap_productos_imagen tap_productos_imagen,string id_producto, HttpPostedFileBase file)
        {
           
                if (file != null && file.ContentLength > 0)
                {
                    string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
                
                    tap_productos_imagen.nombre_archivo = archivo;
                    tap_productos_imagen.fecha_creacion = DateTime.Today;
                    tap_productos_imagen.id_producto = Int32.Parse(id_producto);
                    db.tap_productos_imagen.Add(tap_productos_imagen);
                    db.SaveChanges();
                    file.SaveAs(Server.MapPath("~/Uploads/" + archivo));
                }

            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", tap_productos_imagen.id_producto);
            return RedirectToAction("Index");
            //return View(tap_productos_imagen);
        }

        // GET: ProductosImagen/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tap_productos_imagen tap_productos_imagen = db.tap_productos_imagen.Find(id);
            if (tap_productos_imagen == null)
            {
                return HttpNotFound();
            }
            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", tap_productos_imagen.id_producto);
            return View(tap_productos_imagen);
        }

        public ActionResult GetImage(string name)
        {
            string path = Server.MapPath("~/images/"+name);
            byte[] imageByteData = System.IO.File.ReadAllBytes(path);
            return File(imageByteData, "image/png");
        }

        // POST: ProductosImagen/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_imagen,nombre_archivo,principal,fecha_creacion,id,id_producto")] tap_productos_imagen tap_productos_imagen)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tap_productos_imagen).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_producto = new SelectList(db.tam_productos, "id", "nombre", tap_productos_imagen.id_producto);
            return View(tap_productos_imagen);
        }

        // GET: ProductosImagen/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tap_productos_imagen tap_productos_imagen = db.tap_productos_imagen.Find(id);
            if (tap_productos_imagen == null)
            {
                return HttpNotFound();
            }
            return View(tap_productos_imagen);
        }

        // POST: ProductosImagen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tap_productos_imagen tap_productos_imagen = db.tap_productos_imagen.Find(id);
            db.tap_productos_imagen.Remove(tap_productos_imagen);
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

        [HttpPost]
        public void SubirImagen(HttpPostedFileBase file)
        {
            if (file == null)
            {
                return;
            }
            string archivo = (DateTime.Now.ToString("yyyyMMddHHmmss") + "-" + file.FileName).ToLower();
            file.SaveAs(Server.MapPath("~/Imagenes/" + archivo));
        }
    }
}
