using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using comerciales.Clases;


namespace comerciales.Controllers
{
    public class LoginController : Controller    
    {
        Login usuario = new Login();
        // GET: Login
        public ActionResult Index()
        {
            

            return View(usuario);
        }

        public ActionResult Validar(Login model)
        {
            if (model.usuario.ToLower() =="adminenodje" && model.pass == "gestion17")
            {
               return RedirectToAction("Index","Home");
            }
            else
            {
                ViewBag.mensaje_error = "Usuario y/o contraseña incorrectos";
            }
              return RedirectToAction("index");
        }
    }
}