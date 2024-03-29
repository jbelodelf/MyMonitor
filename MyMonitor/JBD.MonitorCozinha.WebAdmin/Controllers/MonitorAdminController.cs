﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using AutoMapper;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.WebAdmin.Models;
using JBD.MonitorCozinha.WebAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebAdmin.Controllers
{
    public class MonitorAdminController : Controller
    {
        private readonly IMapper _mapper;
        private readonly MonitorAdminServiceWeb _monitorAdminServiceWeb;

        public MonitorAdminController(IMapper mapper)
        {
            _mapper = mapper;
            _monitorAdminServiceWeb = new MonitorAdminServiceWeb(_mapper);
        }

        // GET: Monitor
        public ActionResult Index(int IdUnidade, string NomeUnidade)
        {
            if (!Controle.ValidarUsuarioLogado()){ return RedirectToAction("Index", "Login"); }
            Controle.ControleAcesso.IdUnidade = IdUnidade;
            Controle.ControleAcesso.Unidade = NomeUnidade;

            return View();
        }

        // GET: Listar
        public ActionResult Listar(int IdEmpresa, int IdUnidade)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }
            //Controle.monitorCozinhaViewModel.beep = false;
            ViewBag.Beep = false;

            List<NumeroPedidoViewModel> numeroPedidoViewModel = new List<NumeroPedidoViewModel>();

            numeroPedidoViewModel = _monitorAdminServiceWeb.ListarNumeroPedidos(IdEmpresa, IdUnidade);

            foreach (var numero in numeroPedidoViewModel.Where(n => n.IdStatusPedido == StatusPedidoEnum.Fazendo && n.Controle == 1 ))
            {
                numero.Controle = 2;
                _monitorAdminServiceWeb.AlterarNumeroPedido(numero);
            }

            foreach (var numero in numeroPedidoViewModel.Where(n => n.IdStatusPedido == StatusPedidoEnum.Fazendo && n.Controle == 0))
            {
                numero.Controle = 1;
                _monitorAdminServiceWeb.AlterarNumeroPedido(numero);
                ViewBag.Beep = true;
            }

            ////-------------------------------------------------------------------------------------------------------------------------------------------------
            //if (numeroPedidoViewModel.Where(p => p.IdStatusPedido == StatusPedidoEnum.Fazendo).Any())
            //{
            //    if (!Controle.monitorCozinhaViewModel.Carregado)
            //    {
            //        Controle.numerosPedidoCacheCozinha.AddRange(numeroPedidoViewModel.Where(p => p.IdStatusPedido == StatusPedidoEnum.Fazendo).ToList());
            //        Controle.monitorCozinhaViewModel.Carregado = true;
            //    }
            //    else
            //    {
            //        foreach (var numeroPedido in numeroPedidoViewModel.Where(p => p.IdStatusPedido == StatusPedidoEnum.Fazendo).ToList())
            //        {
            //            if (!Controle.numerosPedidoCacheCozinha.Where(n => n.IdNumeroPedido == numeroPedido.IdNumeroPedido).Any())
            //            {
            //                Controle.monitorCozinhaViewModel.beep = true;
            //                numeroPedido.NovoNumero = true;
            //            }
            //        }

            //        Controle.numerosPedidoCacheCozinha = new List<NumeroPedidoViewModel>();
            //        Controle.numerosPedidoCacheCozinha.AddRange(numeroPedidoViewModel.Where(p => p.IdStatusPedido == StatusPedidoEnum.Fazendo).ToList());
            //    }
            //}
            //else
            //{
            //    Controle.numerosPedidoCacheCozinha = new List<NumeroPedidoViewModel>();
            //    Controle.monitorCozinhaViewModel.Carregado = true;
            //}
            ////-------------------------------------------------------------------------------------------------------------------------------------------------

            return PartialView("~/Views/MonitorAdmin/MainMonitor.cshtml", numeroPedidoViewModel.OrderBy(n => n.IdNumeroPedido));
        }

        // GET: MonitorAdmin/AtualizaStatus/1/5
        public ActionResult AlterarNumeroPedido(int IdNumeroPedido, StatusPedidoEnum Idstatus)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

            NumeroPedidoViewModel numeroPedidoVM = _monitorAdminServiceWeb.ObterNumeroPedido(IdNumeroPedido);
            numeroPedidoVM.IdStatusPedido = Idstatus;
            if (Idstatus == StatusPedidoEnum.Pronto)
            {
                numeroPedidoVM.Controle = 0;
                numeroPedidoVM.DataPronto = DateTime.Now;
            }
            else if (Idstatus == StatusPedidoEnum.Entregue)
            {
                numeroPedidoVM.DataFinalizacao = DateTime.Now;
            }
            _monitorAdminServiceWeb.AlterarNumeroPedido(numeroPedidoVM);

            return Json(new { resultado = true });
        }

        // POST: MonitorAdmin/InserirNumeroPedido/
        [HttpPost]
        public ActionResult InserirNumeroPedido(int IdEmpresa, int IdUnidade, string NumeroPedido)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

            NumeroPedidoViewModel numeroPedidoVM = new NumeroPedidoViewModel() {
                IdEmpresa = IdEmpresa,
                IdUnidade = IdUnidade,
                NumeroPedido = NumeroPedido,
                IdStatusPedido = StatusPedidoEnum.Fazendo,
                DataCadastro = DateTime.Now,
                Controle = 0
            };
            _monitorAdminServiceWeb.CadastrarNumeroPedido(numeroPedidoVM);
            bool retorno = true;

            return Json(new { resultado = retorno });
        }

        // GET: MonitorAdmin/DeletarNumeroPedido/1/5
        public ActionResult DeletarNumeroPedido(int IdNumeroPedido)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

            bool retorno = _monitorAdminServiceWeb.DeletarNumeroPedido(IdNumeroPedido);
            return Json(new { resultado = retorno });
        }
    }
}