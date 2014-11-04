function onDropDownChange() {
    if ($("#DropDownListScope").val() == 2) {
        document.getElementById("pais").disabled = true;
    }
    else {
        document.getElementById("pais").disabled = false;
    }
}

function validacaoPais() {
    if (document.getElementById('pais').getAttribute('disabled') == true) {
        document.getElementById("pais").value = 'null';
    }
}