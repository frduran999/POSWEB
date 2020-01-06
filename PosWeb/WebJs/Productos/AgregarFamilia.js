$(document).ready(function () {
    $('.combobox').combobox();

    $("#CrearFamilia").click(function () {
        var receta = 0;
        var familia = $("#Familia").val();
        var impresora = $("#Impresora").val();
        var check = document.getElementById("TipoProd").checked;
        console.log(check);
        if (check) {
           receta = 1;
        }
        else {
            receta = 0;
        }

        $.ajax({
            type: "POST",
            url: "AgregarFamilia",
            data: {
                _Familia: familia,
                _Impresora: impresora,
                _Receta:receta
            },
            async: true,
            success: function (data) {
                try {
                    if (data.Verificador !== undefined) {
                        if (data == 0) {
                            $("#modalErrorLoginMensaje").html("Debe Ingresar Campos Obligatorios");
                            $("#aModalErrorLogin").click();
                            return;
                        }
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

<<<<<<< HEAD
//prueba
//prueba2
=======
>>>>>>> fco
function ObtenerDatosFamilia(IdFamilia) {
    $("#modImpresoraundefined").empty();
    $.ajax({
        type: "GET",
        url: "ObtenerFamilia",
        data: { _IdFamilia: IdFamilia },
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("Error");
            } else {
                $.each(data, function (index, value) {
                    $.each(this, function (name, value) {
                        $("#modFamilia").val(value.Familia);
                        document.getElementById("modImpresoraundefined").value = value.Impresora;
                        $("#IdFamilia").val(value.IdFamilia);
                        if (value.Receta > 0) {
                            document.getElementById("modTipoProd").checked = 1;
                        }
                    });
                });
            }
        }
    });
}

function EliminarFamilia(IdFamilia) {
    abrirConfirmacion('Eliminar', '¿Desea Eliminar Familia?', function () {
        $.ajax({
            type: 'POST',
            url: 'EliminarFamilia',
            data: {
                _IdFamilia: IdFamilia,
            },
            success: function (data) {
                if (data == 0) {
                    return;
                }
                if (data.Verificador) {
                    location.reload();
                }
                else {
                    alert("Usuario No Encontrado");
                }
            }
        });
    },function(){},true);
}

function ModificarFamilia() {
    var familia = $("#modFamilia").val();
    var idFamilia = $("#IdFamilia").val();
    var impresora = $("#modImpresoraundefined").val();
    var check = document.getElementById("modTipoProd").checked;
    var receta = 0;
    if (check) {
        receta = 1;
    }
    $.ajax({
        type: "POST",
        url: "EditarFamilia",
        data: { _Familia: familia, _IdFamilia: idFamilia, _Impresora: impresora,_Receta:receta},
        async: true,
        success: function (data) {
            if (data = 1) {
                alert("Familia fue Editado");
                location.reload();
            }
            if (data = 2) {
                alert("Familia no Encontrada");
            }
            if (data = 0) {
                alert("Debe Ingresar Datos Debe COmpletar los Datos");
            }
        }
    });
}