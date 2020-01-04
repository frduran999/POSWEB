$(document).ready(function () {
    $('.combobox').combobox();

    $("#CrearProducto").click(function () {
        var receta = 0;
        var producto = $("#Producto").val();
        var familia = $("#Familia").val();
        var umedida = $("#Umedida").val();
        var precio = $("#Precio").val();
        if ($("#Receta").val() != 0) {
            receta = $("#Receta").val();
        }
        $.ajax({
            type: "POST",
            url: "AgregarProductos",
            data: {_Producto:producto,_Familia: familia,
                _Umedida:umedida,_Precio:precio,_Receta:receta},
            async: true,
            success: function (data) {
                try {
                    if (data.Verificador !== undefined) {
                        if (!data.Verificador) {
                            $("#modalErrorLoginMensaje").html(data.Mensaje);
                            $("#aModalErrorLogin").click();
                            return;
                        }
                        else {
                            $("#modalErrorLoginMensaje").html(data.Mensaje);
                            $("#aModalErrorLogin").click();
                            location.reload();
                        }
                    }
                }
                catch (e) { }
            },
            error: function (a, b, c) {
                console.log(a, b, c);
            }
        });
    });
});

function ObtenerProductos(IdProducto) {
    $("#modFamiliaundefined").empty();
    $("#modUmedidaundefined").empty();
    $("#modRecetaundefined").empty();

    $.ajax({
        type: "GET",
        url: "ObtenerProductos",
        data: { _IdProducto: IdProducto },
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("Debe Ingresar Campos Obligatorios");
            } else {
                $.each(data, function (index, value) {
                    $.each(this, function (name, value) {
                        $("#modProducto").val(value.Producto);
                        $("#modFamilia").value = value.Familia;
                        document.getElementById("modFamiliaundefined").value = value.Familia;
                        document.getElementById("modUmedidaundefined").value = value.UnidadMedida;
                        $("#modPrecio").val(value.Precio);
                        if (value.Receta == undefined) {
                            value.Receta = 'SinReceta';
                        }
                        document.getElementById("modRecetaundefined").value = value.Receta;
                        $("#IdProducto").val(value.IdProducto);
                    });
                });
            }
        }
    });
}

function EliminarProducto(IdProducto) {
    abrirConfirmacion('Eliminar', '¿Desea Eliminar Producto?', function () {
        $.ajax({
            type: 'POST',
            url: 'EliminarProducto',
            data: {
                _IdProducto: IdProducto,
            },
            success: function (data) {
                if (data.Verificador) {
                    location.reload();
                }
            }
        });

    }, true);
};

function ModificarProducto() {
    var producto = $("#modProducto").val();
    var familia = $("#modFamiliaundefined").val();
    var umedida = $("#modUmedidaundefined").val();
    var precio = $("#modPrecio").val();
    var idproducto = $("#IdProducto").val();
    var receta = $("#modReceta").val();
    if (receta == 'SinReceta' || receta == '') {
        receta = 0;
    }
    $.ajax({
        type: "POST",
        url: "EditarProducto",
        data: { _IdProducto: idproducto, _Producto: producto, _Familia: familia, _Umedida:umedida, _Precio:precio},
        async: true,
        success: function (data) {
            if (data = 1) {
                alert("Producto fue Editado");
                location.reload();
            }
            if (data = 2) {
                alert("Error");
            }
            if (data = 0) {
                alert("Debe Completar Los Datos");
            }
        }
    });
}