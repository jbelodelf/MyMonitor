using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBD.MonitorCozinha.Domain.Entitys
{
    [Table("TbStatus", Schema = "dbo")]
    public class StatusEntity
    {
        [Key]
        public int IdStatus { get; set; }
        public int Status { get; set; }
        public int Descricao { get; set; }
    }
}
