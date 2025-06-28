// @ts-nocheck

$(function () {
    var $estadoDropdown = $("#estado");
    var $cidadeDropdown = $("#cidade");

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

    // Carrega todas as cidades
    $.ajax({
        url: '/Cidade/GetCidadeEstado',
        method: 'GET',
        success: function (cidades) {
            console.error("As cidade estão sendo carregadas", cidades);
            atualizarDropdownCidades(cidades);
        },
        error: function (error) {
            console.error("Erro ao carregar cidades:", error);
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
        } else {
            // Se nenhum estado for selecionado, mostra todas as cidades
            $.ajax({
                url: '/Cidade/GetCidadeEstado',
                method: 'GET',
                success: function (cidades) {
                    atualizarDropdownCidades(cidades);
                }
            });
        }
    });

    $cidadeDropdown.change(function () {
        var cidadeId = $(this).val();

        if (cidadeId) {
            $.ajax({
                url: `/Cidade/GetEstadoPorCidade?cidadeId=${cidadeId}`,
                method: 'GET',
                success: function (estadoId) {
                    $estadoDropdown.val(estadoId); // atualiza o dropdown de estado
                },
                error: function (error) {
                    console.error("Erro ao buscar estado por cidade:", error);
                }
            });
        }
    });

    // Função para atualizar o dropdown de cidades
    function atualizarDropdownCidades(cidades) {
        console.log("Cidades estao sendo atualizadas funcao de atualizar OK", cidades);
        $cidadeDropdown.empty();
        $cidadeDropdown.append('<option value="">Selecione uma cidade</option>');

        cidades.forEach(function (cidade) {
            $cidadeDropdown.append(`<option value="${cidade.id}">${cidade.nome_Cid}</option>`);
        });
    }
});

