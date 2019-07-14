function iniciar() {
    debugger;
    $("#ModalReserva").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};

function iniciarEditar() {
    debugger;
    $("#item_idReserva").val();
};

function grabar() {
    var nombres = $("#Item_fechaInicio").val();
    var apePaterno = $("#Item_fechaFin").val();
    var apeMaterno = $("#Item_Precio").val();
    var direccion = $("#Item_precioTotal").val();
    var telefono = $("#Item_total").val();
    var tipoCliente = $("#Item_cantHabitacion").val();
    var dniCliente = $("#Item_dniCliente").val();

    //obtener fecha actual
    var hoy = new Date();
    dia = hoy.getDate();
    mes = hoy.getMonth();
    anio = hoy.getFullYear();
    fecha_actual = String(dia + "/" + mes + "/" + anio);
    fecha_actual = new Date(fecha_actual);
    //alert(fecha_actual);


    if (nombres < fecha_actual) {
        alert("Ingrese Fecha Inicio Válido");
        return false;
    }
    if (apePaterno < fecha_actual) {
        alert("Ingrese Fecha Fin Válido");
        return false;
    }
    if (apeMaterno == 0.0) {
        alert("Ingrese Precio");
        return false;
    }
    if (direccion == 0.0) {
        alert("Ingrese Precio Total");
        return false;
    }
    if (telefono == 0.0) {
        alert("Ingrese Total");
        return false;
    }
    if (tipoCliente == 0) {
        alert("Ingrese Cantidad de Habitación");
        return false;
    }


    if (dniCliente =0) {
        alert("Ingrese DNI");
        return false;
    }

    else
        return true;
}

function ejecutaModal(event) {
    debugger;
    $(this).find('.modal-content').css({
        width: 'auto',
        height: 'auto',
        'max-height': '100%'
    });

    var modal = $(this);
    var button = $(event.relatedTarget);
    modal.find(".modal-title").text("Reservas");
    var id = button.data('id');
    var estado = button.data('estado');
    ObtenerPopUp(id,estado);
    return true;
};

function ObtenerPopUp(id,estado) {
    debugger;
    var urlEditReserva = reserva.Urls.editarReservaUrl;

    $.ajax({
        url: urlEditReserva,
        data: {
            id: id,
            estado:estado
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        debugger;
        $("#divModalReserva").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        debugger;
        console.log(data);
    });
    return false;
};

function buscar() {
    debugger;

    var filtro = {
        descTipoDoc: $("#Filtro_descTipoDoc").val()
    };
    var urlBuscarReserva = reserva.Urls.searchReservaUrl;

    $.ajax({
        url: urlBuscarReserva,
        data: {
            filtro: filtro
        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        console.log(data);
    });
    return false;
}

function soloNumeros(e) {
    key = e.keyCode || e.which;
    teclado = String.fromCharCode(key);
    numeros = "0123456789";
    especiales = "8-37-38-46";
    teclado_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            teclado_especial = true;
        }
    }
    if (numeros.indexOf(teclado) == -1 && !teclado_especial) {
        return false;
    }
}

function soloLetras(e) {
    key = e.keyCode || e.which;
    tecla = String.fromCharCode(key).toLowerCase();
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz.,";
    especiales = "8-44-46-127";
    tecla_especial = false;

    for (var i in especiales) {
        if (key == especiales[i]) {
            tecla_especial = true;
            break;
        }
    }

    if (letras.indexOf(tecla) == -1 && !tecla_especial) {
        return false;
    }
}
