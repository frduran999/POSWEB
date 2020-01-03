$(document).ready(function () {
    $('.combobox').combobox();
    var table = $("#tablaIngredientes");

    document.getElementById("agregarIngrediente").onclick = function () {
        var ingredientes = $("#Ingredientes").val();
        var cantidad = $("#Cantidad").val();
        ingredientesList.push({ IdReceta: ingredientes, Cantidad: cantidad});

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
                $("#tablaIngredientes").empty();
                location.reload();
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
    




//var nuevaFila = document.createElement("TR");
//nuevaFila.innerHTML = html;
//document.getElementById("tablaIngredientes").append(html);//appendChild