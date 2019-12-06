using System;
using System.Collections.Generic;
using System.Text;

namespace JBD.MonitorCozinha.Domain.DTOS
{
    public class NumeroPedidoDTO
    {
        public int IdNumeroPedido { get; set; }
        public int IdUnidade { get; set; }
        public int IdEmpresa { get; set; }
        public string NumeroPedido { get; set; }
        public int IdStatusPedido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataPronto { get; set; }
        public DateTime? DataFinalizacao { get; set; }
    }
}
