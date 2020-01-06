$(document).ready(function () {
    var tablaFamilia = $("#tablaFamilia");
    var htmlFamilia = "<tr>";
    tablaFamilia.append(htmlFamilia);
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
                    var htmlBotones = "<td>" +
                        "<button value='" + value.IdFamilia + "' class='form-control btn btn-primary' onclick='getProductos("+value.IdFamilia+")'" +
                        "id='"+familia+"' > " + value.Familia + "</button ></td >";
                    tablaFamilia.append(htmlBotones);
                });
                htmlFamilia = "</tr>"
                tablaFamilia.append(htmlFamilia);
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
                htmlBotonesProd.append(htmlFamilia);
            }
        }
    });
}