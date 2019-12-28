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