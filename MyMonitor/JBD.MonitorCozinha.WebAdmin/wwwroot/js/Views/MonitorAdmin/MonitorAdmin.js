MonitorAdmin = {
    Listar: function () {
        var idEmpresa = $("#IdEmpresa").val();
        var idUnidade = $("#IdUnidade").val();
        var url = "/MonitorAdmin/Listar";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , data: { idEmpresa: idEmpresa, idUnidade: idUnidade }
            , async: false
            , cache: false
        }).done(function (data) {
            $("#divMonitorBody").html(data);
            window.setTimeout(function () {
                RecarregarMonitor();
            }, 20000); //15000
       }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    AtualizarStatus: function (idPedido, idStatus) {
        var url = "/MonitorAdmin/AlterarNumeroPedido";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { IdNumeroPedido: idPedido, Idstatus: idStatus }
            , cache: false
        }).done(function (data) {
            if (data.resultado == true) {
                window.setTimeout(function () {
                    MonitorAdmin.Listar();
                }, 500);
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    InserirNumero: function () {
        var IdEmpresa = $("#IdEmpresa").val();
        var IdUnidade = $("#IdUnidade").val();
        var NumeroPedido = $("#NumeroPedido").val();

        var url = "/MonitorAdmin/InserirNumeroPedido";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "POST"
            , async: false
            , data: { IdEmpresa: IdEmpresa, IdUnidade: IdUnidade, NumeroPedido: NumeroPedido }
            , cache: false
        }).done(function (data) {
            if (data.resultado == true) {
                window.setTimeout(function () {
                   $("#ModalCadastrarNumero").modal('hide');
                    MonitorAdmin.Listar();
                }, 500);
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    DeletarNumero: function (idPedido) {
        var url = "/MonitorAdmin/DeletarNumeroPedido";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { IdNumeroPedido: idPedido }
            , cache: false
        }).done(function (data) {
            if (data.resultado == true) {
                window.setTimeout(function () {
                    MonitorAdmin.Listar();
                }, 500);
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    }
}

$(document).ready(function () {
    var altura = window.screen.availHeight;
    var largura = window.screen.availWidth;
    $("#divFazer").css('height', (altura - 230));
    $("#divTopHeader").css('width', (largura - 17));

    $("#btCadastrarNumeroPedido").click(function () {
        $("#ModalCadastrarNumero").modal('show');
    })

    $("#btnFecharNumeroPedido").click(function () {
        $("#ModalCadastrarNumero").modal('hide');
    })

    $("#btnSalvarNumeroPedido").click(function () {
        MonitorAdmin.InserirNumero();
    })

    var url = window.location.pathname;
    if ((url == "/") || (url == "/MonitorAdmin") || (url == "/MonitorAdmin/Index") || (url == "/MonitorAdmin/")) {
        RecarregarMonitor();
    };
})

function RecarregarMonitor() {
    MonitorAdmin.Listar();
}