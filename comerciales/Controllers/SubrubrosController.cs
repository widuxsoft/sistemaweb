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
    public class SubrubrosController : Controller
    {
        private db_pedidosEntities db = new db_pedidosEntities();

        // GET: Subrubros
        public ActionResult Index()
        {
            var tam_subrubros = db.tam_subrubros.Include(t => t.tamp_rubros);
            return View(tam_subrubros.ToList());
        }

        // GET: Subrubros/Details/5
        public ActionResult Details(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_subrubros tam_subrubros = db.tam_subrubros.Find(id);
            if (tam_subrubros == null)
            {
                return HttpNotFound();
            }
            return View(tam_subrubros);
        }

        // GET: Subrubros/Create
        public ActionResult Create(decimal cod_rubro)
        {
            ViewBag.cod_rubro = cod_rubro;
            return View();
        }

        // POST: Subrubros/Create
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "cod_rubro,cod_subrubro,descripcion")] tam_subrubros tam_subrubros)
        {
            if (ModelState.IsValid)
            {
                db.tam_subrubros.Add(tam_subrubros);
                db.SaveChanges();
               

                return RedirectToAction("Edit", "Rubros", new { id = Convert.ToInt64(tam_subrubros.cod_rubro) });
            }
            
            return View(tam_subrubros);
        }

        // GET: Subrubros/Edit/5
        public ActionResult Edit(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_subrubros tam_subrubros = db.tam_subrubros.Find(id);
            if (tam_subrubros == null)
            {
                return HttpNotFound();
            }
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion", tam_subrubros.cod_rubro);

            
            return View(tam_subrubros);
        }

        // POST: Subrubros/Edit/5
        // Para protegerse de ataques de publicación excesiva, habilite las propiedades específicas a las que desea enlazarse. Para obtener 
        // más información vea http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "cod_rubro,cod_subrubro,descripcion")] tam_subrubros tam_subrubros)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tam_subrubros).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Edit", "Rubros", new { id = Convert.ToInt64(tam_subrubros.cod_rubro) });
            }
            ViewBag.cod_rubro = new SelectList(db.tamp_rubros, "cod_rubro", "descripcion", tam_subrubros.cod_rubro);
            return View(tam_subrubros);
        }

        // GET: Subrubros/Delete/5
        public ActionResult Delete(decimal id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tam_subrubros tam_subrubros = db.tam_subrubros.Find(id);
            if (tam_subrubros == null)
            {
                return HttpNotFound();
            }
            return View(tam_subrubros);
        }

        // POST: Subrubros/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(decimal id)
        {
            tam_subrubros tam_subrubros = db.tam_subrubros.Find(id);
            db.tam_subrubros.Remove(tam_subrubros);
            db.SaveChanges();
            return RedirectToAction("Edit", "Rubros", new { id = Convert.ToInt64(tam_subrubros.cod_rubro) });
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
