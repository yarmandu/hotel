using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CapaLogica;
using Modelo_Entidades;
using Proyecto_Hoteleria.Models;

namespace Proyecto_Hoteleria.Controllers
{
    public class HabitacionController : Controller
    {
        // GET: Habitacion
        public ActionResult Index()
        {
            return View(CrearModelo());
        }
        private ListarHabitacionVM CrearModelo(Habitacion Item = null)
        {
            Habitacion_Logica clientelogica = new Habitacion_Logica();
            TipoHabitacion_Logica odocumento = new TipoHabitacion_Logica();
            TipoServicio_Logica osexo = new TipoServicio_Logica();

            if (Item == null)
                Item = new Habitacion();
            var listahabitacion = clientelogica.Retrieve(Item);
            var listahabitaciones = odocumento.Retrieve(new TipoHabitacion());
            var listaservicio = osexo.Retrieve(new TipoServicio());

            return new ListarHabitacionVM(Item, listahabitacion, listahabitaciones, listaservicio);
        }

        public ActionResult Buscar(Habitacion filtro)
        {
            return View("Grid", CrearModelo(filtro));
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Habitacion_Logica oClienteLogica = new Habitacion_Logica();
            TipoHabitacion_Logica odocumento = new TipoHabitacion_Logica();
            TipoServicio_Logica osexo = new TipoServicio_Logica();

            var item = (id == -1) ? new Habitacion() : oClienteLogica.Find(new Habitacion
            {
                NroHanitacion = id
            });

            var listahabitacion = odocumento.Retrieve(new TipoHabitacion());
            var listaservicio = osexo.Retrieve(new TipoServicio());

            return View(new EditarHabitacionVM(item, listahabitacion, listaservicio));
        }

        [HttpPost]
        public ActionResult Editar(Habitacion Item)
        {
            string mensajeRespuesta = "";
            Habitacion_Logica oClienteLogica = new Habitacion_Logica();
            var rpta = oClienteLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "Habitacion", new { respuesta = mensajeRespuesta });

        }

        public ActionResult Eliminar(int id)
        {
            string mensajeRespuesta = "";
            Habitacion_Logica oClienteLogica = new Habitacion_Logica();
            var rpta = oClienteLogica.Delete(new Habitacion
            {
                NroHanitacion = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "Habitacion", new { respuesta = mensajeRespuesta });

        }
    }
}