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
                                window.location.href = "Index?IdEmpresa=" + numero;
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

    montaPais();

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
        var paises = {
            01: { Pais: "Africa do Sul" },
            02: { Pais: "Albânia" },
            03: { Pais: "Alemanha" },
            04: { Pais: "Andorra" },
            05: { Pais: "Angola" },
            06: { Pais: "Anguilla" },
            07: { Pais: "Antigua" },
            08: { Pais: "Arábia Saudita" },
            09: { Pais: "Argentina" },
            10: { Pais: "Armênia" },
            11: { Pais: "Aruba" },
            12: { Pais: "Austrália" },
            13: { Pais: "Áustria" },
            14: { Pais: "Azerbaijão" },
            15: { Pais: "Bahamas" },
            16: { Pais: "Bahrein" },
            17: { Pais: "Bangladesh" },
            18: { Pais: "Barbados" },
            19: { Pais: "Bélgica" },
            20: { Pais: "Benin" },
            21: { Pais: "Bermudas" },
            22: { Pais: "Botsuana" },
            23: { Pais: "Brasil" },
            24: { Pais: "Brunei" },
            25: { Pais: "Bulgária" },
            26: { Pais: "Burkina Fasso" },
            27: { Pais: "botão" },
            28: { Pais: "Cabo Verde" },
            29: { Pais: "Camarões" },
            30: { Pais: "Camboja" },
            31: { Pais: "Canadá" },
            32: { Pais: "Cazaquistão" },
            33: { Pais: "Chade" },
            34: { Pais: "Chile" },
            35: { Pais: "China" },
            36: { Pais: "Cidade do Vaticano" },
            37: { Pais: "Colômbia" },
            38: { Pais: "Congo" },
            39: { Pais: "Coréia do Sul" },
            40: { Pais: "Costa do Marfim" },
            41: { Pais: "Costa Rica" },
            42: { Pais: "Croácia" },
            43: { Pais: "Dinamarca" },
            44: { Pais: "Djibuti" },
            45: { Pais: "Dominica" },
            46: { Pais: "EUA" },
            47: { Pais: "Egito" },
            48: { Pais: "El Salvador" },
            49: { Pais: "Emirados Árabes" },
            50: { Pais: "Equador" },
            51: { Pais: "Eritréia" },
            52: { Pais: "Escócia" },
            53: { Pais: "Eslováquia" },
            54: { Pais: "Eslovênia" },
            55: { Pais: "Espanha" },
            56: { Pais: "Estônia" },
            57: { Pais: "Etiópia" },
            58: { Pais: "Fiji" },
            59: { Pais: "Filipinas" },
            60: { Pais: "Finlândia" },
            61: { Pais: "França" },
            62: { Pais: "Gabão" },
            63: { Pais: "Gâmbia" },
            64: { Pais: "Gana" },
            65: { Pais: "Geórgia" },
            66: { Pais: "Gibraltar" },
            67: { Pais: "Granada" },
            68: { Pais: "Grécia" },
            69: { Pais: "Guadalupe" },
            70: { Pais: "Guam" },
            71: { Pais: "Guatemala" },
            72: { Pais: "Guiana" },
            73: { Pais: "Guiana Francesa" },
            74: { Pais: "Guiné-bissau" },
            75: { Pais: "Haiti" },
            76: { Pais: "Holanda" },
            77: { Pais: "Honduras" },
            78: { Pais: "Hong Kong" },
            79: { Pais: "Hungria" },
            80: { Pais: "Iêmen" },
            81: { Pais: "Ilhas Cayman" },
            82: { Pais: "Ilhas Cook" },
            83: { Pais: "Ilhas Curaçao" },
            84: { Pais: "Ilhas Marshall" },
            85: { Pais: "Ilhas Turks & Caicos" },
            86: { Pais: "Ilhas Virgens (brit.)" },
            87: { Pais: "Ilhas Virgens(amer.)" },
            88: { Pais: "Ilhas Wallis e Futuna" },
            89: { Pais: "Índia" },
            90: { Pais: "Indonésia" },
            91: { Pais: "Inglaterra" },
            92: { Pais: "Irlanda" },
            93: { Pais: "Islândia" },
            94: { Pais: "Israel" },
            95: { Pais: "Itália" },
            96: { Pais: "Jamaica" },
            97: { Pais: "Japão" },
            98: { Pais: "Jordânia" },
            99: { Pais: "Kuwait" },
            100: { Pais: "Latvia" },
            101: { Pais: "Líbano" },
            102: { Pais: "Liechtenstein" },
            103: { Pais: "Lituânia" },
            104: { Pais: "Luxemburgo" },
            105: { Pais: "Macau" },
            106: { Pais: "Macedônia" },
            107: { Pais: "Madagascar" },
            108: { Pais: "Malásia" },
            109: { Pais: "Malaui" },
            110: { Pais: "Mali" },
            111: { Pais: "Malta" },
            112: { Pais: "Marrocos" },
            113: { Pais: "Martinica" },
            114: { Pais: "Mauritânia" },
            115: { Pais: "Mauritius" },
            116: { Pais: "México" },
            117: { Pais: "Moldova" },
            118: { Pais: "Mônaco" },
            119: { Pais: "Montserrat" },
            120: { Pais: "Nepal" },
            121: { Pais: "Nicarágua" },
            122: { Pais: "Niger" },
            123: { Pais: "Nigéria" },
            124: { Pais: "Noruega" },
            125: { Pais: "Nova Caledônia" },
            126: { Pais: "Nova Zelândia" },
            127: { Pais: "Omã" },
            128: { Pais: "Palau" },
            129: { Pais: "Panamá" },
            130: { Pais: "Papua-nova Guiné" },
            131: { Pais: "Paquistão" },
            132: { Pais: "Peru" },
            133: { Pais: "Polinésia Francesa" },
            134: { Pais: "Polônia" },
            135: { Pais: "Porto Rico" },
            136: { Pais: "Portugal" },
            137: { Pais: "Qatar" },
            138: { Pais: "Quênia" },
            139: { Pais: "Rep. Dominicana" },
            140: { Pais: "Rep. Tcheca" },
            141: { Pais: "Reunion" },
            142: { Pais: "Romênia" },
            143: { Pais: "Ruanda" },
            144: { Pais: "Rússia" },
            145: { Pais: "Saipan" },
            146: { Pais: "Samoa Americana" },
            147: { Pais: "Senegal" },
            148: { Pais: "Serra Leone" },
            149: { Pais: "Seychelles" },
            150: { Pais: "Singapura" },
            151: { Pais: "Síria" },
            152: { Pais: "Sri Lanka" },
            153: { Pais: "St. Kitts & Nevis" },
            154: { Pais: "St. Lúcia" },
            155: { Pais: "St. Vincent" },
            156: { Pais: "Sudão" },
            157: { Pais: "Suécia" },
            158: { Pais: "Suiça" },
            159: { Pais: "Suriname" },
            160: { Pais: "Tailândia" },
            161: { Pais: "Taiwan" },
            162: { Pais: "Tanzânia" },
            163: { Pais: "Togo" },
            164: { Pais: "Trinidad & Tobago" },
            165: { Pais: "Tunísia" },
            166: { Pais: "Turquia" },
            167: { Pais: "Ucrânia" },
            168: { Pais: "Uganda" },
            169: { Pais: "Uruguai" },
            170: { Pais: "Venezuela" },
            171: { Pais: "Vietnã" },
            172: { Pais: "Zaire" },
            173: { Pais: "Zâmbia" },
            174: { Pais: "Zimbábue" },
        };


        $.each(paises, function (p, pais) {

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
        });
    }
});