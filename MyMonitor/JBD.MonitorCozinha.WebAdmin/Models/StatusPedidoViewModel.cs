using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JBD.MonitorCozinha.WebAdmin.Models
{
    public class StatusPedidoViewModel
    {
        public int IdStatusPedido { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }

    }
}
