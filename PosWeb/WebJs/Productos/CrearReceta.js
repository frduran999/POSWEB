$(document).ready(function () {
    $('.combobox').combobox();

    var table = $("#tablaIngredientes");
    var htmlHead = "<thead><tr><th>Ingrediente</th><th>Cantidad</th><th>Modificar</th><th>Eliminar</th></thead>";
    table.html(htmlHead);

    document.getElementById("agregarIngrediente").onclick = function () {
        var arrayHtml = new Array();
        var nombreReceta = $("#Receta").val();
        var ingredientes = $("#Ingredientes").val();
        //var nombre = document.getElementById("Ingredientes").innerText;
        var cantidad = $("#Cantidad").val();

        var html = "<tr><td>" + ingredientes + "</td><td>" + cantidad + "</td>"+
            "<td><button class='btn btn-xs btn-warning'>Modificar</button></td><td><button class='btn btn-xs btn-danger'>eliminar</button></td></tr>";
        
        var nuevaFila = document.createElement("TR");
        nuevaFila.innerHTML = html;
        document.getElementById("tablaIngredientes").appendChild(nuevaFila);
        $("#Cantidad").val("");
        $("#Ingredientesundefined").val("");
    }

    document.getElementById("CrearReceta").onclick = function () {
        var tablaDom = document.getElementById("tablaIngredientes");
        var objTd = tablaDom.querySelectorAll("td");
        var objTr = tablaDom.querySelectorAll("tr");

        var nombreReceta = $("#Receta").val();

        for (var i = 0; i < objTr.length; i++) {
            var idIngrediente = objTd[i].firstChild.nodeValue;
            var cantidad = objTd[i].firstChild.nodeValue;
            console.log(nombreReceta, " Ing: " + idIngrediente, "cant: " + cantidad);
        }
        console.log(table);
    }
});

