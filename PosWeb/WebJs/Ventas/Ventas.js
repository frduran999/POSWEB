$(document).ready(function () {
    var tablaMesas = $("#tablaMesas");
    var cont = 0;
    var htmlMesas = "";
    $.ajax({
        type: "GET",
        url: "obtenerMesa",
        data: {},
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("Error");
            } else {
                $.each(data.list, function (index, value) {
                    if (index == 0 || index == 4 || index == 8 || index == 12 || index == 16 || index == 20) {
                        htmlMesas += "<tr id='linea" + value.Numero + "'>";
                    }
                    htmlMesas += "<td><button id='mesa" + value.Numero + "' class='btn-lg btn btn - primary myButton'" +
                        "onclick = 'guardarMesa(" + value.Numero + ")' > mesa " + value.Numero + "</button ></td > ";
                    if (index == 3 || index == 7 || index == 11 || index == 15 || index == 19) {
                        htmlMesas += "</tr>";
                    }
                });
                tablaMesas.append(htmlMesas);
            }
        }
    });    
        
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

    document.getElementById("guardarVenta").onclick = function () {
        var totalPropina = $("#totalPropina").html();
        var Propina = $("#propina").html();
        dataCabecera.push({ NumMesa: numeroMesa, IdGarzon: idGarzon, Total: total, Propina: Propina })
        if (total < 0 || total == "" && idGarzon == 0 || idGarzon == '') {
            alert("Debe ingresar productos o Ingresar Garzon");
        } else {
            //alert("Generar Venta: " + totalPropina);
            $.ajax({
                type: "POST",
                url: "generaVenta",
                data: { detalleVenta: dataDetalle,cabeceraVenta:dataCabecera},
                async: true,
                success: function (data) {

                }
            });
        }
    }

});

var idGarzon = 1;


function getProductos(idFamilia) {
    var tablaProductos = $("#tablaProductos");
    var htmlBotonesProd = "";
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
                    if (index == 0 || index == 2 || index == 4 || index == 6 || index == 8 || index == 10 ) {
                        htmlBotonesProd += "<tr>";
                    }
                    htmlBotonesProd += "<td><button value='" + value.IdProducto + "' class='form-control btn btn-primary' onclick='detalleVenta(" + value.IdProducto + ")'" +
                        "id='" + producto + "' > " + value.Producto + "</button ></td >";
                    if (index == 1 || index == 3 || index == 5 || index == 7 || index == 9 || index == 11) {
                        htmlBotonesProd += "</tr>";
                    }  
                });
                tablaProductos.append(htmlBotonesProd);
            }
        }
    });
}

var linea = 1;
var total = 0;
var dataDetalle = [];
var dataCabecera = [];
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
                    if (value.IdReceta == '') {
                        value.IdReceta = -1;
                    }
                    var totalLinea = value.Precio * cantidad;
                    htmlGrillaDetalle += "<tr id='linea" + linea + "'><td>" + value.IdProducto + "</td>" +
                        "<td>" + value.Producto + "</td><td>" + cantidad + "</td>" +
                        "<td id='precio" + linea + "'>" + value.Precio + "</td>" +
                        "<td>" + totalLinea + "</td>" +
                        "<td><button class='btn btn-xs btn-danger' onclick='eliminarFila(" + linea + ")'>Eliminar</button></td>" +
                        "<td><button class='btn btn-xs btn-danger' onclick='agregarCantidad(" + linea + ")'>Agregar</button></td></tr > ";
                    total += totalLinea; 
                    dataDetalle.push({
                        IdProducto: value.IdProducto, Cantidad: cantidad, Linea: linea, Desc: value.Producto
                        , TotalLinea: totalLinea, IdFamilia: value.IdFamilia, Precio: value.Precio
                        , IdReceta: value.IdReceta
                    });
                    linea++;
                    tablaDetalle.append(htmlGrillaDetalle);
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
    $("#modalMesas").modal('hide');
    $("#modalMesas").hide();
}