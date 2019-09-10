using JBD.MonitorCozinha.Application.Interfaces;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Application.Repositories
{
    public class NumeroPedidoRepositoryApp : INumeroPedidoApp
    {
        INumeroPedidoService _service = null;

        public NumeroPedidoRepositoryApp(INumeroPedidoService service)
        {
            _service = service;
        }

        public void Deletar(int Id)
        {
            _service.Deletar(Id);
        }

        public List<NumeroPedidoEntity> ListarPedidos(int IdEmpresa, int IdUnidade)
        {
            return _service.ListarPedidos(IdEmpresa, IdUnidade);
        }

        public NumeroPedidoEntity ObterPedidoById(int Id)
        {
            return _service.ObterPedidoById(Id);
        }

        public void Salvar(NumeroPedidoEntity pedido)
        {
            _service.Salvar(pedido);
        }
    }
}
