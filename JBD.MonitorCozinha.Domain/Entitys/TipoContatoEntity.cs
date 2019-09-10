using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBD.MonitorCozinha.Domain.Entitys
{
    [Table("TbTipoContato", Schema = "dbo")]
    public class TipoContatoEntity
    {
        [Key]
        public int IdTipoContato { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
