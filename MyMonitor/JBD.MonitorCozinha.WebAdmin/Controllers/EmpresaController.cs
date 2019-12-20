using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Mail;
using System.Threading.Tasks;
using AutoMapper;
using JBD.MonitorCozinha.CrossCutting;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.WebAdmin.Models;
using JBD.MonitorCozinha.WebAdmin.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace JBD.MonitorCozinha.WebAdmin.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IMapper _mapper;
        private readonly EmpresaServiceWeb _empresaServiceWeb;
        private readonly UsuarioServiceWeb _usuarioServiceWeb;
        private readonly EmailService emailService;

        public EmpresaController(IMapper mapper)
        {
            _mapper = mapper;
            _empresaServiceWeb = new EmpresaServiceWeb(_mapper);
            _usuarioServiceWeb = new UsuarioServiceWeb(_mapper);
            emailService = new EmailService();
        }

        // GET: Empresa
        public ActionResult Index()
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }
            return View();
        }

        // GET: Empresa
        public ActionResult ListarEmpresas(string nomeEmpresa)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

            if (nomeEmpresa != null)
            {
                var empresaDTO = _empresaServiceWeb.ListarEmpresas().Where(c => c.NomeFantasia.ToUpper().Contains(nomeEmpresa.Trim().ToUpper())).ToList();
                List<EmpresaViewModel> empresaVM = new List<EmpresaViewModel>();
                empresaVM = _mapper.Map<List<EmpresaViewModel>>(empresaDTO);
                return PartialView("~/Views/Empresa/_listarEmpresas.cshtml", empresaVM);
            }
            else
            {

                List<EmpresaViewModel> empresasViewModel = new List<EmpresaViewModel>();
                EmpresaViewModel empresaVM = new EmpresaViewModel();
                var empresasDTO = _empresaServiceWeb.ListarEmpresas();
                empresasViewModel = _mapper.Map<List<EmpresaViewModel>>(empresasDTO);
                return PartialView("~/Views/Empresa/_listarEmpresas.cshtml", empresasViewModel);
            }
        }

        // GET: Empresa
        public ActionResult ObterUnidadesByEmpresa(int IdEmpresa)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

            EmpresaViewModel empresasViewModel = new EmpresaViewModel();
            //EmpresaViewModel empresaVM = new EmpresaViewModel();
            var empresasDTO = _empresaServiceWeb.ObterEmpresa(IdEmpresa);
            empresasViewModel = _mapper.Map<EmpresaViewModel>(empresasDTO);
            return PartialView("~/Views/Unidade/_listarUnidades.cshtml", empresasViewModel);
        }

        // GET: Empresa/Details/5
        public ActionResult Details(int id)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

            return View();
        }

        // POST: Empresa/Create
        [HttpPost]
        public ActionResult SalvarEmpresa(EmpresaViewModel empresa)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }
            try
            {
                EmpresaViewModel empresaViewModel = new EmpresaViewModel();
                var empresaRetorno = _empresaServiceWeb.CadastrarEmpresa(empresa);

                if(empresaRetorno != null)
                {
                    Random randNum = new Random();
                    var Numero = randNum.Next().ToString().Substring(5);

                    var padraoPassword = "operacional" + Numero + empresaRetorno.IdEmpresa.ToString();
                    var usuarioViewModel = new UsuarioViewModel()
                    {
                        IdUsuario = 0,
                        IdEmpresa = empresaRetorno.IdEmpresa,
                        IdUnidade = 0,
                        IdPessoa = 0,
                        IdTipo = TipoUsuarioEnum.Operacional,
                        IdStatus = (int)StatusEnum.Ativo,
                        UserName = "operacional" + empresaRetorno.IdEmpresa.ToString(),
                        Password = GeraradorDeHash.GerarHash256(padraoPassword),
                        DataCadastro = DateTime.Now,
                        Pessoa = null,
                        Unidade = null
                    };

                    var usuario = _usuarioServiceWeb.CadastrarUsuario(usuarioViewModel);

                    if (usuario.IdUsuario > 0)
                    {
                        string mensagem = "";
                        string email = empresaRetorno.Email;

                        mensagem = "<html><head><title>Dados para acesso</title></head><body>";
                        mensagem += "<h1>Olá " + empresaRetorno.NomeContato + "</h1>";
                        mensagem += "<p>Segue as informações para acessar o Monitor de Cozinha.</p>";
                        mensagem += "<p></p>";
                        mensagem += "<p>Usuário: " + usuario.UserName + "</p>";
                        mensagem += "<p>Senha: " + padraoPassword + "</p>";
                        mensagem += "<p>Este usuário lhe dará o acesso necessário aos recursos do Monitor de TV, para cadastrar novas senha e administra-las</p>";
                        mensagem += "<p>http://www.mymonitor.com.br</p>";
                        mensagem += "</body></html>";

                        //Enviar e-mail para acesso
                        var retorno = emailService.EnvioEmail(email, mensagem);
                    }
                }

                return Json(new { mensagem = "Registro salvo com sucesso", retorno = "200" });
            }
            catch (Exception ex)
            {
                return Json(new { mensagem = "Ocorreu um erro ao tentar gravar os dados", retorno = "402" });
            }
        }

        // GET: Empresa/Edit/5
        public ActionResult EditarEmpresa(int id)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

            EmpresaViewModel empresaVM = new EmpresaViewModel();
            empresaVM = _empresaServiceWeb.ObterEmpresa(id);
            return Json(new { retorno = 200, data = empresaVM });
        }

        // POST: Empresa/Edit/5
        [HttpPost]
        public ActionResult EditarEmpresa(int id, EmpresaViewModel empresa)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

            try
            {
                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Empresa/Delete/5
        public ActionResult Delete(int id)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }
            var empresa = _empresaServiceWeb.ObterEmpresa(id);
            empresa.IdStatus = (int)StatusEnum.Excluido;
            empresa.Unidades = null;
            _empresaServiceWeb.CadastrarEmpresa(empresa);
            return Json(new { mensagem = "Registro excluído com sucesso", retorno = "200" });
        }

        // POST: Empresa/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

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

        public ActionResult VeficaDuplicidadeCnpjCpf(string cnpjcpf)
        {
            var mensagem = "";
            bool retorno = false;
            try
            {
                EmpresaServiceWeb empresaServiceWeb = new EmpresaServiceWeb(_mapper);
                retorno = empresaServiceWeb.VeficaDuplicidadeCnpjCpf(cnpjcpf);

                if (retorno)
                {
                    mensagem = "CNPJ está cadastrado, por favor verifique";
                }
            }
            catch (Exception)
            {
                mensagem = "Ocorreu um erro na veriificação do CNPJ";
            }

            return Json(new { retorno = 200, duplicado = retorno, mensagem = mensagem });
        }
    }
}