Unidade = {
    Listar: function () {
        $("body").css("padding-top", "2px", "!important");
        $("#TopoPesquisa").css("margin-left", "5px");
        $("#TopoPesquisa").css("margin-right", "5px");
        $("#TopoPesquisa").css("padding-top", "20px");
        $("#TopoPesquisa").css("padding-bottom", "15px");
        var unidade = $("#UnidadePesquisar").val();
        //Recupera o Id Empresa
        var idEmpresa = $("#IdEmpresa").val();

        var url = "/Unidade/ListarUnidades";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { nomeUnidade: unidade, IdEmpresa: idEmpresa }
            , cache: false
        }).done(function (data) {
            $("#divListarUnidades").html(data);

            $("#cabecalho").css("background-color", "#5B9BD5")
            $("#cabecalho").css("color", "#FFFFFF")
            $("#colNome").css("width", "680");
            AplicarDataTable('tbListarUnidades', '0', "asc", 20, false, undefined, true);
            $("#tbListarUnidades").css("margin-top", "5px");
            $("#tbListarUnidades").css("float", "right");
            $("#footer").css("margin-top", "50px");
            $("#footer").css("height", "40px");
            $("#footer").css("padding", "10px");
            $("#tbListarUnidades_length").parent().css("display", "contents");
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    Salvar: function () {
        var isValido = true;     

        if ($("#idEmpresaNum").val() == "") {
            isValido = false;
        }
        else if ($("#Nome").val() == "") {
            isValido = false;
        }
        else if ($("#CEP").val() == "") {
            $("#CEP").unmask();
            isValido = false;
        }
        else if ($("#Endereco").val() == "") {
            isValido = false;
        }
        else if ($("#Numero").val() == "") {
            isValido = false;
        }
        else if ($("#Bairro").val() == "") {
            isValido = false;
        }
        else if ($("#Cidade").val() == "") {
            isValido = false;
        }
        else if ($("#Estado").val() == "") {
            isValido = false;
        }
        else if ($("Pais").val() == "") {
            isValido = false;
        }
        else if ($("#NomeContato").val() == "") {
            isValido = false;
        }
        else if ($("#Telefone").val() == "") {
            isValido = false;
        }
        else if ($("#Email").val() == "") {
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
                var url = "/Unidade/SalvarUnidade";
                var cep = $("#CEP").val().replace(/\D/g, '');

                unidade = {                  
                    IdUnidade: $("#IdUnidade").val(),
                    IdEmpresa: $("#idEmpresaNum").val(),
                    Nome: $("#Nome").val(),
                    CEP: cep,
                    Endereco: $("#Endereco").val(),
                    Numero: $("#Numero").val(),
                    Bairro: $("#Bairro").val(),
                    Cidade: $("#Cidade").val(),
                    Estado: $("#Estado").val(),
                    Pais: $("#Pais").val(),
                    IdStatus: $("#IdStatus").val(),
                    NomeContato: $("#NomeContato").val(),
                    Telefone: $("#Telefone").val(),
                    Email: $("#Email").val(),
                    DataCadastro: $("#DataCadastro").val()
                },
                $.ajax({
                    url: url
                    , datatype: "json"
                    , type: "POST"
                    , async: false
                    , data: { unidade: unidade }
                    , cache: false
                }).done(function (data) {
                    if (data.retorno == "200") {
                        $("#mensagemModal").text(data.mensagem).show();
                        window.setTimeout(function () {                           
                            $("#mensagemModal").text("").hide();       
                            var numero = unidade.IdEmpresa;
                            window.location.href = "Index?IdEmpresa=" + numero ;
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

    ListarPessoa: function (id) {
        window.location.href = "/Pessoa/Index?IdUnidade=" + id;
    },

    Editar: function (idUnidade) {
        var url = "/Unidade/EditarUnidade";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { id: idUnidade }
            , cache: false
        }).done(function (data) {
            if (data != null) {
                $("#IdUnidade").val(data.data.idUnidade);
                $("#IdEmpresa").val(data.data.idEmpresa);
                $("#Nome").val(data.data.nome);
                $("#CEP").val(data.data.cep);
                $("#Endereco").val(data.data.endereco).attr("Readonly", true);
                $("#Bairro").val(data.data.bairro).attr("Readonly", true);
                $("#Numero").val(data.data.numero);
                $("#Cidade").val(data.data.cidade).attr("Readonly", true);
                $("#Estado").val(data.data.estado).attr("Readonly", true);
                $("#Pais").val(data.data.pais);
                $("#IdStatus").val(data.data.idStatus);
                $("#NomeContato").val(data.data.nomeContato);
                $("#Telefone").val(data.data.telefone);
                $("#Email").val(data.data.email);
                $("#DataCadastro").val(data.data.dataCadastro);

                $("#btnSalvarUnidade").show();
                $("#ModalCadastrarUnidade").modal('show');
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

    $(".cepClass").mask("99999-999");

    var url = window.location.pathname;
    if ((url == "/") || (url == "/Unidade") || (url == "/Unidade/Index") || (url == "/Unidade/")) {
        Unidade.Listar();
    }

    $("#btnSalvarUnidade").on("click", function () {
        Unidade.Salvar();
    });

    $("#btVoltar").on("click", function () {
        window.location.href = "/Empresa";
    });

    $('#btNovo').on("click", function () {
        $("#IdUnidade").val("0");
        $("#IdEmpresa").val("").attr("Readonly", false);
        $("#Nome").val("").attr("Readonly", false);
        $("#CEP").val("").attr("Readonly", false);
        $("#Endereco").val("").attr("Readonly", true);
        $("#Numero").val("").attr("Readonly", false);
        $("#Bairro").val("").attr("Readonly", true);
        $("#Cidade").val("").attr("Readonly", true);
        $("#Estado").val("").attr("Readonly", true);
        $("#Pais").val("").attr("Readonly", false);
        $("#IdStatus").val("1").attr("Readonly", true);
        $("#NomeContato").val("");
        $("#Telefone").val("");
        $("#Email").val("");
        $("#DataCadastro").attr("Readonly", false);

        $("#btnSalvarUnidade").show();
        $("#ModalCadastrarUnidade").modal('show');
    });

    $('#btPesquisar').on("click", function () {
        Unidade.Listar();
    });

    $('#btnFecharUnidade').on("click", function () {
        $("#IdUnidade").val("0");
        $("#IdEmpresa").val("");
        $("#Nome").val("");
        $("#CEP").val("");
        $("#Endereco").val("");
        $("#Numero").val("");
        $("#Bairro").val("");
        $("#Cidade").val("");
        $("#Estado").val("");
        $("#Pais").val("");
        $("#IdStatus").val("");
        $("#NomeContato").val("");
        $("#Telefone").val("");
        $("#Email").val("");
        $("#DataCadastro").val("");

        $("#ModalCadastrarUnidade").modal('hide');
    });

    $("#CEP").blur(function () {
        var cep = $("#CEP").val().replace(/\D/g, '');
        if (cep.length == 0) {
            $("#CEP").focus();
            return
        }
        else if (cep.length != 8) {
            $("#mensagemModal").text("CEP inválido.").show();
            limpa_formulário_cep();
            $("#CEP").focus();

            window.setTimeout(function () {
                $("#mensagemModal").text("").hide();
            }, 2000);
            return
        };

        $.getJSON("https://viacep.com.br/ws/" + cep + "/json/?callback=?", function (dados) {

            if (!("erro" in dados)) {
                $("#Endereco").val(dados.logradouro);
                $("#Bairro").val(dados.bairro);
                $("#Cidade").val(dados.localidade);
                $("#Estado").val(dados.uf);
            }
            else {
                $("#mensagemModal").text("CEP não encontrado.").show();
                limpa_formulário_cep();
                $("#CEP").focus();
                window.setTimeout(function () {
                    $("#mensagemModal").text("").hide();
                }, 2000);
            }
        });
    });

    function limpa_formulário_cep() {
        $("#Endereco").val("");
        $("#Bairro").val("");
        $("#Cidade").val("");
        $("#Estado").val("");
    }

    function montaPais() {
        $.ajax({
            type: 'GET',
            url: 'http://api.londrinaweb.com.br/PUC/Paisesv2/0/1000',
            contentType: "application/json; charset=utf-8",
            dataType: "jsonp",
            async: false
        }).done(function (response) {

            paises = '';

            $.each(response, function (p, pais) {

                //if (pais.Pais == "") {

                //    paises += '<option value="' + pais.Sigla + '">' + pais.Pais + '</option>';
                //    //paises += '<option value="' + pais.Sigla + '" selected>' + pais.Pais + '</option>';
                //} else {
                //    paises += '<option value="' + pais.Pais + '" selected>' + pais.Pais + '</option>';
                //    //paises += '<option value="' + pais.Sigla + '">' + pais.Pais + '</option>';
                //}
                paises += '<option value="' + pais.Pais + '">' + pais.Pais + '</option>';

            });

            // PREENCHE O SELECT DE PAÍSES
            $('#Pais').html(paises);

            //// PREENCHE O SELECT DE ACORDO COM O VALOR DO PAÍS
            //montaUF($('#pais').val());

           //VERIFICA A MUDANÇA DO VALOR DO SELECT DE PAÍS
            $('#Pais').change(function () {

                //$('#paisText').append();

                //if ($('#pais').val()) {
                //    // SE O VALOR FOR BR E CONFIRMA OS SELECTS
                //    $('#estado').remove();
                //    $('#cidade').remove();
                //$('#campo_estado').append('<select id="estado"></select>');
                //    $('#campo_cidade').append('<select id="cidade"></select>');

                //} 
            })

        });
    }

    montaPais();
});