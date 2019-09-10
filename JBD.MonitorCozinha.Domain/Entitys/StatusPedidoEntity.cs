using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Entitys
{
    [Table("TbStatusPedido", Schema = "dbo")]
    public class StatusPedidoEntity
    {
        [Key]
        public int IdStatusPedido { get; set; }
        public string Status { get; set; }
        public string Descricao { get; set; }
    }
}
