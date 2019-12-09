using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBD.MonitorCozinha.Domain.Entitys
{
    [Table("TbNumeroPedido", Schema = "dbo")]
    public class NumeroPedidoEntity
    {
        [Key]
        public Int64 IdNumeroPedido { get; set; }
        public int IdUnidade { get; set; }
        public int IdEmpresa { get; set; }
        public string NumeroPedido { get; set; }
        public int IdStatusPedido { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime? DataPronto { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public int Controle { get; set; }
    }
}
