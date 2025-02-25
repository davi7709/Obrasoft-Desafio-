$(document).ready(function () {
    // Carregar Estados no dropdown
    $.ajax({
        url: '/Estado/GetEstado',
        method: 'GET',
        success: function (estados) {
            let selectEstado = $("#estado");
            estados.forEach(function (estado) {
                selectEstado.append(new Option(estado.nome_Est, estado.id));
            });
        },
        error: function (error) {
            console.error("Erro ao carregar estados:", error);
        }
    });

    // Evento de mudança no dropdown de Estado
    $("#estado").change(function () {
        var estadoId = $(this).val();  // Obtém o ID do estado selecionado

        if (estadoId) {
            console.log("Estado selecionado:", estadoId);

            $.ajax({
                url: `/Cidade/GetCidadeEstado?estadoId=${estadoId}`,  // Passa estadoId na URL
                type: "GET",
                dataType: "json",
                success: function (cidades) {
                    console.log("Cidades recebidas:", cidades);
                    atualizarDropdownCidades(cidades);
                },
                error: function (xhr, status, error) {
                    console.error("Erro ao buscar cidades:", xhr.responseText || error);
                }
            });
        }
    });

    // Atualizar o dropdown de cidades
    function atualizarDropdownCidades(cidades) {
        var $cidadeDropdown = $("#cidade");
        $cidadeDropdown.empty();  // Limpa opções anteriores
        $cidadeDropdown.append('<option value="">Selecione uma cidade</option>');

        cidades.forEach(function (cidade) {
            $cidadeDropdown.append(`<option value="${cidade.id}">${cidade.nome_Cid}</option>`);
        });
    }
});

