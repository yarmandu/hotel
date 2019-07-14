function iniciar() {
    debugger;
    $("#btnIngresar").on("click", ingresar);
};

function ingresar() {
    debugger;
    var parametros = {
        usuario: $("#Filtro_Usuario").val(),
        clave: $("#Filtro_Clave").val()
    };
    debugger;

    var urlInicio = ingreso.Urls.inicioUrl;
    var urlIngreso = ingreso.Urls.editarReservaUrl;
    var urlSalida = ingreso.Urls.searchReservaUrl;
    debugger;

    if ($("#Filtro_Usuario").val() == '') {
        alert('Por favor ingrese Usuario');
    }
    if ($("#Filtro_Clave").val() == '') {
        alert('Por favor ingrese Contraseña');
    }

    else {
        $.ajax({
            type: 'POST',
            dataType: 'json',
            url: urlIngreso,
            data: {filtro: parametros},                        
            success: function (data) {
                debugger;
                for (var i = 0; i < data.length; i++) {

                    if (data[i].Usuario == $("#Filtro_Usuario").val() && data[i].Clave == $("#Filtro_Clave").val()) {
                        debugger;
                        window.setTimeout(function () {
                            window.location.href = urlSalida;
                        },100);
                    }
                    else {
                        alert('usuario o contraseña inconrrecto')
                        location.href = urlInicio;

                    }
                }
            }
        });
    }
    return false;
}
