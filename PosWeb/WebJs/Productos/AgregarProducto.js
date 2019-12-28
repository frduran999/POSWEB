﻿$(document).ready(function () {
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
            $.each(data, function (index, value) {
                $.each(this, function (name, value) {
                    $("#modProducto").val(value.Producto);
                    document.getElementById("modFamiliaundefined").value = value.Familia;
                    if (value.UnidadMedida == 'gr') {
                        value.UnidadMedida = 'Gramos';
                    } else {
                        value.UnidadMedida = 'Receta';
                    }
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
    });
}

function EliminarProducto(IdProducto) {
    var mensaje;
    var opcion = confirm("Desea Eliminar Producto?");
    if (opcion == true) {
        $.ajax({
            type: 'POST',
            url: 'EliminarProducto',
            data: {
                _IdProducto: IdProducto,
            },
            success: function (data) {
                if (data.Verificador) {
                    alert(data.Mensaje);
                    location.reload();
                }
                else {
                    alert("Usuario No Encontrado");
                }
            }
        });
    }
    else {
        mensaje = "Has clickado Cancelar";
    }
}

function ModificarProducto() {
    var producto = $("#modProducto").val();
    var idfamilia = $("#modFamilia").val();
    var umedida = $("#modUmedida").val();
    var precio = $("#modPrecio").val();
    var idproducto = $("#IdProducto").val();
    var receta = $("#modReceta").val();
    if (receta == 'SinReceta' || receta == '') {
        receta = 0;
    }
    $.ajax({
        type: "POST",
        url: "EditarProducto",
        data: { _IdProducto: idproducto, _Producto: producto, _IdFamilia: idfamilia, _Umedida:umedida, _Precio:precio},
        async: true,
        success: function (data) {
            if (data = 1) {
                alert("Producto fue Editado");
                location.reload();
            }
            else {
                alert("NO");
            }
        }
    });
}