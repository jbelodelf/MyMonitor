using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.WebAdmin.Models;
using JBD.MonitorCozinha.WebAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebAdmin.Controllers
{
    public class MonitorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly MonitorServiceWeb _monitorServiceWeb;
        private readonly UnidadeServiceWeb _unidadeServiceWeb;

        public MonitorController(IMapper mapper)
        {
            _mapper = mapper;
            _monitorServiceWeb = new MonitorServiceWeb(_mapper);
            _unidadeServiceWeb = new UnidadeServiceWeb(_mapper);
        }

        // GET: Monitor
        public ActionResult Index(int idUnidade, string NomeUnidade)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }
            Controle.ControleAcesso.IdUnidade = idUnidade;
            Controle.ControleAcesso.Unidade = NomeUnidade;
            Controle.ControleAcesso.UnidadeCor = _unidadeServiceWeb.ObterUnidade(idUnidade)?.UnidadeCor;

            return View();
        }

        // GET: Monitor
        public ActionResult Listar(int IdEmpresa, int IdUnidade)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }
            Controle.monitorCozinhaViewModel.beep = false;

            List<NumeroPedidoViewModel> numeroPedidoViewModel = new List<NumeroPedidoViewModel>();
            var numeroPedidoDTO = _monitorServiceWeb.ListarNumeroPedidos(IdEmpresa, IdUnidade);
            numeroPedidoViewModel = _mapper.Map<List<NumeroPedidoViewModel>>(numeroPedidoDTO);

            //-------------------------------------------------------------------------------------------------------------------------------------------------
            if (numeroPedidoViewModel.Where(p => p.IdStatusPedido == StatusPedidoEnum.Pronto).Any())
            {
                if (!Controle.monitorCozinhaViewModel.Carregado)
                {
                    Controle.numerosPedidoCacheTV.AddRange(numeroPedidoViewModel.Where(p => p.IdStatusPedido == StatusPedidoEnum.Pronto).ToList());
                    Controle.monitorCozinhaViewModel.Carregado = true;
                }
                else
                {
                    foreach (var numeroPedido in numeroPedidoViewModel.Where(p => p.IdStatusPedido == StatusPedidoEnum.Pronto).ToList())
                    {
                        if (!Controle.numerosPedidoCacheTV.Where(n => n.IdNumeroPedido == numeroPedido.IdNumeroPedido).Any())
                        {
                            Controle.monitorCozinhaViewModel.beep = true;
                            numeroPedido.NovoNumero = true;
                        }
                    }

                    Controle.numerosPedidoCacheTV = new List<NumeroPedidoViewModel>();
                    Controle.numerosPedidoCacheTV.AddRange(numeroPedidoViewModel.Where(p => p.IdStatusPedido == StatusPedidoEnum.Pronto).ToList());
                }
            }
            else
            {
                Controle.numerosPedidoCacheTV = new List<NumeroPedidoViewModel>();
                Controle.monitorCozinhaViewModel.Carregado = true;
            }
            //-------------------------------------------------------------------------------------------------------------------------------------------------

            return PartialView("~/Views/Monitor/MainMonitorTv.cshtml", numeroPedidoViewModel.OrderBy(n => n.IdNumeroPedido));
        }
    }
}