using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBD.MonitorCozinha.Domain.Entitys
{
    [Table("TbLembreteSenha", Schema = "dbo")]
    public class LembreteSenhaEntity
    {
        [Key]
        public int IdLembreteSenha { get; set; }
        public int IdUsuario { get; set; }
        public int IdPessoa { get; set; }
        public string UserName { get; set; }
        public Guid Chave { get; set; }
        public bool ChaveValida { get; set; }
        public DateTime DataGerado { get; set; }
    }
}
