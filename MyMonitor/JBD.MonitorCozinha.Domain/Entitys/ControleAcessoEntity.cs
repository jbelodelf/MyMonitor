using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace JBD.MonitorCozinha.Domain.Entitys
{
    [Table("TbControleAcesso", Schema = "dbo")]
    public class ControleAcessoEntity
    {
        [Key]
        public int IdControleAcesso { get; set; }
        public int IdUsuario { get; set; }
        public int IdUnidade { get; set; }
        public int IdEmpresa { get; set; }
        public string IP { get; set; }
        public DateTime DataLogin { get; set; }
        public DateTime DataLogoff { get; set; }
        public bool ConexaoAtiva { get; set; }
    }
}

