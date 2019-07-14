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
    public class ClienteController : Controller
    {
        // GET: Cliente
        public ActionResult Index()
        {
            return View(CrearModelo());

        }

        private ListarClienteVM CrearModelo(Cliente Item = null)
        {
            Cliente_logica clientelogica = new Cliente_logica();

            if (Item == null)
                Item = new Cliente();
            var listaWhite = clientelogica.Retrieve(Item);

            return new ListarClienteVM(Item, listaWhite);
        }
        
        public ActionResult Buscar(Cliente filtro)
        {
            return View("Grid", CrearModelo(filtro));
        }

        [HttpGet]
        public ActionResult Editar(int id)
        {
            Cliente_logica oClienteLogica = new Cliente_logica();
            TipoDocumento_Logica odocumento = new TipoDocumento_Logica();
            TipoSexo_Logica osexo = new TipoSexo_Logica();
            TipoCliente_Logica otipocliente = new TipoCliente_Logica();
            TipoResidencia_Logica oresidencia = new TipoResidencia_Logica();

            var item = (id == -1) ? new Cliente() : oClienteLogica.Find(new Cliente
            {
                IdCliente = id
            });

            var listadocumentos = odocumento.Retrieve(new TipoDocumento());
            var listasexo = osexo.Retrieve(new Sexo());
            var listatipoCliente = otipocliente.Retrieve(new TipoCliente());
            var listaresidencia = oresidencia.Retrieve(new Residencia());

            return View(new EditarClienteVM(item, listadocumentos, listasexo, listatipoCliente, listaresidencia));
        }

        [HttpPost]
        public ActionResult Editar(Cliente Item)
        {
            string mensajeRespuesta = "";
            Cliente_logica oClienteLogica = new Cliente_logica();
            var rpta = oClienteLogica.Edit(Item);
            if (rpta == 2)
                mensajeRespuesta = "Se modificó correctamente el registro";
            else if (rpta == 1)
                mensajeRespuesta = "Se agregó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "Cliente", new { respuesta = mensajeRespuesta });

        }

        public ActionResult Eliminar(int id)
        {
            string mensajeRespuesta = "";
            Cliente_logica oClienteLogica = new Cliente_logica();
            var rpta = oClienteLogica.Delete(new Cliente
            {
                IdCliente = id
            });

            if (rpta > 0)
                mensajeRespuesta = "Se eliminó correctamente el registro";
            else
                mensajeRespuesta = "Ocurrió un error";

            return RedirectToAction("Index", "Cliente", new { respuesta = mensajeRespuesta });

        }
    }
}