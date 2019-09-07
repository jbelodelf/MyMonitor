using JBD.MonitorCozinha.Domain.DTOS;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JBD.MonitorCozinha.Domain.Entitys
{
    [Table("TbPessoa", Schema = "dbo")]
    public class PessoaEntity
    {
        public PessoaEntity()
        {

            //Telefones = new List<TelefoneEntity>();
        }

        [Key]
        public int IdPessoa { get; set; }
        public int IdEmpresa { get; set; }
        public int IdUnidade { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string RG { get; set; }
        public string Cargo { get; set; }
        public string EmailPJ { get; set; }
        public string EmailPF { get; set; }
        public int IdStatus { get; set; }
        public int IdTipoContato { get; set; }
        public DateTime DataCadastro { get; set; }

        //public string NomeUnidade { get; set; }
        //public List<SelectListItem> TipoUsuarios { get; set; }

        //public List<TelefoneEntity> Telefones { get; set; }
    }
}
