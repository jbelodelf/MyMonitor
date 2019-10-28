using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using JBD.MonitorCozinha.CrossCutting;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.WebAdmin.Models;
using JBD.MonitorCozinha.WebAdmin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebAdmin.Controllers
{
    public class UnidadeController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UnidadeServiceWeb _unidadeServiceWeb;
        private readonly UsuarioServiceWeb _usuarioServiceWeb;
        private readonly EmailService emailService;

        public UnidadeController(IMapper mapper)
        {
            _mapper = mapper;
            _unidadeServiceWeb = new UnidadeServiceWeb(_mapper);
            _usuarioServiceWeb = new UsuarioServiceWeb(_mapper);
            emailService = new EmailService();
        }

        // GET: Unidade
        public ActionResult Index(int IdEmpresa = 0)
        {
            var unidadeViewModel = new UnidadeViewModel();
            unidadeViewModel.IdEmpresa = IdEmpresa;

            var nomeEmpresa = new UnidadeViewModel();

            //Recuperando Nome Empresa por Nome Fantasia
            EmpresaServiceWeb empresaServiceWeb = new EmpresaServiceWeb(_mapper);
            var nome = empresaServiceWeb.ObterEmpresa(IdEmpresa).NomeFantasia;

            //var Nomeaqui = nome.RazaoSocial;
            unidadeViewModel.NomeEmpresa = nome;

            return View(unidadeViewModel);
        }

        public ActionResult ListarUnidades(string nomeUnidade, int IdEmpresa)
        {
            var empresaViewModel = new EmpresaViewModel();

            if (nomeUnidade != null)
            {
                EmpresaServiceWeb unidadeServiceWeb = new EmpresaServiceWeb(_mapper);
                var empresaVM = unidadeServiceWeb.ObterEmpresa(IdEmpresa);

                empresaViewModel = empresaVM;               
                var unidades = empresaVM.Unidades.Where(c => c.Nome.ToUpper().Contains(nomeUnidade.Trim().ToUpper())).ToList();
                empresaViewModel.Unidades = new List<UnidadeViewModel>();

                empresaViewModel.Unidades.AddRange(unidades);

                return PartialView("~/Views/Unidade/_listarUnidades.cshtml", empresaViewModel);
            }
            else
            {
                // empresaViewModel = new EmpresaViewModel();
                if (IdEmpresa > 0)
                {
                    empresaViewModel = ObterListaUnidades(IdEmpresa);
                }
            }
            return PartialView("~/Views/Unidade/_listarUnidades.cshtml", empresaViewModel);
        }

        // GET: Unidade/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Unidade/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Unidade/Create
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult SalvarUnidade(UnidadeViewModel unidade)
        {
            try
            {
                unidade = _unidadeServiceWeb.CadastrarUnidade(unidade);

                if (unidade != null)
                {
                    Random randNum = new Random();
                    var Numero = randNum.Next().ToString().Substring(5);

                    var padraoPassword = "cozinha" + Numero + unidade.IdUnidade;
                    var usuarioViewModel = new UsuarioViewModel()
                    {
                        IdUsuario = 0,
                        IdEmpresa = unidade.IdEmpresa,
                        IdUnidade = unidade.IdUnidade,
                        IdPessoa = 0,
                        IdTipo = TipoUsuarioEnum.Cozinha,
                        IdStatus = (int)StatusEnum.Ativo,
                        UserName = "cozinha" + unidade.IdUnidade.ToString(),
                        Password = GeraradorDeHash.GerarHash256(padraoPassword),
                        DataCadastro = DateTime.Now,
                        Pessoa = null,
                        Unidade = null
                    };

                    var usuario = _usuarioServiceWeb.CadastrarUsuario(usuarioViewModel);

                    if (usuario.IdUsuario > 0)
                    {
                        string mensagem = "";
                        string email = unidade.Email;

                        mensagem = "<html><head><title>Dados para acesso</title></head><body>";
                        mensagem += "<h1>Olá " + unidade.NomeContato + "</h1>";
                        mensagem += "<p>Segue as informações para acessar o Monitor de Cozinha.</p>";
                        mensagem += "<p></p>";
                        mensagem += "<p>Usuário: " + usuario.UserName + "</p>";
                        mensagem += "<p>Senha: " + padraoPassword + "</p>";
                        mensagem += "<p>http://www.mymonitor.com.br</p>";
                        mensagem += "<p>Este usuário lhe dará acesso aos recursos do Monitor de Administrativo, para atualizar o andamento das senha</p>";
                        mensagem += "</body></html>";

                        //Enviar e-mail para acesso
                        var retorno = emailService.EnvioEmail(email, mensagem);
                    }
                }

                return Json (new {mensagem = "Registro salvo com sucesso", retorno = "200" });
            }
            catch(Exception ex)
            {
                return Json(new { mensagem = "Ocorreu um erro ao tentar salvar a unidade", retorno = "400" });
            }
        }

        // GET: Unidade/Edit/5
        public ActionResult EditarUnidade(int id)
        {
            UnidadeServiceWeb unidadeServiceWeb = new UnidadeServiceWeb(_mapper);
            UnidadeViewModel unidadeVM = new UnidadeViewModel();

            unidadeVM = unidadeServiceWeb.ObterUnidade(id);

            return Json(new { retorno = 200, data = unidadeVM });
        }

        // POST: Unidade/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public ActionResult EditarUnidade(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Unidade/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Unidade/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        #region Methods

        private EmpresaViewModel ObterListaUnidades(int IdEmpresa)
        {
            //UnidadeServiceWeb unidadeServiceWeb = new UnidadeServiceWeb(_mapper);
            EmpresaServiceWeb unidadeServiceWeb = new EmpresaServiceWeb(_mapper);

            EmpresaViewModel unidadesViewModel = new EmpresaViewModel();
            var unidadesDTO = unidadeServiceWeb.ObterEmpresa(IdEmpresa);
         
            unidadesViewModel = _mapper.Map<EmpresaViewModel>(unidadesDTO);

            return unidadesViewModel;
        }

        #endregion
    }
}