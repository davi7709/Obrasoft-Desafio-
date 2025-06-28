$(document).ready(function () {
    console.log("JS atualizado carregado com sucesso");

    // Carregar todos os estados no dropdown
    $.ajax({
        url: '/Estado/GetEstado',
        method: 'GET',
        success: function (estados) {
            var selectEstado = $("#estado");
            selectEstado.append('<option value="">Selecione um estado</option>');
            estados.forEach(function (estado) {
                selectEstado.append(new Option(estado.nome_Est, estado.id));
            });
        },
        error: function (error) {
            console.error("Erro ao carregar estados:", error);
        }
    });

    // Carregar todas as cidades no dropdown
    $.ajax({
        url: '/Cidade/GetCidade',
        method: 'GET',
        success: function (cidades) {
            var selectCidade = $("#cidade");
            selectCidade.append('<option value="">Selecione uma cidade</option>');
            cidades.forEach(function (cidade) {
                selectCidade.append(new Option(cidade.nome_Cid, cidade.id));
            });
        },
        error: function (error) {
            console.error("Erro ao carregar cidades:", error);
        }
    });
});
