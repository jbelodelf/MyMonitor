Pessoa = {
    Listar: function () {
        $("body").css("padding-top", "2px", "!important");
        $("#TopoPesquisa").css("margin-left", "5px");
        $("#TopoPesquisa").css("margin-right", "5px");
        $("#TopoPesquisa").css("padding-top", "20px");
        $("#TopoPesquisa").css("padding-bottom", "15px");
        var pessoa = $("#PessoaPesquisar").val();
        //Recupera o Id Unidade
        var idUnidade = $("#IdUnidade").val();

        var url = "/Pessoa/ListarPessoas";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { nomePessoa: pessoa, IdUnidade: idUnidade }
            , cache: false
        }).done(function (data) {
            $("#divListarPessoas").html(data);

            $("#cabecalho").css("background-color", "#5B9BD5")
            $("#cabecalho").css("color", "#FFFFFF")
            $("#colNome").css("width", "680");
            AplicarDataTable('tbListarPessoas', '0', "asc", 20, false, undefined, true);
            $("#tbListarPessoas").css("margin-top", "5px");
            $("#tbListarPessoas").css("float", "right");
            $("#footer").css("margin-top", "50px");
            $("#footer").css("height", "40px");
            $("#footer").css("padding", "10px");
            $("#tbListarPessoas_length").parent().css("display", "contents");
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },
    
    Salvar: function () {
        var isValido = true;

        if ($("#idEmpresaNum").val() == "") {
            isValido = false;
        }
        else if ($("#idUnidadeNum").val() == "") {
            isValido = false;
        }
        else if ($("#Nome").val() == "") {
            isValido = false;
        }
        else if ($("#CPF").val() == "") {
            isValido = false;
        }
        else if ($("#RG").val() == "") {
            isValido = false;
        }
        else if ($("#Cargo").val() == "") {
            isValido = false;
        }
        else if ($("#EmailPJ").val() == "") {
           isValido = false;
        }
        else if ($("#EmailPF").val() == "") {
           isValido = false;
        }
        else if ($("IdStatus").val() == "") {
            isValido = false;
        }
        else if ($("IdTipoContato").val() == "") {
            isValido = false;
        }
        else if ($("DataCadastro").val() == "") {
            isValido = false;
        }

        if (!isValido) {
            $("#mensagemModal").text("Favor preencher os campos obrigatórios!!!").show();
            window.setTimeout(function () {
                $("#mensagemModal").text("").hide();
            }, 6000);
            return;
        }
        bootbox.confirm({
            message: 'Deseja realmente salvar este registro?',
            buttons: {
                confirm: {
                    label: 'Sim',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'Não',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                if (!result) {
                    controle = true;
                    return;
                }
                var url = "/Pessoa/SalvarPessoa";

                pessoa = {
                    IdEmpresa: $("#idEmpresaNum").val(),
                    IdUnidade: $("#idUnidadeNum").val(),
                    Nome: $("#Nome").val(),
                    CPF: $("#CPF").val(),
                    RG: $("#RG").val(),
                    Cargo: $("#Cargo").val(),
                    EmailPJ: $("#EmailPJ").val(),
                    EmailPF: $("#EmailPF").val(),
                    IdStatus: $("#IdStatus").val(),
                    IdTipoContato: $("#IdTipoContato").val(),
                    DataCadastro: $("#DataCadastro").val()

                },
                    $.ajax({
                        url: url
                        , datatype: "json"
                        , type: "POST"
                        , async: false
                        , data: { pessoa: pessoa }
                        , cache: false
                    }).done(function (data) {
                        if (data.retorno == "200") {
                            $("#mensagemModal").text(data.mensagem).show();
                            window.setTimeout(function () {
                                $("#mensagemModal").text("").hide();
                                var numero = pessoa.IdUnidade;
                                window.location.href = "/Pessoa/Index?IdUnidade=" + numero;
                            }, 3000);
                        }
                        else {
                            $("#mensagemModal").text('Erro:' + data.mensagem).show();
                            window.setTimeout(function () {
                                $("#mensagemModal").text("").hide();
                                window.location.href = "/Unidade/Index";
                            }, 3000);
                            return;
                        }
                    }).fail(function (jqXHR, exception) {
                        TratamentoDeErro(jqXHR, exception);
                    });
            }
        });
    },

    Editar: function (idPessoa) {
        var url = "/Pessoa/EditarPessoa";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { id: idPessoa }
            , cache: false
        }).done(function (data) {
            if (data != null) {
                $("#IdPessoa").val(data.data.idPessoa);
                $("#IdEmpresa").val(data.data.idEmpresa);
                $("#IdUnidade").val(data.data.idUnidade);
                $("#Nome").val(data.data.nome);
                $("#CPF").val(data.data.cpf);
                $("#RG").val(data.data.rg);
                $("#Cargo").val(data.data.cargo);
                $("#EmailPJ").val(data.data.emailPJ);
                $("#EmailPF").val(data.data.emailPF);
                $("#IdStatus").val(data.data.idStatus);
                $("#IdTipoContato").val(data.data.idTipoContato);
                $("#DataCadastro").val(data.data.dataCadastro);

                $("#btnSalvarPessoa").show();
                $("#ModalCadastrarPessoa").modal('show');
            }
            else {
                return;
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    }


}

$(document).ready(function () {
    var url = window.location.pathname;
    if ((url == "/") || (url == "/Pessoa") || (url == "/Pessoa/Index") || (url == "/Pessoa/")) {
        Pessoa.Listar();
    }

    $("#btVoltar").on("click", function () {
        var numero = $("#idEmpresaNum").val();
        window.location.href = "/Unidade/Index?IdEmpresa=" + numero;
    });

    $("#btnSalvarPessoa").on("click", function () {
        Pessoa.Salvar();
    });


    $('#btNovo').on("click", function () {

        $("#IdPessoa").val("0");
        $("#IdEmpresa").val("").attr("Readonly", false);
        $("#IdUnidade").val("").attr("Readonly", false);
        $("#Nome").val("").attr("Readonly", false);
        $("#CPF").val("").attr("Readonly", false);
        $("#RG").val("").attr("Readonly", false);
        $("#Cargo").val("").attr("Readonly", false);
        $("#EmailPJ").val("").attr("Readonly", false);
        $("#EmailPF").val("").attr("Readonly", false);
        $("#IdStatus").val("1").attr("Readonly", true);
        $("#IdTipoContato").val("").attr("Readonly", false);
        $("#DataCadastro").attr("Readonly", false);
        
        $("#btnSalvarPessoa").show();
        $("#ModalCadastrarPessoa").modal('show');

    });

    $('#btnFecharPessoa').on("click", function () {

        $("#IdPessoa").val("0");
        $("#IdEmpresa").val("");
        $("#IdUnidade").val("");
        $("#Nome").val("");
        $("#CPF").val("");
        $("#RG").val("");
        $("#Cargo").val("");
        $("#EmailPJ").val("");
        $("#EmailPF").val("");
        $("#IdStatus").val("");
        $("#IdTipoContato").val("");
        $("#DataCadastro");

        $("#ModalCadastrarPessoa").modal('hide');


    });

});

