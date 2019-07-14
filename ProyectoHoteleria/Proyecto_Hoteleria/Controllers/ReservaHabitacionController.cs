using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Modelo_Entidades;
using CapaLogica;
using Proyecto_Hoteleria.Models.ReservaVM;

namespace Proyecto_Hoteleria.Controllers
{
    public class ReservaHabitacionController : Controller
    {
        // GET: ReservaHabitacion
        public ActionResult Index()
        {
            return View(CrearModelo());
        }

        private ListarReservaVM CrearModelo(ReservaHabitacion Item = null)
        {
            ReservaHabitacion_Logica reservalogica = new ReservaHabitacion_Logica();
            TipoHabitacion_Logica ohabitacion = new TipoHabitacion_Logica();
            TipoPago_Logica opago = new TipoPago_Logica();

            if (Item == null)
                Item = new ReservaHabitacion();
            var listareservahabitacion = reservalogica.Retrieve(Item);
            var listahabitaciones = ohabitacion.Retrieve(new TipoHabitacion());
            var listapago = opago.Retrieve(new TipoPago());

            return new ListarReservaVM(Item, listareservahabitacion, listapago, listahabitaciones);
        }

        public ActionResult Buscar(ReservaHabitacion filtro)
        {
            return View("Grid", CrearModelo(filtro));
        }

        [HttpGet]
        public ActionResult Editar(int id, int estado)
        {
            ReservaHabitacion_Logica oReservaLogica = new ReservaHabitacion_Logica();
            TipoHabitacion_Logica ohabitacion = new TipoHabitacion_Logica();
            TipoPago_Logica opago = new TipoPago_Logica();
            TipoDocumento_Logica odocumento = new TipoDocumento_Logica();

            var item = (id == -1) ? new ReservaHabitacion() : oReservaLogica.Find(new ReservaHabitacion
            {
                idReserva = id,
                estado = estado
            });

            var listahabitacion = ohabitacion.Retrieve(new TipoHabitacion());
            var listapago = opago.Retrieve(new TipoPago());
            var listadocumento = odocumento.Retrieve(new TipoDocumento());

            return View(new EditarReservaVM(item, listapago, listahabitacion,listadocumento));
        }

        [HttpPost]
        public ActionResult Editar(ReservaHabitacion Item)
        {
            string mensajeRespuesta = "";
            ReservaHabitacion_Logica oReservaLogica = new ReservaHabitacion_Logica();
            var rpta = oReservaLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "ReservaHabitacion", new { respuesta = mensajeRespuesta });

        }

        public ActionResult Notificacion()
        {
            return View(CrearModeloNotificacion());
        }

        private ListarReservaVM CrearModeloNotificacion(ReservaHabitacion Item = null)
        {
            ReservaHabitacion_Logica reservalogica = new ReservaHabitacion_Logica();
            TipoHabitacion_Logica ohabitacion = new TipoHabitacion_Logica();
            TipoPago_Logica opago = new TipoPago_Logica();

            if (Item == null)
                Item = new ReservaHabitacion();
            var listareservahabitacion = reservalogica.ListarNotificacion(Item);
            var listahabitaciones = ohabitacion.Retrieve(new TipoHabitacion());
            var listapago = opago.Retrieve(new TipoPago());

            return new ListarReservaVM(Item, listareservahabitacion, listapago, listahabitaciones);
        }


        public ActionResult AprobarReserva(int id)
        {
            string mensajeRespuesta = "";
            ReservaHabitacion_Logica oReservaLogica = new ReservaHabitacion_Logica();
            var rpta = oReservaLogica.AprobarNotificacion(new ReservaHabitacion
            {
                idReserva = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se Aprobó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Notificacion", "ReservaHabitacion", new { respuesta = mensajeRespuesta });

        }


        public ActionResult Eliminar(int id)
        {
            string mensajeRespuesta = "";
            ReservaHabitacion_Logica oReservaLogica = new ReservaHabitacion_Logica();
            var rpta = oReservaLogica.Delete(new ReservaHabitacion
            {
                idReserva = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "ReservaHabitacion", new { respuesta = mensajeRespuesta });

        }

        public ActionResult DesaprobarReserva(int id)
        {
            string mensajeRespuesta = "";
            ReservaHabitacion_Logica oReservaLogica = new ReservaHabitacion_Logica();
            var rpta = oReservaLogica.Delete(new ReservaHabitacion
            {
                idReserva = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se desaprobó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Notificacion", "ReservaHabitacion", new { respuesta = mensajeRespuesta });

        }


    }
}