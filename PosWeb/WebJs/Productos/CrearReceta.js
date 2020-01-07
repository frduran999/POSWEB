$(document).ready(function () {
    $('.combobox').combobox();
    var table = $("#tablaIngredientes");

    document.getElementById("agregarIngrediente").onclick = function () {
        var ingredientes = $("#Ingredientes").val();
        var cantidad = $("#Cantidad").val();
        ingredientesList.push({ IdProducto: ingredientes, Cantidad: cantidad});

        var html = "<tr><td>" + ingredientes + "</td><td>" + cantidad + "</td>" +
            "<td><button class='btn btn-xs btn-danger'>eliminar</button></td></tr>";//<button class='btn btn-xs btn-warning'>Modificar</button>
        $("#tablaIngredientes").append(html);//jquery <---
        $("#Cantidad").val("");
        $("#Ingredientesundefined").val("");
    }

    document.getElementById("CrearReceta").onclick = function () {
        var nombreReceta = $("#Receta").val();
        $.ajax({
            type: "POST",
            url: "CrearReceta",
            data: { listIngredientes: ingredientesList, _Receta: nombreReceta },
            async: true,
            success: function (data) {
                if (data > 0) {
                    alert("Se Grabo Detalle");
                    $("#tablaIngredientes").empty();
                    location.reload();
                }
                
            }
        });
    }

    document.getElementById("McrearReceta").onclick = function () {
        var htmlHead = "<thead><tr><th>Ingrediente</th><th>Cantidad</th><th>Eliminar</th></thead>";//<th>Modificar</th>
        $("#tablaIngredientes").append(htmlHead);
        $("#Cantidad").val("");
        $("#Ingredientesundefined").val("");
        $("#Receta").val("");
        ingredientesList = [];
    }
    document.getElementById("cerrarModal").onclick = function () {
        $("#tablaIngredientes").empty();
    }
    document.getElementById("cerrar").onclick = function () {
        $("#tablaIngredientes").empty();
    }
});
var ingredientesList = [];

function eliminarReceta(idReceta) {
    abrirConfirmacion('Eliminar', '¿Desea Eliminar Receta?', function () {
        $.ajax({
            type: 'POST',
            url: 'eliminarReceta',
            data: {
                _idReceta: idReceta,
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
    }, function () { }, true);
}    

function obtenerReceta(idReceta) {
    $.ajax({
        type: "GET",
        url: "obtenerReceta",
        data: { _idReceta: idReceta },
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


//var nuevaFila = document.createElement("TR");
//nuevaFila.innerHTML = html;
//document.getElementById("tablaIngredientes").append(html);//appendChild