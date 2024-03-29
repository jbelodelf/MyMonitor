﻿using System;
using System.Linq;
using AutoMapper;
using Hanssens.Net;
using JBD.MonitorCozinha.CrossCutting;
using JBD.MonitorCozinha.WebAdmin.Models;
using JBD.MonitorCozinha.WebAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebAdmin.Controllers
{
    public class LoginController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UsuarioServiceWeb _usuarioServiceWeb;
        private readonly LembreteSenhaServiceWeb _lembreteSenhaServiceWeb;
        private readonly EmailService _emailService;
        private readonly EmpresaServiceWeb _empresaServiceWeb;
        private readonly UnidadeServiceWeb _unidadeServiceWeb;

        public LoginController(IMapper mapper)
        {
            _mapper = mapper;
            _usuarioServiceWeb = new UsuarioServiceWeb(_mapper);
            _empresaServiceWeb = new EmpresaServiceWeb(_mapper);
            _unidadeServiceWeb = new UnidadeServiceWeb(_mapper);
            _lembreteSenhaServiceWeb = new LembreteSenhaServiceWeb(_mapper);
            _emailService = new EmailService();
        }

        // GET: Login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Logar(string userName, string senha)
        {
            string mansagem = "";
            bool logado = false;
            bool autenticar = false;
            var usuario = new UsuarioViewModel();
            try
            {
                usuario = _usuarioServiceWeb.UsuarioLogar(userName, GeraradorDeHash.GerarHash256(senha));
                if (usuario != null)
                {
                    var empresa = _empresaServiceWeb.ObterEmpresa(usuario.IdEmpresa);
                    if (empresa?.IdStatus != 1)
                    {
                        mansagem = "Esta unidade não está mais ativa!!!";
                    }
                    else
                    {
                        autenticar = true;
                    }

                    if (usuario.IdUnidade > 0 && autenticar)
                    {
                        if (empresa.Unidades.FirstOrDefault(u => u.IdUnidade == usuario.IdUnidade)?.IdStatus != 1)
                        {
                            mansagem = "Esta cozinha não está mais ativa!!!";
                            autenticar = false;
                        }
                    }

                    if (autenticar)
                    {
                        Controle.AtualzarAcesso(usuario);
                        logado = true;
                    }
                }
                else
                {
                    mansagem = "Usuário ou senha não confere!!!";
                }
            }
            catch (Exception ex)
            {
                mansagem = "Erro: Entre em contato com o Administrador!";
            }

            return Json(new { message = mansagem, logado = logado, usuario = usuario });
        }

        public ActionResult Home()
        {
            return View();
        }

        [HttpPost]
        public ActionResult EmailLembreteSenha(string UserName, string Email)
        {
            var mensagemRetorno = "Email enviado com sucesso";
            var usuario = _usuarioServiceWeb.UsuarioByUsuerName(UserName);
            var emailValidar = "";
            if (usuario != null)
            {
                if (usuario.IdTipo == Domain.Enuns.TipoUsuarioEnum.Operacional)
                {
                    emailValidar = _empresaServiceWeb.ObterEmpresa(usuario.IdEmpresa)?.Email ?? "";
                }
                else if (usuario.IdTipo == Domain.Enuns.TipoUsuarioEnum.Cozinha)
                {
                    emailValidar = _unidadeServiceWeb.ObterUnidade(usuario.IdUnidade)?.Email ?? "";
                }

                if (emailValidar.Trim() == Email.Trim())
                {
                    var NovaChave = Guid.NewGuid();
                    LembreteSenhaViewModel lembreteSenhaViewModel = new LembreteSenhaViewModel()
                    {
                        IdUsuario = usuario.IdUsuario,
                        IdPessoa = usuario.IdPessoa,
                        UserName = usuario.UserName,
                        Chave = NovaChave,
                        ChaveValida = true,
                        DataGerado = DateTime.Now
                    };

                    _lembreteSenhaServiceWeb.CadastrarLembreteSenha(lembreteSenhaViewModel);

                    string emailMensagem = "";
                    emailMensagem = "<html><head><title>Dados para acesso</title></head><body>";
                    emailMensagem += "<h1>Olá " + usuario.Pessoa.Nome + "</h1>";
                    emailMensagem += "<p>Segue as informações para alterar a senha de acesso do usuário [" + usuario.UserName + "] no Monitor de Cozinha.</p>";
                    emailMensagem += "<p></p>";
                    emailMensagem += "<p>Usuário: " + usuario.UserName + "</p>";
                    emailMensagem += "<p>Clique no link para alterar a sua senha</p>";
                    emailMensagem += "<p>http://www.mymonitor.com.br/Login/NovaSenha?chave=" + NovaChave + "</p>";
                    emailMensagem += "</body></html>";

                    //Enviar e-mail para acesso
                    var retorno = _emailService.EnvioEmailLembrate(Email, emailMensagem);
                }
                else
                {
                    mensagemRetorno = "Os dados informados não confere!!!";
                }
            }

            return Json(new { mensagem = mensagemRetorno, retorno = "200" });
        }

        // GET: Login/NovaSenha/5
        public ActionResult NovaSenha(Guid chave)
        {
            LembreteSenhaViewModel lembreteSenha = null;
            try
            {
                lembreteSenha = _lembreteSenhaServiceWeb.ObterLembreteSenha(chave);
                if (lembreteSenha != null)
                {
                    if (lembreteSenha.ChaveValida)
                    {
                        var tempo = lembreteSenha.DataGerado.AddMinutes(30);
                        if (tempo >= DateTime.Now)
                        {
                            lembreteSenha.ChaveValida = false;
                            _lembreteSenhaServiceWeb.AlterarLembreteSenha(lembreteSenha);
                        }
                        else
                        {
                            lembreteSenha.ChaveValida = false;
                            _lembreteSenhaServiceWeb.AlterarLembreteSenha(lembreteSenha);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw;
            }
            return View(lembreteSenha);
        }

        // POST: Login/Edit/5
        [HttpPost]
        public ActionResult NovaSenha(int idUsuario, string Password)
        {
            string mensagem = "";
            int status = 402;
            try
            {
                var usuario = _usuarioServiceWeb.ObterUsuario(idUsuario);
                
                if (usuario != null)
                {
                    usuario.Password = GeraradorDeHash.GerarHash256(Password);
                    _usuarioServiceWeb.AlterarUsuario(usuario);
                }

                status = 200;
                mensagem = "Senha alterada com sucesso!!!";
            }
            catch (Exception ex)
            {
                mensagem = "Ocorreu um erro e não foi possível alterar sua senha!!!";
            }

            return Json(new { mensagem = mensagem, retorno = status });
        }
    }
}