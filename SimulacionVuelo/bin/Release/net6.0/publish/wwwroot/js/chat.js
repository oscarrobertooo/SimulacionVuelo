"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("enviar").disabled = true;



connection.on("ReceiveMessage", function (tiempoEstimadoLLegada, climaExterior, comburete, combustible, horaTierra, tiempoEnVuelo, velocidad) {

    document.getElementById("myDiv").hidden = true;

    document.querySelector("#tiempoEstimadoLLegada").innerText = '' + tiempoEstimadoLLegada;
    document.querySelector("#climaExterior").innerText = '' + climaExterior;
    document.querySelector("#comburete").innerText = '' + comburete;
    document.querySelector("#combustible").innerText = '' + combustible;
    document.querySelector("#horaTierra").innerText = '' + horaTierra;
    document.querySelector("#tiempoEnVuelo").innerText = '' + tiempoEnVuelo;
    document.querySelector("#velocidad").innerText = '' + velocidad;

});

connection.start().then(function () {
    document.getElementById("enviar").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});


$("#enviar").click(function () {
    document.getElementById("myDiv").hidden = true;

    var data = {};
    data.IdPiloto = $("#IdPiloto").val();
    data.IdPlaneta = $("#IdPlaneta").val();
    data.IdNave = $("#IdNave").val();
    

    $.ajax({
        type: "POST",
        url: "/Home/Index",
        data: data,
        success: function (response) {
            document.getElementById("myDiv").hidden = false;
            
        }
    });
});
