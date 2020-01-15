function validaApertura() {
    $.ajax({
        type: "POST",
        url: "validaApertura",
        data: {},
        async: true,
        success: function (result) {
            if (result.Verificador == true) {
                estadoCaja = 1;
                $("#aperturaCaja").hide();
                //$("#cerrarCaja").show();
                //$("#retirarCaja").show();
            } else {
                estadoCaja = 0;
                $("#aperturaCaja").show();
                $("#cerrarCaja").hide();
                $("#retirarCaja").hide();
            }
        }
    });
}
$(document).ready(validaApertura);

$(document).ready(function () {
    $('.combobox').combobox();

    var estadoCaja = 0;
    var tablaMesas = $("#tablaMesas");
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

    var tablaGarzones = $("#tablaGarzones");
    var htmlGarzones = "";
    $.ajax({
        type: "GET",
        url: "obtenerGarzones",
        data: {},
        async: true,
        success: function (data) {
            if (data == 0) {
                alert("Error");
            } else {
                $.each(data.list, function (index, value) {
                    if (index == 0 || index == 4 || index == 8 || index == 12 || index == 16 || index == 20) {
                        htmlGarzones += "<tr id='linea" + value.IdEmpleado + "'>";
                    }
                    htmlGarzones += "<td><button id='numGarzon" + value.IdEmpleado + "' class='btn-lg btn btn - primary myButton'" +
                        "onclick = 'guardarGarzon(" + value.IdEmpleado + ")' >" + value.Nombre + "</button ></td > ";
                    if (index == 3 || index == 7 || index == 11 || index == 15 || index == 19) {
                        htmlGarzones += "</tr>";
                    }
                });
                tablaGarzones.append(htmlGarzones);
            }
        }
    });

    document.getElementById("guardarVenta").onclick = function () {
        if (estadoCaja == 1) {
            alert("Debe abrir caja");
        }
        else {
            var totalPropina = $("#totalPropina").html();
            var idGarzon = parseInt(document.getElementById("idGarzon").value);
            var Propina = $("#propina").html();
            dataCabecera.push({ NumMesa: numeroMesa, IdGarzon: idGarzon, Total: total, Propina: Propina })
            if (total < 0 || total == "" && idGarzon == 0 || idGarzon == '') {
                alert("Debe ingresar productos o Ingresar Garzon");
            } else {
                $.ajax({
                    type: "POST",
                    url: "generaVenta",
                    data: { detalleVenta: dataDetalle, cabeceraVenta: dataCabecera },
                    async: true,
                    success: function (data) {

                    }
                });
            }
        }
    }

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
        if (montoApertura == '' && glosaApertura == '') {
            alert("Debe Ingresar Datos");
        } else {
            $.ajax({
                type: "POST",
                url: "aperturaCaja",
                data: { _montoApertura: montoApertura, _glosaApertura: glosaApertura },
                async: true,
                success: function (data) {
                    if (data > 0) {
                        alert("Caja Abierta. Num°: " + data);
                        estadoCaja = 1;
                        $("#aperturaCaja").hide();
                        $("#modalApertura").hide();
                        $("#retirarCaja").show();
                        $("#cerrarCaja").show();
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
        
    }

    document.getElementById("retiroCaja").onclick = function () {
        var montoRetiro = $("#montoRetiro").val();
        var glosaRetiro = $("#glosaRetiro").val();
        if (montoRetiro == '' && glosaRetiro == '') {
            alert("Debe Ingresar Datos");
        } else {
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
    }

    document.getElementById("cierreCaja").onclick = function () {
        var glosaCierre = $("#glosaCierre").val();
        if (glosaCierre == '') {
            alert('Debe Ingresar Datos');
        } else {
            $.ajax({
                type: "POST",
                url: "cierreCaja",
                data: { _glosaCierre: glosaCierre },
                async: true,
                success: function (result) {
                    if (result.Verificador == true) {
                        estadoCaja = 0;
                        $("#aperturaCaja").show();
                        $("#cerrarCaja").hide();
                        $("#retirarCaja").hide();
                        $("#modalCierre").hide();
                        alert(result.Mensaje);
                    } else {
                        estadoCaja = 0;
                    }
                }
            });
        }
    }
    //--- FUNCIONES CAJA ----------
});

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
                    if (index == 0 || index == 2 || index == 4 || index == 6 || index == 8 || index == 10) {
                        htmlBotonesProd += "<tr>";
                    }
                    htmlBotonesProd += "<td><button value='" + value.IdProducto + "' class='form-control btn btn-primary btn-xs' onclick='detalleVenta(" + value.IdProducto + ")'" +
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
                    htmlGrillaDetalle += "<tr id='linea" + linea + "'>" +
                        "<td>" + value.Producto + "</td><td id='cantidad" + linea + "'>" + cantidad + "</td>" +
                        "<td id='precio" + linea + "'>" + value.Precio + "</td>" +
                        "<td id='totalLinea" + linea + "'>" + totalLinea + "</td>" +
                        "<td><button class='btn btn-xs btn-danger' onclick='agregadoProd(" + linea + ")'>Agregado</button></td> " +
                        "<td><button class='btn btn-xs btn-danger' onclick='eliminarFila(" + linea + ")'>Eliminar</button></td>" +
                        "<td><button class='btn btn-xs btn-danger' onclick='agregarCantidad(" + linea + ")'>+</button></td> " +
                        "<td><button class='btn btn-xs btn-danger' onclick='restarCantidad(" + linea + ")'>-</button></td></tr > ";
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

function agregarCantidad(linea) {
    logicaCantidad(linea, 1);
}

function restarCantidad(linea) {
    var cantidadActual = parseInt($("#cantidad" + linea).html());
    if (cantidadActual != 1) {
        logicaCantidad(linea, -1);
    }
}

function logicaCantidad(linea, valor) {
    var cantidadActual = parseInt($("#cantidad" + linea).html());
    cantidadActual = cantidadActual + valor;
    $("#cantidad" + linea).html(cantidadActual);
    dataDetalle.find(m => m.Linea === linea).Cantidad = cantidadActual;

    var totalActual = parseInt($("#totalLinea" + linea).html());
    var precio = parseInt($("#precio" + linea).html());
    totalActual = precio * cantidadActual;
    $("#totalLinea" + linea).html(totalActual);
    dataDetalle.find(m => m.Linea === linea).ToTalLinea = totalActual;

    var totalFinal = 0;
    var totales = dataDetalle.map(m => m.Cantidad * m.TotalLinea);
    for (i = 0; i < totales.length; i++) {
        totalFinal = totalFinal + totales[i];
    }
    total = totalFinal;
    $("#total").html("$" + total);

    var propina = $("#propina").html();
    propina = total / 10;
    $("#propina").html(propina);

    $("#totalPropina").html("$" + (total + propina));
}

function eliminarFila(linea) {
    var totalLinea = $("#totalLinea" + linea).html();
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
    $("#numMesa").html("&nbsp;N° Mesa: (" + numMesa + ")");
    $("#numMesa").show();
    $("#modalMesas").modal('hide');
    $("#modalMesas").hide();
}

var numeroGarzon = 0;
function guardarGarzon(numGarzon) {
    numeroGarzon = numGarzon;
    $("#modalGarzon").modal('hide');
    $("#modalGarzon").hide();
}

function agregarMesa() {
    var tablaMesas = $("#tablaMesas");
    var numeroMesa = $("#numMesaNueva").val();
    var tipoMesa = 'Interior';
    $.ajax({
        type: "POST",
        url: "agregarMesa",
        data: { _numMesa: numeroMesa, _tipo: tipoMesa },
        async: true,
        success: function (data) {
            if (data == -666) {
                $.ajax({
                    type: "GET",
                    url: "obtenerMesa",
                    data: {},
                    async: true,
                    success: function (data) {
                        if (data == 0) {
                            alert("Error");
                        } else {
                            htmlMesas = "";
                            tablaMesas.empty();
                            tablaMesas.hide();
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
                        tablaMesas.show();
                        $("#agregarMesa").modal('hide');
                    }
                });
            }
            if (data == -1) {
                alert("Debe ingresar numero de mesa");
            }
            if (data > 0) {
                $.ajax({
                    type: "GET",
                    url: "obtenerMesa",
                    data: {},
                    async: true,
                    success: function (data) {
                        if (data == 0) {
                            alert("Error");
                        } else {
                            htmlMesas = "";
                            tablaMesas.empty();
                            tablaMesas.hide();
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
                        tablaMesas.show();
                        $("#agregarMesa").modal('hide');
                    }
                });
            }
        }
    });
}

function eliminarMesa() {
    var tablaMesas = $("#tablaMesas");
    var numeroMesa = $("#modNumMesa").val();
    $.ajax({
        type: "POST",
        url: "eliminarMesa",
        data: { _numeroMesa: numeroMesa },
        async: true,
        success: function (data) {
            if (data == -666) {
                alert("Mesa Ingresada no es Valida");
            }
            if (data == -1) {
                alert("Debe Ingresar Numero de Mesa");
            }
            if (data > 0) {
                alert("Mesa Eliminada");
                $.ajax({
                    type: "GET",
                    url: "obtenerMesa",
                    data: {},
                    async: true,
                    success: function (data) {
                        if (data == 0) {
                            alert("Error");
                        } else {
                            htmlMesas = "";
                            tablaMesas.empty();
                            tablaMesas.hide();
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
                        tablaMesas.show();
                        $("#eliminarMesa").modal('hide');
                    }
                });
            }
        }
    });
}

function agregarGarzon() {
    var tablaGarzones = $("#tablaGarzones");
    var nombreGarzon = $("#idNombreGarzon").val();
    $.ajax({
        type: "POST",
        url: "agregarGarzon",
        data: { _nombreGarzon: nombreGarzon },
        async: true,
        success: function (data) {
            if (data == -666) {
                alert("Nombre de Garzon Existente");
                $.ajax({
                    type: "GET",
                    url: "obtenerGarzones",
                    data: {},
                    async: true,
                    success: function (data) {
                        if (data == 0) {
                            alert("Error");
                        } else {
                            htmlGarzones = "";
                            tablaGarzones.empty();
                            tablaGarzones.hide();
                            $.each(data.list, function (index, value) {
                                if (index == 0 || index == 4 || index == 8 || index == 12 || index == 16 || index == 20) {
                                    htmlGarzones += "<tr id='linea" + value.IdEmpleado + "'>";
                                }
                                htmlGarzones += "<td><button id='numGarzon" + value.IdEmpleado + "' class='btn-lg btn btn - primary myButton'" +
                                    "onclick = 'guardarGarzon(" + value.IdEmpleado + ")' >" + value.Nombre + "</button ></td > ";
                                if (index == 3 || index == 7 || index == 11 || index == 15 || index == 19) {
                                    htmlGarzones += "</tr>";
                                }
                            });
                            tablaGarzones.append(htmlGarzones);
                            location.reload();
                        }
                        tablaGarzones.show();
                        $("#agregarGarzon").modal('hide');
                    }
                });
            }
            if (data == -1) {
                alert("Debe Nombre de Garzon");
            }
            if (data > 0) {
                alert("Garzon fue Agregado");
                $.ajax({
                    type: "GET",
                    url: "obtenerGarzones",
                    data: {},
                    async: true,
                    success: function (data) {
                        if (data == 0) {
                            alert("Error");
                        } else {
                            htmlGarzones = "";
                            tablaGarzones.empty();
                            tablaGarzones.hide();
                            $.each(data.list, function (index, value) {
                                if (index == 0 || index == 4 || index == 8 || index == 12 || index == 16 || index == 20) {
                                    htmlGarzones += "<tr id='linea" + value.idEmpleado + "'>";
                                }
                                htmlGarzones += "<td><button id='mesa" + value.idEmpleado + "' class='btn-sm btn btn-primary myButton'" +
                                    "onclick = 'guardarGarzon(" + value.idEmpleado + ")' >" + value.Nombre + "</button ></td > ";
                                if (index == 3 || index == 7 || index == 11 || index == 15 || index == 19) {
                                    htmlGarzones += "</tr>";
                                }
                            });
                            tablaGarzones.append(htmlGarzones);
                            location.reload();
                        }
                        //tablaGarzones.show();
                        //$("#agregarGarzon").modal('hide');
                    }
                });
            }
        }
    });
}

function eliminaGarzon() {
    var tablaGarzones = $("#tablaGarzones");
    var idGarzon = $("#modIdGarzon").val();
    $.ajax({
        type: "POST",
        url: "eliminarGarzon",
        data:{ _idGarzon: idGarzon },
        async: true,
        success: function (data) {
            if (data == -666) {
                alert("Garzon Ingresada no es Valido");
            }
            if (data == -1) {
                alert("Debe Ingresar Garzon");
            }
            if (data > 0) {
                alert("Garzon fue Agregado");
                $.ajax({
                    type: "GET",
                    url: "obtenerGarzones",
                    data: {},
                    async: true,
                    success: function (data) {
                        if (data == 0) {
                            alert("Error");
                        } else {
                            htmlGarzones = "";
                            tablaGarzones.empty();
                            tablaGarzones.hide();
                            $.each(data.list, function (index, value) {
                                if (index == 0 || index == 4 || index == 8 || index == 12 || index == 16 || index == 20) {
                                    htmlGarzones += "<tr id='linea" + value.IdEmpleado + "'>";
                                }
                                htmlGarzones += "<td><button id='numGarzon" + value.IdEmpleado + "' class='btn-lg btn btn - primary myButton'" +
                                    "onclick = 'guardarGarzon(" + value.IdEmpleado + ")' >" + value.Nombre + "</button ></td > ";
                                if (index == 3 || index == 7 || index == 11 || index == 15 || index == 19) {
                                    htmlGarzones += "</tr>";
                                }
                            });
                            tablaGarzones.append(htmlGarzones);
                        }
                        tablaGarzones.show();
                        $("#eliminarGarzon").modal('hide');
                    }
                });
            }
        }
    });
}

function imprimir() {
    window.print();
}
            
        
    