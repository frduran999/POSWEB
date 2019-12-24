$(document).ready(function () {

    $("#CrearFamilia").click(function () {
        var familia = $("#Familia").val();
        var impresora = $("#Impresora").val();

        $.ajax({
            type: "POST",
            url: "AgregarFamilia",
            data: {
                _Familia: familia,
                _Impresora: impresora
            },
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
                            //TablaFamilia(data.NumInt);
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

function ObtenerDatosFamilia(IdFamilia) {
    $("#modImpresora").empty();
    $.ajax({
        type: "GET",
        url: "ObtenerFamilia",
        data: { _IdFamilia: IdFamilia },
        async: true,
        success: function (data) {
            $.each(data, function (index, value) {
                $.each(this, function (name, value) {
                    $("#modFamilia").val(value.Familia);
                    $("#modImpresora").append('<option value="' + value.Impresora + '">'+value.Impresora+'</option>');
                });
            });
        }
    });
}

function EliminarFamilia(IdFamilia, Estado) {
    var mensaje;
    var opcion = confirm("Desea Eliminar Familia?");
    if (opcion == true) {
        $.ajax({
            type: 'POST',
            url: 'EliminarFamilia',
            data: {
                _IdFamilia: IdFamilia,
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







//function TablaFamilia(IdFamilia) {
//    $.ajax({
//        type: 'GET',
//        url: "ConsultaContratos2",
//        data: {
//            _IdContrato: idContrato
//        },
//        success: function (data) {

//            var table = $("#tbladeproductos");
//            var html = "<thead><tr><th>Nro Servicio</th><th>Servicio</th><th>Ruta</th><th>Unidad Medida</th><th>Valor</th></thead>";

//            $.each(data, function (index, value) {

//                $.each(this, function (name, value) {
//                    html += "<tr><td>" + value.IdServicio + "</td><td>" + value.Servicio + "</td><td>" + value.Ruta + "</td><td>" + value.UnidadMedida + "</td><td>" + value.Valor + "</td></tr>";
//                });
//            });

//            table.html(html);

//            $("#txtRuta").val("");
//            $("#txtCantidad").val("");
//            $("#txtValor").val("");
//            $("#txtDetalle").val("");
//            $("#UnidadMedida").val("");
//            $("#TxtIdContrato").val(idContrato);
//            $("#txtServicio").val("");

//        }
//    });
//}