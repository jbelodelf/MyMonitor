using Data.Repositories.Base;
using JBD.MonitorCozinha.Domain.Entitys;
using JBD.MonitorCozinha.Domain.Enuns;
using JBD.MonitorCozinha.Domain.Interfaces.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Data.Repositories
{
    public class NumeroPedidoRepository : INumeroPedidoRepository
    {
        //Delete Pedido
        public void Deletar(int Id)
        {
            Expression<Func<NumeroPedidoEntity, bool>> expressionFiltro = (a => a.IdNumeroPedido == (Int64)Id);

            using (var rep = new RepositoryBase<NumeroPedidoEntity>())
            {
                NumeroPedidoEntity pedido = rep.Select(expressionFiltro).FirstOrDefault();
                if(pedido != null)
                {
                    rep.Delete(pedido);
                }
            }
        }

        //List Pedidos
        public List<NumeroPedidoEntity> ListarPedidos(int IdEmpresa, int IdUnidade)
        {
            List<NumeroPedidoEntity> ListaPedidos = new List<NumeroPedidoEntity>();
            Expression<Func<NumeroPedidoEntity, bool>> expressionFiltro = (
                a =>
                a.IdStatusPedido != (int)StatusPedidoEnum.Entregue
                && a.IdEmpresa == IdEmpresa && a.IdUnidade == IdUnidade
            );

            using (var rep = new RepositoryBase<NumeroPedidoEntity>())
            {
                ListaPedidos = rep.Select(expressionFiltro).ToList();
            }

            return ListaPedidos;
        }

        //Get By Id Pedidos
        public NumeroPedidoEntity ObterPedidoById(int Id)
        {
            NumeroPedidoEntity pedido = new NumeroPedidoEntity();
            Expression<Func<NumeroPedidoEntity, bool>> expressionFiltro = (a => a.IdNumeroPedido == (Int64)Id);

            using (var rep = new RepositoryBase<NumeroPedidoEntity>())
            {
                pedido = rep.Select(expressionFiltro).FirstOrDefault();
            }

            return pedido;
        }

        //Save Pedidos
        public void Salvar(NumeroPedidoEntity pedido)
        {

            using (var rep = new RepositoryBase<NumeroPedidoEntity>())
            {
                if(pedido.IdNumeroPedido == 0)
                {
                    rep.Insert(pedido);
                }
                else
                {
                    rep.Update(pedido);
                }
            }

        }
    }
}
