"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//Disable the send button until connection is established.
document.getElementById("enviar").disabled = true;



connection.on("ReceiveMessage", function (tiempoEstimadoLLegada, climaExterior, comburete, combustible, horaTierra, tiempoEnVuelo, velocidad, posicionNave) {

    document.getElementById("myDiv").hidden = true;
    console.log("entrroooooooooooo")
    document.querySelector("#tiempoEstimadoLLegada").innerText = '' + tiempoEstimadoLLegada;
    document.querySelector("#climaExterior").innerText = '' + climaExterior;
    document.querySelector("#comburete").innerText = '' + comburete;
    document.querySelector("#combustible").innerText = '' + combustible;
    document.querySelector("#horaTierra").innerText = '' + horaTierra;
    document.querySelector("#tiempoEnVuelo").innerText = '' + tiempoEnVuelo;
    document.querySelector("#velocidad").innerText = '' + velocidad;




});

connection.start().then(function () {
   
}).catch(function (err) {
    return console.error(err.toString());
});

