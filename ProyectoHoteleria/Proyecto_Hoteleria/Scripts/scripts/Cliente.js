function iniciar() {
    debugger;
    $("#ModalCliente").on("show.bs.modal", ejecutaModal);
    $("#btnBuscar").on("click", buscar);
};

function iniciarEditar() {
    debugger;
    $("#item_IdCliente").val();
};

function grabar() {
    var nombres = $("#Item_Nombres").val();
    var apePaterno = $("#Item_ApePaterno").val();
    var apeMaterno = $("#Item_ApeMaterno").val();
    var direccion = $("#Item_Direccion").val();
    var telefono = $("#Item_Telefono").val();
    var tipoCliente = $("#Item_IdTipoCliente").val();

    if (nombres == "") {
        alert("Ingrese Nombres");
        return false;
    }
    if (apePaterno == "") {
        alert("Ingrese Apellido Paterno");
        return false;
    }
    if (apeMaterno == "") {
        alert("Ingrese Apellido Materno");
        return false;
    }
    if (direccion == "") {
        alert("Ingrese Dirección");
        return false;
    }
    if (telefono == "") {
        alert("Ingrese Teléfono");
        return false;
    }
    if (tipoCliente == 0) {
        alert("Ingrese Tipo Cliente");
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
    modal.find(".modal-title").text("Clientes");
    var id = button.data('id');
    ObtenerPopUp(id);
    return true;
};

function ObtenerPopUp(id) {
    debugger;
    var urlEditCliente = cliente.Urls.editarClienteUrl;

    $.ajax({
        url: urlEditCliente,
        data: {
            id: id
        },
        type: 'GET'
    }).done(function (data, textStatus, jqXhr) {
        debugger;
        $("#divModalCliente").html(data);
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
    var urlBuscarCliente = cliente.Urls.searchClienteUrl;

    $.ajax({
        url: urlBuscarCliente,
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
    letras = " áéíóúabcdefghijklmnñopqrstuvwxyz.,0123456789";
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
