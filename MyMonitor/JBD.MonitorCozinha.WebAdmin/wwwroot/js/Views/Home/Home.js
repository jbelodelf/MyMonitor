Home = {
    InserirNumero: function (origem) {
        //var IdEmpresa = $("#IdEmpresa").val();
        //var IdUnidade = $("#IdUnidade").val();
        var IdEmpresa = localStorage.getItem('IdEmpresa');
        var IdUnidade = localStorage.getItem('IdUnidade');
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
                if (origem == "MOTOBOY") {
                    Home.Finalizar();
                }
                else {
                    window.setTimeout(function () {
                        $("#ModalCadastrarNumero").modal('hide');
                    }, 500);
                }
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    Cadastrar: function (idEmpresa, idUnidade, nomeCozinha) {
        $("#IdUnidade").val(idUnidade);
        $("#nomeCozinha").html(nomeCozinha);
        $("#ModalCadastrarNumero").modal('show');
    },

    CadastrarSenha: function () {
        $("#dvIniciar").hide();
        $("#dvCozinhas").hide();
        $("#dvDigitarNumero").show();
        $("#dvBtVoltar").show();

        var btVoltar = '<button class="btn btn-outline-danger btn-custom" style="font-size:20px;" onclick="Home.Iniciar()"><i class="fas fa-arrow-alt-circle-left"></i> <b>VOLTAR</b></button>';
        $("#dvBtVoltar").html(btVoltar);
    },
    
    SelecionarUnidade: function () {
        var isNumber = isNumeric($("#NumeroPedido").val());
        if (isNumber) {
            $("#dvDigitarNumero").hide();
            $("#dvConfirmar").hide();
            $("#dvCozinhas").show();

            var btVoltar = '<button class="btn btn-outline-danger btn-custom" style="font-size:20px;" onclick="Home.CadastrarSenha()"><i class="fas fa-arrow-alt-circle-left"></i> <b>VOLTAR</b></button>';
            $("#dvBtVoltar").html(btVoltar);
        }
        else {
            $("#mensagemBody").html("Digite apenas números!!!");
            $("#mensagemBody").show();
            window.setTimeout(function () {
                $("#mensagemBody").html("");
                $("#mensagemBody").hide();
            }, 2000);
        }
    },
    
    Confirmar: function (idUnidade, logomarca, nomeCozinha) {
        $("#IdUnidade").val(idUnidade);
        $("#Logomarca").val(logomarca);
        $("#CozinhaNome").val(nomeCozinha);

        var num = '<button class="btn btn-lg-hover btn-lg btn-custom" id="numeroPedido" style="height: 60px;">&nbsp;&nbsp' + $("#NumeroPedido").val() + '&nbsp;&nbsp;</button>';
        var logo = '<img src="' + logomarca + '"' + ' class="img-fluid rounded img-thumbnail btn-outline-danger">';
        $("#dvNumeroPedido").html(num);
        $("#dvLogomarca").html(logo);
        $("#dvFinalizar").hide();
        $("#dvCozinhas").hide();
        $("#dvConfirmar").show();

        var btVoltar = '<button class="btn btn-outline-danger btn-custom" style="font-size:20px;" onclick="Home.SelecionarUnidade()"><i class="fas fa-arrow-alt-circle-left"></i> <b>VOLTAR</b></button>';
        $("#dvBtVoltar").html(btVoltar);
    },

    Finalizar: function () {
        var nomeCozinha = '<button class="btn btn-lg-hover btn-block btn-custom" id="btFinalizar" style="font-size:40px;">&nbsp;&nbsp' + $("#CozinhaNome").val() + '&nbsp;&nbsp;</button>';
        $("#dvBtNomeCozinha").html(nomeCozinha);
        $("#dvConfirmar").hide();
        $("#dvFinalizar").show();
        $('#dvBtVoltar')[0].style.display = "none";

        window.setTimeout(function () {
            Home.Iniciar();
        }, 2000);
    },

    Iniciar: function () {
        $("#Logomarca").val("");
        $("#CozinhaNome").val("");
        $("#NumeroPedido").val("");
        $("#dvDigitarNumero").hide();
        $("#dvFinalizar").hide();
        $("#dvIniciar").show();
        $("#dvBtVoltar").hide();
    }
}

$(document).ready(function () {
    $("#btnFecharNumeroPedido").click(function () {
        $("#ModalCadastrarNumero").modal('hide');
    })

    $("#btnSalvarNumeroPedido").click(function () {
        Home.InserirNumero("OPERADOR");
    })

    $("#versaoAppMonitor").html("Versão: 1.1.0.0");
})

function isNumeric(str) {
    var er = /^[0-9]+$/;
    return (er.test(str));
}