MonitorAdmin = {
    Listar: function () {
        //var idEmpresa = $("#IdEmpresa").val();
        //var idUnidade = $("#IdUnidade").val();
        var idEmpresa = localStorage.getItem('IdEmpresa');
        var idUnidade = localStorage.getItem('IdUnidade');
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
            }, 20000);
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
        //var idEmpresa = $("#IdEmpresa").val();
        //var idUnidade = $("#IdUnidade").val();
        var idEmpresa = localStorage.getItem('IdEmpresa');
        var idUnidade = localStorage.getItem('IdUnidade');
        var NumeroPedido = $("#NumeroPedido").val();

        var url = "/MonitorAdmin/InserirNumeroPedido";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "POST"
            , async: false
            , data: { IdEmpresa: idEmpresa, IdUnidade: idUnidade, NumeroPedido: NumeroPedido }
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
    var corFundo = localStorage.getItem("UnidadeCor");
    $("#divFazer").css('height', (altura - 230));
    $("#divTopHeader").css('width', (largura - 17));

    $("#IdEmpresa").val(localStorage.getItem('IdEmpresa'));
    $("#IdUnidade").val(localStorage.getItem('IdUnidade'));

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

    $("#versaoAppMonitorAdm").html("Versão: 1.1.0.0");
    $("CorresFundoA").css("background-color", corFundo);
})

function RecarregarMonitor() {
    MonitorAdmin.Listar();
}