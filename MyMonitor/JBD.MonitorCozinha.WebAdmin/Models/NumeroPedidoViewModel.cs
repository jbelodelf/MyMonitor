using JBD.MonitorCozinha.Domain.Enuns;
using System;

namespace JBD.MonitorCozinha.WebAdmin.Models
{
    public class NumeroPedidoViewModel
    {
        public Int64 IdNumeroPedido { get; set; }
        public int IdUnidade { get; set; }
        public int IdEmpresa { get; set; }
        public string NumeroPedido { get; set; }
        public StatusPedidoEnum IdStatusPedido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataPronto { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public bool NovoNumero { get; set; }
    }
}
