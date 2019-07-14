function iniciarHabitacion() {
    debugger;
    $("#ModalHabitacion").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};

function iniciarEditarHabitacion() {
    debugger;
    $("#item_NroHabitacion").val();
};

function grabar() {
    var precio = $("#Item_precio").val();
    var CantCama = $("#Item_cantCamas").val();

    if (precio == 0) {
        alert("Ingrese Precio");
        return false;
    }
    if (CantCama == 0) {
        alert("Ingrese Cantidad de Camas");
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
    modal.find(".modal-title").text("Habitaciones");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};

function ObtenerPopUp(id) {
    debugger;
    var urlEditHabitacion = habitacion.Urls.editarhabitacionUrl;

    $.ajax({
        url: urlEditHabitacion,
        data: {
            id: id
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        debugger;
        $("#divModalHabitacion").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        debugger;
        console.log(data);
    });
    return false;
};

function buscar() {
    debugger;

    var filtro = {
        tipoHabitacion: $("#Filtro_idTipoHabitacion").val(),
        tipoServicio: $("#Filtro_idtipoServicio").val(),
        precio: $("#Filtro_precio").val(),
        cantCamas: $("#Filtro_cantCamas").val()
    };
    var urlBuscarHabitacion = habitacion.Urls.searchhabitacionUrl;
    debugger;
    $.ajax({
        url: urlBuscarHabitacion,
        data: {
            filtro: filtro            
        },
        type: 'POST'
    }).done(function (data, textStatus, jqXhr) {
        debugger;
        $("#divGrid").html(data);
    }).fail(function (data, textStatus, jqXhr) {
        debugger;
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
