$(document).ready(function () {

    $("#selectListCampeonatos").on("change", function (event) {
        $("#tableEquipas input").attr('checked', false);
        if($(this).find(':selected').index()>0)
        {
            if($(this).find(':selected').attr('data-category')!="")
            {
                $("#tableEquipas p").addClass('hidden').slideUp("slow");
                $("#tableEquipas p:hidden[data-category=" +
                    $("#selectListCampeonatos").find(':selected').attr('data-category')
                    + "]").removeClass('hidden').slideDown("slow");
            }
            else
            {
                $("#tableEquipas p:hidden").removeClass('hidden').slideDown("slow");

            }
        }
        else
        {
            $("#tableEquipas p").addClass('hidden').slideUp("slow");
        }
    });

    $("#inputNumeroJornadas").on("change", function (event) {
        if ($(this).val() > 0 && $(this).val() < 100) {

            $("#numeroInvalido").remove();
            var numeroJornadas = $(this).val();
            var numeroEquipas = 0;

            numeroEquipas = (numeroJornadas / 2) + 1;

            if ($('#informacaoEquipas td').length > 0) {
                $('#tdEquipas').remove();
                $('#informacaoEquipas').append('<td id="tdEquipas">Tem que selecionar ' + Math.round(numeroEquipas) + ' equipas.</td>');
            }
            else {
                $('#informacaoEquipas').removeClass('hidden').append('<td id="tdEquipas">Tem que selecionar ' + Math.round(numeroEquipas) + ' equipas.</td>');
            }
        }
        else {
            $("#tdEquipas").remove();
            if ($("#numeroInvalido").length == 0) {
                $("#informacaoNumeroJornadas").removeClass('hidden').append('<p id="numeroInvalido">O Número de Jornadas não é válido.</<p>');
            }
        }

        $("#tableEquipas input:checked").attr('checked', false);
    });


    $("#tableEquipas input").click(function (event) {
        var numeroEquipasSeleciondas = $("#tableEquipas input:checked").length;
        var numeroJornadas = $("#inputNumeroJornadas").val();
        var numeroEquipas = 0;
        var equipasRestantes = 0;

        numeroEquipas = (numeroJornadas / 2) + 1;
        numeroEquipas = Math.round(numeroEquipas);
        if (numeroEquipasSeleciondas === numeroEquipas) {
            if ($('#informacaoEquipas td').length > 0) {
                $('#tdEquipas').remove();
                $('#informacaoEquipas').append('<td id="tdEquipas" rowspan="4">Já selecionou todas as equipas.</td>');
            }
            else {
                $('#informacaoEquipas').removeClass('hidden').append('<td id="tdEquipas" rowspan="4">Já selecionou todas as equipas.</td>');
            }
        }
        else {
            equipasRestantes = numeroEquipas - numeroEquipasSeleciondas;
            if ($('#informacaoEquipas td').length > 0) {
                $('#tdEquipas').remove();
                $('#informacaoEquipas').append('<td id="tdEquipas">Ainda tem que selecionar ' + equipasRestantes + ' equipas.</td>');
            }
            else {
                $('#informacaoEquipas').removeClass('hidden').append('<td id="tdEquipas">Ainda tem que selecionar ' + equipasRestantes + ' equipas.</td>');
            }
        }
    });
});