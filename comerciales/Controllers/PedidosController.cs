using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using comerciales.Contexto;
using System.Text;

namespace comerciales.Controllers
{
    
    public class C_Tipo
    {
        public String Id { get; set; }
        public string Name { get; set; }
    }
    [Authorize]
    public class PedidosController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Pedidos
        public ActionResult Index()
        {
            var tam_pedidos = db.tam_pedidos.Include(t => t.tam_clientes).Include(t => t.tam_localidades).OrderByDescending(tb =>tb.id);
               

            return View(tam_pedidos.ToList());
        }

        // GET: Pedidos/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_pedidos tam_pedidos = db.tam_pedidos.Find(id);
            if (tam_pedidos == null)
            {
                return HttpNotFound();
            }
            return View(tam_pedidos);
        }

        // GET: Pedidos/Create
        public ActionResult Create()
        {
            ViewBag.id_cliente = new SelectList(db.tam_clientes, "id_cliente", "apellido");            
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion");
          
            return View();
        }

        // POST: Pedidos/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id_cliente,fecha_creacion,estado,fecha_finalizado,id,calle,numero,depto,piso,manzana,lote,cod_localidad")] tam_pedidos tam_pedidos)
        {
            if (ModelState.IsValid)
            {
                db.tam_pedidos.Add(tam_pedidos);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.id_cliente = new SelectList(db.tam_clientes, "id_cliente", "apellido", tam_pedidos.id_cliente);            
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion", tam_pedidos.cod_localidad);
            return View(tam_pedidos);
        }

        // GET: Pedidos/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_pedidos tam_pedidos = db.tam_pedidos.Find(id);
            if (tam_pedidos == null)
            {
                return HttpNotFound();
            }
            
            ViewBag.id_cliente = new SelectList(db.tam_clientes, "id_cliente", "apellido", tam_pedidos.id_cliente);           
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion", tam_pedidos.cod_localidad);

            return View(tam_pedidos);
        }

        // POST: Pedidos/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id_cliente,fecha_creacion,estado,fecha_finalizado,id,calle,numero,depto,piso,manzana,lote,cod_localidad")] tam_pedidos tam_pedidos)
        {
            if (ModelState.IsValid)
            {
                if (tam_pedidos.estado=="1" && tam_pedidos.fecha_finalizado == null)
                {
                    tam_pedidos.fecha_finalizado = DateTime.Now;
                }
                db.Entry(tam_pedidos).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.id_cliente = new SelectList(db.tam_clientes, "id_cliente", "apellido", tam_pedidos.id_cliente);          
            ViewBag.cod_localidad = new SelectList(db.tam_localidades, "cod_localidad", "descripcion", tam_pedidos.cod_localidad);
            return View(tam_pedidos);
        }

        // GET: Pedidos/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_pedidos tam_pedidos = db.tam_pedidos.Find(id);
            if (tam_pedidos == null)
            {
                return HttpNotFound();
            }
            return View(tam_pedidos);
        }

        // POST: Pedidos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tam_pedidos tam_pedidos = db.tam_pedidos.Find(id);
            var items = db.tar_pedidos_detall.Where(m => m.id_pedido == id);
            foreach (tar_pedidos_detall item in items)
                db.tar_pedidos_detall.Remove(item);
            db.tam_pedidos.Remove(tam_pedidos);
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
