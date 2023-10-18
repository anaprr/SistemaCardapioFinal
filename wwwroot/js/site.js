function CalcularPorcentagem() {

    var CampoTotalAlimento = document.querySelector("#QtdAlimento");
    var TotalAlimento = CampoTotalAlimento.value;

    var CampoTotalDisperdicio = document.querySelector("#QtdDesperdicio");
    var TotalDisperdicio = CampoTotalDisperdicio.value;

     porcentagem = (TotalDisperdicio * 100) / TotalAlimento;

    document.querySelector("#PorcentagemDesperdicio").value = Math.round(porcentagem);
}

var elements = document.getElementsByClassName("porcentagem");

Object.keys(elements).forEach(key => {
    var teste = parseInt(elements[key].innerText);
    if (teste <= 10) {
        elements[key].style.backgroundColor = "#32CD32";
    }
    else if (parseInt(elements[key].innerText) >= 10 && parseInt(elements[key].innerText) <= 50) {
        elements[key].style.backgroundColor = "#FFFF00";
    }
    else {
        elements[key].style.backgroundColor = "#FF0000";
    } 
});