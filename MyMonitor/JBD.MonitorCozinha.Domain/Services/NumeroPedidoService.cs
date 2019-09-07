using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using JBD.MonitorCozinha.Domain.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Services
{
    public class NumeroPedidoService : INumeroPedidoService
    {
        INumeroPedidoRepository _repository = null;

        public NumeroPedidoService (INumeroPedidoRepository repository)
        {
            _repository = repository;
        }

        public void Deletar(int Id)
        {
            _repository.Deletar(Id);
        }

        public List<NumeroPedidoEntity> ListarPedidos(int IdEmpresa, int IdUnidade)
        {
            return _repository.ListarPedidos(IdEmpresa, IdUnidade);
        }

        public NumeroPedidoEntity ObterPedidoById(int Id)
        {
            return _repository.ObterPedidoById(Id);
        }

        public void Salvar(NumeroPedidoEntity pedido)
        {
            _repository.Salvar(pedido);
        }
    }
}
