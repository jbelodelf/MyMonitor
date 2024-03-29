﻿Usuario = {
    Login: function () {
        var userName = $("#userName").val();
        var password = $("#password").val();

        var url = "/Login/Logar";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "POST"
            , async: false
            , data: { userName: userName, senha: password }
            , cache: false
        }).done(function (data) {
            if (data.logado) {

                localStorage.setItem('IdEmpresa', data.usuario.idEmpresa);
                localStorage.setItem('IdUnidade', data.usuario.idUnidade);
                localStorage.setItem('IdUsuario', data.usuario.idUsuario);
                localStorage.setItem('IdTipo', data.usuario.idTipo);
                localStorage.setItem('Unidade', '');
                localStorage.setItem('UnidadeCor', '');

                if (data.usuario.unidade != null) {
                    localStorage.setItem('Unidade', data.usuario.unidade.nome);
                    localStorage.setItem('UnidadeCor', data.usuario.unidade.unidadeCor);
                }

                window.location.href = "Login/Home";
            }
            else {
                $("#mensagemModal").text(data.message).show();
                window.setTimeout(function () {
                    $("#mensagemModal").text("").hide();
                    window.location.href = "/Login";
                }, 3000);
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    EmailLembreteSenha: function () {
        var userName = $("#NomeUsuario").val();
        var emailPF = $("#EmailPF").val();

        var url = "/Login/EmailLembreteSenha";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "POST"
            , async: false
            , data: { UserName: userName, Email: emailPF }
            , cache: false
        }).done(function (data) {
            

        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    AlterarSenha: function () {
        var password = $("#Password").val();
        var idUsuario = $("#idUsuario").val();

        var url = "/Login/NovaSenha";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "POST"
            , async: false
            , data: { Password: password, IdUsuario: idUsuario }
            , cache: false
        }).done(function (data) {
            if (data.retorno == "200") {
                $("#mensagem").text(data.mensagem).show();
                window.setTimeout(function () {
                    $("#mensagem").text("").hide();
                    window.location.href = "/Login";
                }, 3000);
            }
            else {
                $("#mensagem").text('Erro:' + data.mensagem).show();
                window.setTimeout(function () {
                    $("#mensagem").text("").hide();
                    window.location.href = "/Login";
                }, 3000);
                return;
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    Listar: function () {
        $("body").css("padding-top", "2px", "!important");
        $("#TopoPesquisa").css("margin-left", "5px");
        $("#TopoPesquisa").css("margin-right", "5px");
        $("#TopoPesquisa").css("padding-top", "20px");
        $("#TopoPesquisa").css("padding-bottom", "15px");
        var empresa = $("#EmpresaPesquisar").val();

        var url = "/Empresa/ListarEmpresas";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { nomeEmpresa: empresa }
            , cache: false
        }).done(function (data) {
            $("#divListarEmpresas").html(data);

            $("#cabecalho").css("background-color", "#5B9BD5")
            $("#cabecalho").css("color", "#FFFFFF")
            $("#colNome").css("width", "680");
            AplicarDataTable('tbListarEmpresas', '0', "asc", 20, false, undefined, true);
            $("#tbListarEmpresas").css("margin-top", "5px");
            $("#tbListarEmpresas").css("float", "right");
            $("#footer").css("margin-top", "50px");
            $("#footer").css("height", "40px");
            $("#footer").css("padding", "10px");
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    Salvar: function () {
        var isValido = true;
        if ($("#RazaoSocial").val() == "") {
            isValido = false;
        }
        else if ($("#NomeFantasia").val() == "") {
            isValido = false;
        }
        else if ($("#CNPJ").val() == "") {
            isValido = false;
        }
        else if ($("#InscricaoEstadual").val() == "") {
            isValido = false;
        }
        else if ($("#InscricaoMunicipal").val() == "") {
            isValido = false;
        }
        else if ($("#IdStatus").val() == "") {
            isValido = false;
        }
        else if ($("#DataCadastro").val() == "") {
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
                var url = "/Empresa/SalvarEmpresa";

                var cnpj = $("#CNPJ").val().replace(/\D/g, '');

                empresa = {
                    IdEmpresa: $("#IdEmpresa").val(),
                    RazaoSocial: $("#RazaoSocial").val(),
                    NomeFantasia: $("#NomeFantasia").val(),
                    CNPJ: cnpj,
                    InscricaoEstadual: $("#InscricaoEstadual").val(),
                    InscricaoMunicipal: $("#InscricaoMunicipal").val(),
                    IdStatus: $("#IdStatus").val(),
                    DataCadastro: $("#DataCadastro").val()
                };
                $.ajax({
                    url: url
                    , datatype: "json"
                    , type: "POST"
                    , async: false
                    , data: { empresa: empresa }
                    , cache: false
                }).done(function (data) {
                    if (data.retorno == "200") {
                        $("#mensagemModal").text(data.mensagem).show();
                        window.setTimeout(function () {
                            $("#mensagemModal").text("").hide();
                            window.location.href = "/Empresa";
                        }, 3000);
                    }
                    else {
                        $("#mensagemModal").text('Erro:' + data.mensagem).show();
                        window.setTimeout(function () {
                            $("#mensagemModal").text("").hide();
                            window.location.href = "/Empresa";
                        }, 3000);
                        return;
                    }
                }).fail(function (jqXHR, exception) {
                    TratamentoDeErro(jqXHR, exception);
                });
            }
        });
    },

    Editar: function (idEmpresa) {
        var url = "/Empresa/EditarEmpresa";
        $.ajax({
            url: url
            , datatype: "json"
            , type: "GET"
            , async: false
            , data: { id: idEmpresa }
            , cache: false
        }).done(function (data) {
            if (data != null) {
                $("#IdEmpresa").val(data.data.idEmpresa);
                $("#RazaoSocial").val(data.data.razaoSocial);
                $("#NomeFantasia").val(data.data.nomeFantasia);
                $("#CNPJ").val(data.data.cnpj);
                $("#InscricaoEstadual").val(data.data.inscricaoEstadual);
                $("#InscricaoMunicipal").val(data.data.inscricaoMunicipal);
                $("#IdStatus").val(data.data.idStatus);
                $("#DataCadastro").val(data.data.dataCadastro);

                $("#btnSalvarEmpresa").show();
                $("#ModalCadastrarEmpresa").modal('show');
            }
            else {
                return;
            }
        }).fail(function (jqXHR, exception) {
            TratamentoDeErro(jqXHR, exception);
        });
    },

    UnidadeAdmin: function (funcionalidade) {
        window.location.href = "/Home/Index?funcionalidade=" + funcionalidade + "&IdEmpresa=" + localStorage.getItem('IdEmpresa');
    },

    MonitorTV: function (idUnidade, nomeUnidade) {
        localStorage.setItem('IdUnidade', idUnidade);
        window.location.href = "/Monitor/Index?idUnidade=" + idUnidade + "&NomeUnidade=" + nomeUnidade;
    },

    MonitorAdmin: function (idUnidade, nomeUnidade) {
        var idUnidade = localStorage.getItem('IdUnidade');
        var nomeUnidade = localStorage.getItem('Unidade');
        $("#IdUnidade").val(idUnidade);
        window.location.href = "/MonitorAdmin/Index?IdUnidade=" + idUnidade + "&NomeUnidade=" + nomeUnidade;
    },

    LembreteSenha: function () {
        $("#ModalLembreteSenha").modal('show');
    },

    ValidaSenhaDigitada: function () {
        password1 = $("#Password").val();
        password2 = $("#Password2").val();

        if (password1 != password2) {
            $("#mensagem").text("Senha não confere, digite novamente!!!").show();
            window.setTimeout(function () {
                $("#mensagem").text("").hide();
            }, 3000);
        }
        else {
            Usuario.AlterarSenha();
        }
    }
}

$(document).ready(function () {

    //Verifica se está sendo usado o IE, Edge ou Firefox
    myFunction();

    $("#btAdmin").on("click", function () {
        window.location.href = "/MonitorAdmin";
    });

    $("#btGestao").on("click", function () {
        window.location.href = "/Empresa";
    });

    var altura = window.screen.availHeight;
    var largura = window.screen.availWidth;
    $("#CadastroSenhaMotoboy").css('height', (altura - 230));

    $("#versaoApp").html("Versão: 1.1.0.0");
})

function myFunction() {
    if ((navigator.userAgent.indexOf("MSIE") != -1) || (!!document.documentMode == true)) {
        $("#ModalNavegador").modal('show');
    }
    else if (!!navigator.userAgent.match(/Trident\/7\./) || window.navigator.userAgent.indexOf("Edge") > -1) {
        $("#ModalNavegador").modal('show');
    }
    else if (navigator.userAgent.indexOf("Firefox") != -1) {
        $("#ModalNavegador").modal('show');
    }
    //else if (navigator.userAgent.indexOf("Safari") != -1) {
    //    $("#ModalNavegador").modal('show');
    //}
    //else if ((navigator.userAgent.indexOf("Opera") || navigator.userAgent.indexOf('OPR')) != -1) {
    //    $("#ModalNavegador").modal('show');
    //}
    //else if (navigator.userAgent.indexOf("Chrome") != -1) {
    //    alert('Chrome');
    //}
    //else {
    //    alert('Este navegador não é o Chrome');
    //}
}
