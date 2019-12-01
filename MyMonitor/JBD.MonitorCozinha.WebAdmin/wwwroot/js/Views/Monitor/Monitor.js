Monitor = {
    Listar: function () {
        var idEmpresa = $("#IdEmpresa").val();
        var idUnidade = $("#IdUnidade").val();

        var url = "/Monitor/Listar";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , data: {idEmpresa: idEmpresa, idUnidade: idUnidade}
            , async: false
            , cache: false
        }).done(function (data) {
            $("#divMonitorTvBody").html(data);

            $("html, body").animate({ scrollTop: $(document).height() - $(window).height() }, 5000);
            window.setTimeout(function () {
                RecarregarMonitor();
            }, 10000);
            $("html, body").animate({ scrollTop: $("#divTop").scrollTop() }, 5000);

        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },
}

$(document).ready(function () {
    var altura = window.screen.availHeight;
    var largura = window.screen.availWidth;
    $("#divFazer").css('height', (altura - 230));
    $("#divTopHeader").css('width', (largura - 17));
    RecarregarMonitor();
})

function RecarregarMonitor() {
    Monitor.Listar();
}