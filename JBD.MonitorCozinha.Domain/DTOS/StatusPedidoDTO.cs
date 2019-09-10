using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.DTOS
{
    public class StatusPedidoDTO
    {
        public int IdStatusPedido { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }

    }
}
