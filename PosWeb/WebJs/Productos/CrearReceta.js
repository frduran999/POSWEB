$(document).ready(function () {
    $('.combobox').combobox();
    var table = $("#tablaIngredientes");
    var html = "<thead><tr><th>Ingrediente</th><th>Cantidad</th><th>Modificar</th><th>Eliminar</th></thead>";
    table.html(html);
});
