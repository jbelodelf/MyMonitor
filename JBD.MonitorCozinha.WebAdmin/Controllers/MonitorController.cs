using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using JBD.MonitorCozinha.WebAdmin.Models;
using JBD.MonitorCozinha.WebAdmin.Services;
using Microsoft.AspNetCore.Mvc;

namespace JBD.MonitorCozinha.WebAdmin.Controllers
{
    public class MonitorController : Controller
    {
        private readonly IMapper _mapper;
        private readonly MonitorServiceWeb _monitorServiceWeb;

        public MonitorController(IMapper mapper)
        {
            _mapper = mapper;
            _monitorServiceWeb = new MonitorServiceWeb(_mapper);
        }

        // GET: Monitor
        public ActionResult Index(int idUnidade, string NomeUnidade)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }
            Controle.ControleAcesso.IdUnidade = idUnidade;
            Controle.ControleAcesso.Unidade = NomeUnidade;

            return View();
        }

        // GET: Monitor
        public ActionResult Listar(int IdEmpresa, int IdUnidade)
        {
            if (!Controle.ValidarUsuarioLogado()) { return RedirectToAction("Index", "Login"); }

            List<NumeroPedidoViewModel> numeroPedidoViewModel = new List<NumeroPedidoViewModel>();
            var numeroPedidoDTO = _monitorServiceWeb.ListarNumeroPedidos(IdEmpresa, IdUnidade);
            numeroPedidoViewModel = _mapper.Map<List<NumeroPedidoViewModel>>(numeroPedidoDTO);

            return PartialView("~/Views/Monitor/MainMonitorTv.cshtml", numeroPedidoViewModel.OrderBy(n => n.IdNumeroPedido));
        }
    }
}