﻿using JBD.MonitorCozinha.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Interfaces.Repository
{
    public interface INumeroPedidoRepository
    {
        List<NumeroPedidoEntity> ListarPedidos(int IdEmpresa, int IdUnidade);
        NumeroPedidoEntity ObterPedidoById(int Id);
        void Salvar(NumeroPedidoEntity pedido);
        void Deletar(int Id);

    }
}
