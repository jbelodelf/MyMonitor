using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Entitys
{
    [Table("TbTipoUsuario", Schema = "dbo")]
    public class TipoUsuarioEntity
    {
        [Key]
        public int IdTipoUsuario { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
