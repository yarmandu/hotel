using Proyecto_Hoteleria.Models.Login;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica;
using Modelo_Entidades;
using System.Threading.Tasks;

namespace Proyecto_Hoteleria.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(CrearModelo());
        }


        private ListarLoginVM CrearModelo(Login Item = null)
        {
            Login_Logica loginlogica = new Login_Logica();

            if (Item == null)
                Item = new Login();
            var listalogin = loginlogica.RetrieveUsuario(Item);

            return new ListarLoginVM(Item, listalogin);
        }

        public JsonResult Ingreso(Login filtro)
        {
            Login_Logica loginlogica = new Login_Logica();
            var datos = loginlogica.RetrieveUsuario(filtro);

            return Json(datos, JsonRequestBehavior.AllowGet);
        }


        //public ActionResult Ingreso(string usuario, string contrasenia)
        //{

        //    Login_Logica loginlogica = new Login_Logica();

        //    var item = (usuario == "") ? new Login() : loginlogica.RetrieveUsuario1(new Login
        //    {
        //        Usuario = usuario,
        //        Clave = contrasenia
        //    });

        //    var listalogin = loginlogica.RetrieveUsuario(item);
        //    if (listalogin.Count() == 0)
        //    {
        //        return RedirectToAction("Index", "Login");
        //    }
        //    else
        //    {
        //        return new ("Notificacion", "ReservaHabitacion");
        //    }
        //}

    }
}