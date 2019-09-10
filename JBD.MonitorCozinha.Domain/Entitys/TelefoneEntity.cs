using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Entitys
{
    [Table("TbTelefone", Schema ="dbo")]
    public class TelefoneEntity
    {
        [Key]
        public int IdTelefone { get; set; }
        public int IdPessoa { get; set; }
        public int IdUnidade { get; set; }
        public int IdEmpresa { get; set; }
        public string DDD { get; set; }
        public string Telefone { get; set; }
        public DateTime DataCadastro { get; set; }
    }
}
