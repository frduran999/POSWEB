$(document).ready(function () {
    var tablaMesas = $("#tablaMesas");
    var cont = 0;
    for (var i = 1; i < 3; i++) {
        var htmlMesas = "<tr id='linea" + i + "'>";
        for (var j = 0; j < 4; j++) {
            cont += 1;
            htmlMesas += "<td><button id='mesa" + cont + "' class='btn-lg btn btn - primary myButton' onclick='guardarMesa("+cont+")'>mesa " + cont + "</button></td>";
        }
        htmlMesas += "</tr>";
        tablaMesas.append(htmlMesas);
    }
    $("#modalMesas").show();
    
    var tablaFamilia = $("#tablaFamilia");
    $("#tablaDetalle").html("");
    $.ajax({
        type: "GET",
        url: "grillaFamilia",
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("Error");
            } else {
                $("#tablaFamilia").html("");
                $.each(data.list, function (index, value) {
                    var familia = value.Familia.replace(" ","");
                    var htmlBotones = "<tr><td>" +
                        "<button value='" + value.IdFamilia + "' class='form-control btn btn-primary btn-xs' onclick='getProductos("+value.IdFamilia+")'" +
                        "id='"+familia+"' > " + value.Familia + "</button ></td ></tr>";
                    tablaFamilia.append(htmlBotones);
                });
            }
        }
    });

    //--- MODAL ---- OPC.CAja-----
    document.getElementById("modalOpciones").onclick = function () {
        $("#montoApertura").val("");
        $("#glosaApertura").val("");
        $("#montoRetiro").val("");
        $("#glosaRetiro").val("");
        $("#glosaCierre").val("");
    }

    document.getElementById("aperturaCaja").onclick = function () {
        $("#modalApertura").show();
        $("#modalRetiro").hide();
        $("#modalCierre").hide();
        $("#montoApertura").val("");
        $("#glosaApertura").val("");
    }

    document.getElementById("retirarCaja").onclick = function () {
        $("#modalRetiro").show();
        $("#modalApertura").hide();
        $("#modalCierre").hide();
        $("#montoRetiro").val("");
        $("#glosaRetiro").val("");
    }

    document.getElementById("cerrarCaja").onclick = function () {
        $("#modalCierre").show();
        $("#modalRetiro").hide();
        $("#modalApertura").hide();
        $("#glosaCierre").val("");
    }
    //--- MODAL ---- OPC.CAja-----

    //--- FUNCIONES CAJA ----------
    document.getElementById("abrirCaja").onclick = function () {
        var montoApertura = $("#montoApertura").val();
        var glosaApertura = $("#glosaApertura").val();
        $.ajax({
            type: "POST",
            url: "aperturaCaja",
            data: { _montoApertura: montoApertura, _glosaApertura: glosaApertura },
            async: true,
            success: function (data) {
                if (data > 0) {
                    alert("Caja Abierta. Num°: " + data);
                    location.reload();
                }
                else {
                    alert("Caja Abierta");
                }
                if (data == -1) {
                    alert("Debe llenar datos obligatorios");
                }
            }
        });
    }

    document.getElementById("retiroCaja").onclick = function () {
        var montoRetiro = $("#montoRetiro").val();
        var glosaRetiro = $("#glosaRetiro").val();
        $.ajax({
            type: "POST",
            url: "retiroCaja",
            data: { _montoRetiro: montoRetiro, _glosaRetiro: glosaRetiro },
            async: true,
            success: function (data) {
                if (data == 1) {
                    alert("hola");
                }
            }
        });
    }

    document.getElementById("cierreCaja").onclick = function () {
        var glosaCierre = $("#glosaCierre").val();
        $.ajax({
            type: "POST",
            url: "cierreCaja",
            data: { _glosaCierre: glosaCierre },
            async: true,
            success: function (data) {
                if (data == 1) {
                    alert("hola");
                }
            }
        });
    }
    //--- FUNCIONES CAJA ----------
    

});

function getProductos(idFamilia) {
    var tablaProductos = $("#tablaProductos");
    var htmlProductos = "<tr>";
    tablaProductos.append(htmlProductos);
    $.ajax({
        type: "GET",
        url: "grillaProductos",
        data: { _idFamilia: idFamilia },
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("Error");
            }
            else {
                $("#tablaProductos").html("");
                $.each(data.list, function (index, value) {
                    var producto = value.Producto.replace(" ", "");
                    var htmlBotonesProd = "<td>" +
                        "<button value='" + value.IdProducto + "' class='form-control btn btn-primary' onclick='detalleVenta(" + value.IdProducto + ")'" +
                        "id='" + producto + "' > " + value.Producto + "</button ></td >";
                    tablaProductos.append(htmlBotonesProd);
                });
                htmlProductos = "</tr>"
                htmlBotonesProd.append(htmlProductos);
            }
        }
    });
}

var linea = 1;
var total = 0;
var dataDetalle = [];
function detalleVenta(idProducto) {
    var tablaDetalle = $("#tablaDetalle");
    var cantidad = 1;
    var htmlGrillaDetalle = "";
    $.ajax({
        type: "POST",
        url: "detalleVenta",
        data: { _idProducto: idProducto },
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("Error");
            } 
            else {
                $.each(data.list, function (index, value) {
                    dataDetalle.push({ IdProducto: value.IdProducto, Cantidad: cantidad, Linea: linea });

                    var totalLinea = value.Precio * cantidad;
                    htmlGrillaDetalle += "<tr id='linea" + linea + "'><td>" + value.IdProducto + "</td>" +
                        "<td>" + value.Producto + "</td><td>" + cantidad + "</td>" +
                        "<td>" + value.UnidadMedida + "</td><td id='precio" + linea + "'>" + value.Precio + "</td>" +
                        "<td>" + totalLinea + "</td>" +
                        "<td><button class='btn btn-xs btn-danger' onclick='eliminarFila(" + linea + ")'>Eliminar</button></td></tr>";
                    linea++;
                    tablaDetalle.append(htmlGrillaDetalle);
                    total += totalLinea; 
                    $("#total").html("$" + total);
                    $("#propina").html("$" + (total / 10));
                    $("#totalPropina").html("$" + (total + (total / 10)));
                });
            }
        }
    });
}

function eliminarFila(linea) {
    var totalLinea = $("#precio" + linea).html();
    total -= parseInt(totalLinea);
    var propina = total / 10;
    var totalPropina = total + propina;
    $("#total").html("$" + total);
    $("#propina").html("$" + propina);
    $("#totalPropina").html("$" + totalPropina);
    dataDetalle.splice(dataDetalle.findIndex(v => v.Linea === linea), 1);
    //dataDetalle.splice(linea,1);
    $('#linea' + linea).remove();
}

function cerrarModal() {
    $("#modalMesas").hide();
}

var numeroMesa = 0;
function guardarMesa(numMesa) {
    numeroMesa = numMesa;
    $("#numMesa").html("&nbsp;N° Mesa: ("+numMesa+")");
    $("#numMesa").show();
    $("#modalMesas").hide();
}